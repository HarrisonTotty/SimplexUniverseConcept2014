using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimplexUniverse.Scripting
{
    /// <summary>
    /// Represents a list of interaction scripts
    /// </summary>
    public class InteractionScripts : List<InteractionScript>
    {
        /// <summary>
        /// Determines if an interaction script is in the list of interactions by name (not case sensitive)
        /// </summary>
        /// <param name="InteractionName">The name of the interaction to search for</param>
        public bool HasScript(string InteractionName)
        {
            foreach (InteractionScript IntScript in this)
            {
                if (IntScript.Name.ToLower() == InteractionName.ToLower())
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Returns an interaction script by name (not case sensitive)
        /// </summary>
        /// <param name="InteractionName">The name of the interaction script to search for</param>
        public InteractionScript GetScript(string InteractionName)
        {
            foreach (InteractionScript IntScript in this)
            {
                if (IntScript.Name.ToLower() == InteractionName.ToLower())
                {
                    return IntScript;
                }
            }
            return null;
        }

        /// <summary>
        /// Extracts a sub-list of intraction scripts by tag (not case sensitive)
        /// </summary>
        /// <param name="Tag">The tag string to extract by</param>
        public InteractionScripts ExtractByTag(string Tag)
        {
            InteractionScripts New = new InteractionScripts();
            foreach (InteractionScript IntScript in this)
            {
                if (IntScript.HasTag(Tag))
                {
                    New.Add(IntScript);
                }
            }
            return New;
        }
    }
}
