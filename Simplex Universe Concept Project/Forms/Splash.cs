using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using System.IO;
using SimplexUniverse.IO;
using SimplexUniverse.Scripting;
using System.Threading;

namespace SimplexUniverse
{
    /// <summary>
    /// The startup form for the application.
    /// </summary>
    public partial class Splash : MetroForm
    {
        public LoadAssets LoadedAssets = new LoadAssets();


        /// <summary>
        /// Creates a new splash form.
        /// </summary>
        public Splash()
        {
            InitializeComponent();
        }

        private void Splash_Load(object sender, EventArgs e)
        {
            StartTimer.Start();
        }

        /// <summary>
        /// Recursively obtains the scripting files within a specific subdirectory
        /// </summary>
        /// <param name="Directory">The directory to scan</param>
        public List<FileInfo> ObtainScripts(string Directory)
        {
            List<FileInfo> ReturnList = new List<FileInfo>();

            DirectoryInfo ScriptsDirectory = new DirectoryInfo(Directory);

            FileInfo[] files = ScriptsDirectory.GetFiles();
            foreach (FileInfo file in files) ReturnList.Add(file);

            foreach (DirectoryInfo subdirectory in ScriptsDirectory.GetDirectories())
            {
                ReturnList.AddRange(ObtainScripts(subdirectory.FullName));
            }

            ReturnList.Capacity = ReturnList.Count;
            return ReturnList;
        }

        public void LoadScripts()
        {
            StatusLabel.Text = "Enumerating Scripts";
            List<FileInfo> ScriptFiles = ObtainScripts("Scripts");
            int NumberFiles = ScriptFiles.Count;
            PB.Maximum = NumberFiles;
            PB.Value = 0;
            RefreshComponents();

            //Load update scripts
            foreach (FileInfo file in ScriptFiles)
            {
                LoadScript(file.FullName);
                RefreshComponents();
            }
            StatusLabel.Text = "Loaded " + NumberFiles + " Scripts";
        }

        private void LoadScript(string FileName)
        {
            FileInfo file = new FileInfo(FileName);
            if (!file.Exists)
            {
                this.StatusLabel.Text = file.Name + " does not exist!";
                this.PB.Value++;
                this.PB.Style = MetroFramework.MetroColorStyle.Orange;
                Thread.Sleep(3000);
                return;
            }
            this.StatusLabel.Text = "Loading " + file.Name;
            var Results = ScriptCompiler.TestCompile_FromFile(FileName);

            //If our code has errors:
            if (Results.Errors.HasErrors)
            {
                this.StatusLabel.Text = "Error Compiling " + file.Name;
                this.PB.Value++;
                this.PB.Style = MetroFramework.MetroColorStyle.Orange;
                Thread.Sleep(3000);
                return;
            }

            //Obtain the assembly from the compiler results
            System.Reflection.Assembly ScriptAssembly = Results.CompiledAssembly;

            //Obtain the object
            Type SType = ScriptAssembly.GetType("SimplexUniverse.Scripting.Script");

            //Create an instance of the script type and return it
            SimplexScript NewScript = (SimplexScript)Activator.CreateInstance(SType);
            this.LoadedAssets.AvailableScripts.Add(NewScript);

            this.PB.Value++;
            return;
        }

        private void StatusLabel_Click(object sender, EventArgs e)
        {

        }

        private void RefreshComponents()
        {
            this.StatusLabel.Invalidate();
            this.StatusLabel.Update();
            this.StatusLabel.Refresh();
            this.PB.Invalidate();
            this.PB.Update();
            this.PB.Refresh();
        }

        private void LoadMainForm()
        {
            (new MainForm(this.LoadedAssets)).Show();
        }

        private void StartTimer_Tick(object sender, EventArgs e)
        {
            StartTimer.Stop();
            LoadScripts();
            this.LoadedAssets.AvailableScripts.Capacity = this.LoadedAssets.AvailableScripts.Count;
            LoadMainForm();
            //(new ScriptTest(this.LoadedAssets)).Show();
            this.Hide();
        }
    }
}
