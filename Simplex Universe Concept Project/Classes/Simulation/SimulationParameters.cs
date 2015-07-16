using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimplexUniverse.Simulations
{
    /// <summary>
    /// Represents a list of simulation parameters
    /// </summary>
    [Serializable()]
    public class SimulationParameters : List<SimulationParameter>
    {
        /// <summary>
        /// Determines if a parameter is in the list of parameters by name (not case sensitive)
        /// </summary>
        /// <param name="ParameterName">The name of the parameter to search for</param>
        public bool HasParam(string ParameterName)
        {
            foreach (SimulationParameter Param in this)
            {
                if (Param.Name.ToLower() == ParameterName.ToLower())
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Returns a paramter's value by name (not case sensitive) (and returns null if the parameter wasn't found)
        /// </summary>
        /// <param name="ParameterName">The name of the parameter to search for</param>
        public dynamic GetParam(string ParameterName)
        {
            foreach (SimulationParameter Param in this)
            {
                if (Param.Name.ToLower() == ParameterName.ToLower())
                {
                    return Param.Value;
                }
            }
            return null;
        }

        /// <summary>
        /// Sets a parameter to a particular value.
        /// </summary>
        /// <param name="ParameterName">The name of the parameter to change (not case sensitive)</param>
        /// <param name="Value">The value to change the parameter to</param>
        public void SetParam(string ParameterName, dynamic Value)
        {
            foreach (SimulationParameter Param in this)
            {
                if (Param.Name.ToLower() == ParameterName.ToLower())
                {
                    Param.Value = Value;
                    return;
                }
            }
            return;
        }
    }
}
