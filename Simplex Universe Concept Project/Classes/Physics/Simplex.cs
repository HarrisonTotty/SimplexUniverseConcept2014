using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimplexUniverse.Math;
using System.ComponentModel;

namespace SimplexUniverse.Physics
{
    /// <summary>
    /// Represents a simplex object. All available universe objects inherit this object.
    /// </summary>
    [Serializable(), Description("Represents a simplex object that all available universe objects inherit")]
    public class Simplex
    {
        /// <summary>
        /// The collection of all created simplex objects that have been registered, stored by ID
        /// </summary>
        public static Dictionary<string, Simplex> ObjectRegistry = new Dictionary<string, Simplex>();


        /// <summary>
        /// Whether this object is a temporary one (and thus not added to the object registry)
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool Temporary;


        /// <summary>
        /// Creates a new simplex object with a randomly generated ID
        /// </summary>
        public Simplex()
        {
            this.ID = SimMath.GenerateSimplexObjectID();
            /*while (ObjectRegistry.ContainsKey(NID))
            {
                NID = SimMath.GenerateSimplexObjectID();
            }
            this.ID_Protected = NID;*/
        }

        /// <summary>
        /// Destroys this simplex object and removes itself from the registry.
        /// </summary>
        ~Simplex()
        {
            //this.Unregister();
        }

        /// <summary>
        /// The unique ID of this particular object
        /// </summary>
        [Category("Identity"), Description("The unique ID of this particular object"), MergableProperty(false)]
        public string ID
        {
            /*get
            {
                return this.ID_Protected;
            }
            set
            {
                if (ObjectRegistry.ContainsKey(value))
                {
                    throw new Exception("An object already exists with the ID " + value);
                }
                this.ID_Protected = value;
            }*/
            get;
            set;
        }

        /// <summary>
        /// A (usually) unique name given to this object (EX: Earth)
        /// </summary>
        [Category("Identity"), Description("A (usually) unique name given to this object (EX: Earth)")]
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// A breif description of this object
        /// </summary>
        [Category("Identity"), Description("A breif description of this object")]
        public string Description
        {
            get;
            set;
        }

        /// <summary>
        /// Forcefully sets the ID of this object without checking availability.
        /// Primarily used to copy objects
        /// </summary>
        /// <param name="ID">The ID to set this object's ID to</param>
        /*public void ForceSetID(string ID)
        {
            this.ID_Protected = ID;
        }*/

        /// <summary>
        /// Registers this object to the object registry and if an object already exists with the same ID, replaces the origional object
        /// </summary>
        public void Register()
        {
            lock (ObjectRegistry)
            {
                if (ObjectRegistry.ContainsKey(this.ID))
                {
                    ObjectRegistry[this.ID] = this;
                }
                else
                {
                    ObjectRegistry.Add(this.ID, this);
                }
            }
        }

        /// <summary>
        /// Unregisters this object from the object registry
        /// </summary>
        public void Unregister()
        {
            lock (ObjectRegistry)
            {
                if (ObjectRegistry.ContainsKey(this.ID)) ObjectRegistry.Remove(this.ID);
            }
        }
    }
}
