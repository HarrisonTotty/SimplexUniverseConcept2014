using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using SimplexUniverse.Math;

namespace SimplexUniverse.Physics
{
    /// <summary>
    /// Represents a particle of a particular size, dimensional existance, and sub-particles.
    /// </summary>
    [Serializable(), Description("Represents a particle of a particular size, dimensional existance, and sub-particles"), TypeConverter(typeof(TypeConverters.TypeConverter_Particle))]
    public class Particle : Simplex
    {
        /// <summary>
        /// Creates a new 2D Particle of zero size and no properties/parent/children.
        /// </summary>
        public Particle()
        {
            this.Position = new Vector();
            this.Velocity = new Vector();
            this.Acceleration = new Vector();
            this.NetForce = new Vector();
            this.Properties = new List<ParticleProperty>();
            this.SubParticles = new List<Particle>();
            this.Radius = 0;
        }

        /// <summary>
        /// Creates a new 2D Particle of a particular size and no properties/parent/children.
        /// </summary>
        /// <param name="Radius">The size (radius) of the particle</param>
        public Particle(double Radius)
        {
            this.Position = new Vector();
            this.Velocity = new Vector();
            this.Acceleration = new Vector();
            this.NetForce = new Vector();
            this.Properties = new List<ParticleProperty>();
            this.SubParticles = new List<Particle>();
            this.Radius = Radius;
        }

        /// <summary>
        /// Creates a new particle of a particular dimensional existance of zero size and no properties/parent/children.
        /// </summary>
        /// <param name="NumberDimensions">The number of dimensions this particle exists in</param>
        public Particle(int NumberDimensions)
        {
            this.Position = new Vector(NumberDimensions);
            this.Velocity = new Vector(NumberDimensions);
            this.Acceleration = new Vector(NumberDimensions);
            this.NetForce = new Vector(NumberDimensions);
            this.Properties = new List<ParticleProperty>();
            this.SubParticles = new List<Particle>();
            this.Radius = 0;
        }

        /// <summary>
        /// Creates a new particle of a particular dimensional existance and size with no properties/parent/children.
        /// </summary>
        /// <param name="NumberDimensions">The number of dimensions this particle exists in</param>
        /// <param name="Radius">The size of the particle</param>
        public Particle(int NumberDimensions, double Radius)
        {
            this.Position = new Vector(NumberDimensions);
            this.Velocity = new Vector(NumberDimensions);
            this.Acceleration = new Vector(NumberDimensions);
            this.Properties = new List<ParticleProperty>();
            this.SubParticles = new List<Particle>();
            this.Radius = Radius;
        }

        /// <summary>
        /// Gets or sets the vector corresponding to the position of this particle relative to its parent.
        /// </summary>
        [Category("Dynamics"), Description("The position vector of this particle relative to its parent")]
        public Vector Position
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the vector corresponding to the velocity of this particle relative to its parent.
        /// </summary>
        [Category("Dynamics"), Description("The velocity vector of this particle relative to its parent")]
        public Vector Velocity
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the vector corresponding to the acceleration of this particle relative to its parent.
        /// </summary>
        [Category("Dynamics"), Description("The acceleration vector of this particle relative to its parent")]
        public Vector Acceleration
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the sub-particles (children) of this particle.
        /// </summary>
        [Category("Hierarchy"), Description("The list of sub-particles (or children) within this particle"), DefaultValue(null)]
        public List<Particle> SubParticles
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the parent of this particle.
        /// </summary>
        [Category("Hierarchy"), Description("The parent particle of this particle"), DefaultValue(null)]
        public Particle ParentParticle
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the list of properties for this particle (such as mass or charge).
        /// </summary>
        [Category("Properties"), Description("The various properties this particle has (such as mass or charge)")]
        public List<ParticleProperty> Properties
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the radius of this particle.
        /// </summary>
        [Category("Properties"), Description("The radius of this particle"), DefaultValue(0)]
        public double Radius
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the number of dimensions of movement this particle exists in.
        /// Note that lowering the number of dimensions may result in data loss.
        /// </summary>
        [Category("Properties"), Description("The number of dimensions of movement this particle exists in"), DefaultValue(2)]
        public int NumberDimensions
        {
            get
            {
                //Return the number of numbers in the position vector
                return this.Position.Count;
            }
            set
            {
                //If the new value is invalid, complain
                if (value <= 0) return;

                //Create new vectors to hold the numbers
                Vector NewNF = new Vector(value);
                Vector NewA = new Vector(value);
                Vector NewV = new Vector(value);
                Vector NewP = new Vector(value);

                for (int i = 0; i < value; i++)
                {
                    NewNF[i] = this.NetForce[i];
                    NewA[i] = this.Acceleration[i];
                    NewV[i] = this.Velocity[i];
                    NewP[i] = this.Position[i];
                }

                this.NetForce = NewNF;
                this.Acceleration = NewA;
                this.Velocity = NewV;
                this.Position = NewP;
            }
        }

