using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Dynamic;
using Microsoft.CSharp;
using System.CodeDom.Compiler;
using System.Reflection;
using SimplexUniverse.Math;
using SimplexUniverse.Physics;
using SimplexUniverse.Simulations;
using SimplexUniverse.VisualizationComponents;

namespace SimplexUniverse.Scripting
{
    /// <summary>
    /// Contains methods for the dynamic compilation of scripts at runtime.
    /// </summary>
    public class ScriptCompiler
    {
        /// <summary>
        /// A link to the C# compiler used for dynamic execution
        /// </summary>
        public static CSharpCodeProvider CSProvider = new CSharpCodeProvider();

        /// <summary>
        /// A link to the C# compiler parameters
        /// </summary>
        public static CompilerParameters Parameters = new CompilerParameters() { GenerateInMemory = true, GenerateExecutable = false, IncludeDebugInformation = false };

        /// <summary>
        /// Compiles a script of any type from source code and returns a new instantiated script object
        /// </summary>
        /// <param name="Code">The string of code to compile</param>
        /// <typeparam name="T">The base type that this script inherits</typeparam>
        public static T CompileScript_FromSource<T>(string Code)
        {
            //Check script validaty
            if (!IsValidScript(Code)) throw new Exception("Invalid Script Format!");

            //Add all of the neccessary assemblies
            Parameters.ReferencedAssemblies.Clear();
            Assembly executingAssembly = Assembly.GetExecutingAssembly();
            Parameters.ReferencedAssemblies.Add(executingAssembly.Location);
            foreach (AssemblyName assemblyName in executingAssembly.GetReferencedAssemblies())
            {
                Parameters.ReferencedAssemblies.Add(Assembly.Load(assemblyName).Location);
            }

            //Compile the code into a compiler results object
            CompilerResults Results = CSProvider.CompileAssemblyFromSource(Parameters, Code);

            //If our code has errors:
            if (Results.Errors.HasErrors)
            {
                throw new Exception("Unable to compile script!");
            }

            //Obtain the assembly from the compiler results
            Assembly ScriptAssembly = Results.CompiledAssembly;

            //Obtain the object
            Type ScriptType = ScriptAssembly.GetType("SimplexUniverse.Scripting.Script");

            //Create an instance of the script type and return it
            return (T)Activator.CreateInstance(ScriptType);
        }

        /// <summary>
        /// Compiles a script of any type from source code and returns the compiler results
        /// </summary>
        /// <param name="Code">The string of code to compile</param>
        public static CompilerResults TestCompile_FromSource(string Code)
        {
            //Check script validaty
            if (!IsValidScript(Code)) throw new Exception("Invalid Script Format!");

            //Add all of the neccessary assemblies
            Parameters.ReferencedAssemblies.Clear();
            Assembly executingAssembly = Assembly.GetExecutingAssembly();
            Parameters.ReferencedAssemblies.Add(executingAssembly.Location);
            foreach (AssemblyName assemblyName in executingAssembly.GetReferencedAssemblies())
            {
                Parameters.ReferencedAssemblies.Add(Assembly.Load(assemblyName).Location);
            }

            //Compile the code into a compiler results object
            return CSProvider.CompileAssemblyFromSource(Parameters, Code);
        }

        /// <summary>
        /// Compiles a script of any type from source code and returns the compiler results
        /// </summary>
        /// <param name="File">The path to the source code file</param>
        public static CompilerResults TestCompile_FromFile(string File)
        {
            //Add all of the neccessary assemblies
            Parameters.ReferencedAssemblies.Clear();
            Assembly executingAssembly = Assembly.GetExecutingAssembly();
            Parameters.ReferencedAssemblies.Add(executingAssembly.Location);
            foreach (AssemblyName assemblyName in executingAssembly.GetReferencedAssemblies())
            {
                Parameters.ReferencedAssemblies.Add(Assembly.Load(assemblyName).Location);
            }

            //Compile the code into a compiler results object
            return CSProvider.CompileAssemblyFromFile(Parameters, File);
        }

        /// <summary>
        /// Compiles a script of any type from a source file and returns a new instantiated script object
        /// </summary>
        /// <param name="File">The file path to the source code to compile</param>
        /// <typeparam name="T">The base type that this script inherits</typeparam>
        public static T CompileScript_FromFile<T>(string File)
        {
            //Check script validity
            

            //Add all of the neccessary assemblies
            Parameters.ReferencedAssemblies.Clear();
            Assembly executingAssembly = Assembly.GetExecutingAssembly();
            Parameters.ReferencedAssemblies.Add(executingAssembly.Location);
            foreach (AssemblyName assemblyName in executingAssembly.GetReferencedAssemblies())
            {
                Parameters.ReferencedAssemblies.Add(Assembly.Load(assemblyName).Location);
            }

            //Compile the code into a compiler results object
            CompilerResults Results = CSProvider.CompileAssemblyFromFile(Parameters, File);

            //If our code has errors:
            if (Results.Errors.HasErrors)
            {
                throw new Exception("Unable to compile script!");
            }

            //Obtain the assembly from the compiler results
            Assembly ScriptAssembly = Results.CompiledAssembly;

            //Obtain the object
            Type ScriptType = ScriptAssembly.GetType();

            //Create an instance of the script type and return it
            return (T)Activator.CreateInstance(ScriptType);
        }

        /// <summary>
        /// Quick-checks a source code string to make sure that it is a valid script.
        /// </summary>
        /// <param name="Code">The source code to check</param>
        public static bool IsValidScript(string Code)
        {
            if (!Code.Contains("namespace SimplexUniverse.Scripting")) return false;
            if (!Code.Contains("class Script")) return false;

            return true;
        }
    }
}
