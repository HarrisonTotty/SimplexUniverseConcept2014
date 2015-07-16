using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimplexUniverse.Math;
using System.ComponentModel;

namespace SimplexUniverse.Physics
{

    /// <summary>
    /// Represents a property that a particle particle holds.
    /// </summary>
    [Serializable(), Description("Represents a property that a particle particle holds"), TypeConverter(typeof(TypeConverters.TypeConverter_ParticleProperty))]
    public class ParticleProperty
    {
        [Browsable(false)]
        private dynamic FieldValue;

        /// <summary>
        /// Creates a new blank particle property with no initial value or type.
        /// </summary>
        public ParticleProperty()
        {
            
        }


        /// <summary>
        /// Creates a new particle property of a particular type.
        /// </summary>
        /// <param name="PType">The particle property type (such as "mass" or "charge")</param>
        public ParticleProperty(PropertyType PType)
        {
            this.Type = PType;
        }

        /// <summary>
        /// Creates a new particle property of a particular type and value
        /// </summary>
        /// <param name="PType">The particle property type (such as "mass" or "charge")</param>
        /// <param name="Value">The value associated with the new property</param>
        public ParticleProperty(PropertyType PType, dynamic Value)
        {
            this.Type = PType;
            this.Value = Value;
        }


        /// <summary>
        /// The value of the property that this particle holds.
        /// If a value is set outside the accepted value range for this property's type, it will be automatically resolved.
        /// </summary>
        [Category("Particle KineticEnergy"), Description("The value of the property that this particle holds")]
        public dynamic Value
        {
            get
            {
                return FieldValue;
            }
            set
            {
                FieldValue = this.Type.AcceptedValues.Resolve(value);
            }
        }

        /// <summary>
        /// The property type associated with this value (such as "Mass" or "Charge")
        /// </summary>
        [Category("Particle KineticEnergy"), Description("The property type associated with this value (such as \"Mass\" or \"Charge\")")]
        public PropertyType Type
        {
            get;
            set;
        }

        /// <summary>
        /// Creates a shallow copy of this property.
        /// </summary>
        public ParticleProperty Copy()
        {
            ParticleProperty Copied = new ParticleProperty();

            Copied.Type = this.Type;
            Copied.Value = this.Value;

            return Copied;
        }
    }
}
