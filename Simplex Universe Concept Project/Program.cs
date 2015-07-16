using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimplexUniverse
{
    public static class Program
    {
        //Switch these comments before running to enable/disable debug mode
        //public static bool DebugMode = true;
        public static bool DebugMode = false;

        /// <summary>
        /// A reference to the debug form for universal access.
        /// </summary>
        public static DebugStartupForm DebugForm;

        /// <summary>
        /// A reference to the splash form for universal access.
        /// </summary>
        public static Splash SplashForm;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (DebugMode)
            {
                DebugForm = new DebugStartupForm();
                Application.Run(DebugForm);
            }
            else
            {
                SplashForm = new Splash();
                Application.Run(SplashForm);
            }
        }
    }
}
