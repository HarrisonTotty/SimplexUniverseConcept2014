using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimplexUniverse.Simulations
{
    /// <summary>
    /// Represents a parameter for a simulation (such as a physical constant, velocity restraint, etc.)
    /// </summary>
    public class SimulationParameter
    {
        /// <summary>
        /// Creates a new simulation parameter with a given name and value
        /// </summary>
        /// <param name="Name">The name of the parameter</param>
        /// <param name="Value">The value of the parameter</param>
        public SimulationParameter(string Name, dynamic Value)
        {
            this.Name = Name;
            this.Value = Value;
        }

        /// <summary>
        /// Creates a new blank simulation parameter
        /// </summary>
        public SimulationParameter()
        {
            
        }
        
        /// <summary>
        /// The name of this paramater
        /// </summary>
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// The value that this parameter holds
        /// </summary>
        public dynamic Value
        {
            get;
            set;
        }
    }
}
