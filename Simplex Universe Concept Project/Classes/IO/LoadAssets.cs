using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimplexUniverse.Scripting;
using SimplexUniverse.Simulations;

namespace SimplexUniverse.IO
{
    /// <summary>
    /// Represents all of the neccessary stuff we obtain from loading when the application starts
    /// </summary>
    public class LoadAssets
    {
        /// <summary>
        /// Create a new set of load assets
        /// </summary>
        public LoadAssets()
        {
            this.AvailableScripts = new ScriptCollection();
        }

        /// <summary>
        /// The available boundary scripts
        /// </summary>
        public ScriptCollection AvailableScripts
        {
            get;
            set;
        }
    }
}