        /// <summary>
        /// Gets or sets the vector corresponding to current net force experienced by this particle.
        /// </summary>
        [Category("Dynamics"), Description("The vector corresponding to current net force experienced by this particle relative to its parent")]
        public Vector NetForce
        {
            get;
            set;
        }

        /// <summary>
        /// Copies a particle and all child references but does not copy children.
        /// </summary>
        /// <param name="InputParticle">The particle to copy</param>
        /// <param name="CopyID">Whether to copy the current particle's ID to the new particle</param>
        public static Particle Copy_Shallow(Particle InputParticle, bool CopyID)
        {
            Particle ReturnParticle = new Particle(InputParticle.NumberDimensions);

            ReturnParticle.ParentParticle = InputParticle.ParentParticle; //We MUST make sure that we DON'T make a new parent
            ReturnParticle.Acceleration = Vector.Vector_Copy(InputParticle.Acceleration);
            ReturnParticle.Velocity = Vector.Vector_Copy(InputParticle.Velocity);
            ReturnParticle.Position = Vector.Vector_Copy(InputParticle.Position);
            ReturnParticle.NetForce = Vector.Vector_Copy(InputParticle.NetForce);
            ReturnParticle.Radius = InputParticle.Radius;
            if (CopyID) ReturnParticle.ID = InputParticle.ID;

            foreach (dynamic Prop in InputParticle.Properties)
            {
                ReturnParticle.Properties.Add(Prop.Copy());
            }

            foreach (Particle SubParticle in InputParticle.SubParticles)
            {
                ReturnParticle.SubParticles.Add(SubParticle);
            }

            return ReturnParticle;
        }


        /// <summary>
        /// Copies a particle and all sub-particles.
        /// </summary>
        /// <param name="InputParticle">The particle to copy</param>
        /// <param name="CopyID">Whether to copy the current particle's ID to the new particle</param>
        public static Particle Copy_Full(Particle InputParticle, bool CopyID)
        {
            Particle ReturnParticle = new Particle(InputParticle.NumberDimensions);

            ReturnParticle.ParentParticle = InputParticle.ParentParticle; //We MUST make sure that we DON'T make a new parent
            ReturnParticle.Acceleration = Vector.Vector_Copy(InputParticle.Acceleration);
            ReturnParticle.Velocity = Vector.Vector_Copy(InputParticle.Velocity);
            ReturnParticle.Position = Vector.Vector_Copy(InputParticle.Position);
            ReturnParticle.NetForce = Vector.Vector_Copy(InputParticle.NetForce);
            ReturnParticle.Radius = InputParticle.Radius;
            if (CopyID) ReturnParticle.ID = InputParticle.ID;

            foreach (dynamic Prop in InputParticle.Properties)
            {
                ReturnParticle.Properties.Add(Prop.Copy());
            }

            foreach (Particle SubParticle in InputParticle.SubParticles)
            {
                ReturnParticle.SubParticles.Add(Particle.Copy_Full(SubParticle, CopyID));
            }

            return ReturnParticle;
        }

        /// <summary>
        /// Grabs a particular property of this particle by name (not case sensitive) and returns a null value if the property is not found.
        /// </summary>
        /// <param name="PropertyName">The name of the property to grab</param>
        public ParticleProperty GrabProperty(string PropertyName)
        {
            foreach (ParticleProperty Prop in this.Properties)
            {
                if (Prop.Type.Name.ToLower() == PropertyName.ToLower())
                {
                    return (ParticleProperty)Prop;
                }
            }
            return null;
        }

