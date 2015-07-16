using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimplexUniverse.Scripting
{
    /// <summary>
    /// Represents a collection of simplex scripts
    /// </summary>
    public class ScriptCollection : List<SimplexScript>
    {
        /// <summary>
        /// Returns a list of scripts of a particular type contained within this script collection.
        /// This method returns "null" if no scripts of that particular type are found.
        /// </summary>
        /// <typeparam name="T">The type of script to extract</typeparam>
        public List<T> ExtractScripts<T>() where T : SimplexScript
        {
            //Create a new list to store the found scripts
            List<T> ReturnList = new List<T>();

            //For each available script:
            foreach (SimplexScript Script in this)
            {
                //If the script is the type we are looking for:
                if (Script is T)
                {
                    //Add the script to the list
                    T ConvertedScript = (T)(object)Script;
                    ReturnList.Add(ConvertedScript);
                }
            }

            //If we didn't find any scripts of that type, return null
            if (ReturnList.Count == 0) return null;

            //Return the list of scripts
            return ReturnList;
        }


        /// <summary>
        /// Extracts a script by a particular name and type
        /// </summary>
        /// <typeparam name="T">The type of script to extract</typeparam>
        /// <param name="ScriptName">The name of the script to extract (not case sensitive)</param>
        public T ExtractScript<T>(string ScriptName) where T : SimplexScript
        {
            //For each available script:
            foreach (SimplexScript Script in this)
            {
                //If the script is the type we are looking for:
                if (Script is T)
                {
                    if (Script.Name.ToLower() == ScriptName.ToLower())
                    {
                        //Return the script
                        return (T)(object)Script;
                    }
                }
            }

            return default(T);
        }

        /// <summary>
        /// Determines if a particular script is in the collection by name (not case sensitive)
        /// </summary>
        /// <param name="ScriptName">The name of the script to search for</param>
        public bool HasScript(string ScriptName)
        {
            foreach (SimplexScript Script in this)
            {
                if (Script.Name.ToLower() == ScriptName.ToLower())
                {
                    return true;
                }
            }
            return false;
        }


        /// <summary>
        /// Determines if a particular script is in the collection by name and type (not case sensitive)
        /// </summary>
        /// <typeparam name="T">The type of script to search for</typeparam>
        /// <param name="ScriptName">The name of the script to search for</param>
        public bool HasScript<T>(string ScriptName) where T : SimplexScript
        {
            foreach (SimplexScript Script in this)
            {
                if (Script is T)
                {
                    if (Script.Name.ToLower() == ScriptName.ToLower())
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
