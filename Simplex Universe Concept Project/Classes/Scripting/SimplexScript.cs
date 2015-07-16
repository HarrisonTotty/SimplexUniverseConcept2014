using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimplexUniverse.Scripting
{
    /// <summary>
    /// The base class inherited by all simplex scripts
    /// </summary>
    public class SimplexScript
    {
        /// <summary>
        /// Initializes a new simplex script
        /// </summary>
        public SimplexScript()
        {
            this.Name = "";
            this.Description = "";
            this.Tags = new string[] { };
            this.RequiredSimulationParameters = new string[] { };
        }


        /// <summary>
        /// The name of this script
        /// </summary>
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// A description of what this script does or how it behaves
        /// </summary>
        public string Description
        {
            get;
            set;
        }

        /// <summary>
        /// A list of required simulation parameters (by name) that the simulation must have in order to run this script
        /// </summary>
        public string[] RequiredSimulationParameters
        {
            get;
            set;
        }


        /// <summary>
        /// A set of tags that may be used to classify this script in relation to other scripts
        /// </summary>
        public string[] Tags
        {
            get;
            set;
        }

        /// <summary>
        /// Determines if this script has a particular tag
        /// </summary>
        /// <param name="Tag">The tag to search for (not case sensitive)</param>
        public bool HasTag(string Tag)
        {
            if (this.Tags == null) return false;
            if (this.Tags.Length == 0) return false;

            foreach (string T in this.Tags)
            {
                if (T.ToLower() == Tag.ToLower())
                {
                    return true;
                }
            }

            return false;
        }


        /// <summary>
        /// Determines if this script requires a particular simulation parameter
        /// </summary>
        /// <param name="Parameter">The simulation parameter to search for (not case sensitive)</param>
        public bool RequiresSimParam(string Parameter)
        {
            if (this.RequiredSimulationParameters == null) return false;
            if (this.RequiredSimulationParameters.Length == 0) return false;

            foreach (string P in this.RequiredSimulationParameters)
            {
                if (P.ToLower() == Parameter.ToLower())
                {
                    return true;
                }
            }

            return false;
        }
    }
}