        /// <summary>
        /// Determines if this particle has a particular property by name and value type(not case sensitive).
        /// </summary>
        /// <param name="PropertyName">The name of the property to test</param>
        public bool HasProperty(string PropertyName)
        {
            foreach (ParticleProperty Prop in this.Properties)
            {
                if (Prop.Type.Name.ToLower() == PropertyName.ToLower())
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Gets the actual (non-relative or global) position of this particle.
        /// </summary>
        public Vector GetActualPosition()
        {
            Particle Parent = this.ParentParticle;
            Vector ActualPosition = Vector.Vector_Copy(this.Position);

            //While the parent isn't null:
            while (Parent != null)
            {
                //Add the parent's position to the summation
                ActualPosition = Vector.Vector_Add(ActualPosition, Parent.Position);

                //Recursively set the parent
                Parent = Parent.ParentParticle;
            }

            return ActualPosition;
        }

        /// <summary>
        /// Gets the actual (non-relative or global) velocity of this particle.
        /// </summary>
        public Vector GetActualVelocity()
        {
            Particle Parent = this.ParentParticle;
            Vector ActualVelocity = Vector.Vector_Copy(this.Velocity);

            //While the parent isn't null:
            while (Parent != null)
            {
                //Add the parent's velocity to the summation
                ActualVelocity = Vector.Vector_Add(ActualVelocity, Parent.Velocity);

                //Recursively set the parent
                Parent = Parent.ParentParticle;
            }

            return ActualVelocity;
        }

        /// <summary>
        /// Gets the actual (non-relative or global) acceleration of this particle.
        /// </summary>
        public Vector GetActualAcceleration()
        {
            Particle Parent = this.ParentParticle;
            Vector ActualAcceleration = Vector.Vector_Copy(this.Acceleration);

            //While the parent isn't null:
            while (Parent != null)
            {
                //Add the parent's acceleration to the summation
                ActualAcceleration = Vector.Vector_Add(ActualAcceleration, Parent.Acceleration);

                //Recursively set the parent
                Parent = Parent.ParentParticle;
            }

            return ActualAcceleration;
        }

        /// <summary>
        /// Determines an appropriate relative position from this particle's parent from a non-relative actual position.
        /// Used when this.Position is not known or is incorrect and/or needs to be updated.
        /// </summary>
        /// <param name="GlobalPosition">The un-relative actual position of this particle</param>
        public Vector GetRelativePositionFromGlobal(Vector GlobalPosition)
        {
            Particle Parent = this.ParentParticle;
            Vector Relative = Vector.Vector_Copy(GlobalPosition);

            //While the parent isn't null:
            while (Parent != null)
            {
                //Subtract the parent's position from the relative position
                Relative = Vector.Vector_Subtract(Relative, Parent.Position);

                //Recursively set the parent
                Parent = Parent.ParentParticle;
            }

            return Relative;
        }

        /// <summary>
        /// Gets the density of a particular property by name for this particle. Returns null if property wasn't found or doesn't support density.
        /// </summary>
        /// <param name="PropertyName">The name of the property to look up</param>
        public dynamic GetPropertyDensity(string PropertyName)
        {
            //Grab the property and make sure that it isn't null
            var prop = this.GrabProperty(PropertyName);
            if (prop == null) return null;
            return (prop.Value / this.Radius);
        }

        /// <summary>
        /// Returns a list of particles from a particular child depth.
        /// </summary>
        /// <param name="Depth">The depth to grab (1 being the first layer of children, etc.)</param>
        public List<Particle> GrabChildDepth(int Depth)
        {
            //If the depth is zero, we cannot grab the list
            if (Depth <= 0) return null;

            //If the depth is 1:
            if (Depth == 1)
            {
                //Return this particle's subparticles
                return this.SubParticles;
            }
            else //If the depth is greater than 1:
            {
                if (this.SubParticles == null) return null;

                //Create a new list to hold the recursive lists
                List<Particle> RecursiveList = new List<Particle>();

                //For each subparticle:
                foreach (Particle SubParticle in this.SubParticles)
                {
                    //Check for errors
                    if (SubParticle == null) continue;
                    if (SubParticle.SubParticles == null) continue;

                    //Find all the children at the depth - 1
                    RecursiveList.AddRange(SubParticle.GrabChildDepth(Depth - 1));
                }

                //Clean up the list
                RecursiveList.Capacity = RecursiveList.Count;

                //Return
                return RecursiveList;
            }
        }


        /// <summary>
        /// Compares two particles, returning true if they are the same particle.
        /// </summary>
        /// <param name="Particle1">The first particle to compare</param>
        /// <param name="Particle2">The second particle to compare</param>
        public static bool Compare(Particle Particle1, Particle Particle2)
        {
            return (Particle1.ID == Particle2.ID);
        }


        /// <summary>
        /// Returns the value of a particular property by name
        /// </summary>
        /// <param name="PropertyName">The name of the property (not case sensitive)</param>
        public dynamic GetPropertyVal(string PropertyName)
        {
            foreach (ParticleProperty Prop in this.Properties)
            {
                if (Prop.Type.Name.ToLower() == PropertyName.ToLower())
                {
                    return Prop.Value;
                }
            }
            return null;
        }

        /// <summary>
        /// Sets a property of this particle to a particular value.
        /// </summary>
        /// <param name="PropertyName">The name of the property (not case sensitive)</param>
        /// <param name="Value">The value to set the property to</param>
        public void SetProperty(string PropertyName, dynamic Value)
        {
            foreach (ParticleProperty Prop in this.Properties)
            {
                if (Prop.Type.Name.ToLower() == PropertyName.ToLower())
                {
                    Prop.Value = Value;
                    return;
                }
            }
            return;
        }

        /// <summary>
        /// Adds a property of a particular type and value to this particle
        /// </summary>
        /// <param name="PType">The type of property to add (such as "mass" or "charge"</param>
        /// <param name="Value">The value of the new property</param>
        public void AddProperty(PropertyType PType, dynamic Value)
        {
            if (PType == null) return;
            this.Properties.Add(new ParticleProperty(PType, Value));
        }
    }
}
