using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimplexUniverse.Math;
using System.Reflection;
using System.ComponentModel;

namespace SimplexUniverse.Physics
{
    /// <summary>
    /// Represents a type of property such as mass, charge, or even net force (NEW VERSION).
    /// </summary>
    [Serializable(), Description("Represents a type of property such as mass or charge"), TypeConverter(typeof(TypeConverters.TypeConverter_ParticlePropertyType))]
    public class PropertyType
    {
        /// <summary>
        /// Represents the registry of all created property types, stored by name.
        /// </summary>
        public static Dictionary<string, PropertyType> PropertyTypeRegistry = new Dictionary<string, PropertyType>();

        /// <summary>
        /// Creates a new blank property type.
        /// </summary>
        public PropertyType()
        {
            this.Name = "";
            this.AcceptedValues = new ValidRangeCondition();
        }

        /// <summary>
        /// Creates a new blank property type with a partcular name.
        /// </summary>
        /// <param name="Name">The name to assign to the property</param>
        public PropertyType(string Name)
        {
            this.Name = Name;
            this.AcceptedValues = new ValidRangeCondition();
        }


        /// <summary>
        /// Creates a new property type with a partcular name and accepted range of values.
        /// </summary>
        /// <param name="Name">The name to assign to the property</param>
        /// <param name="AcceptedValues">The range of values acceptable to the property</param>
        public PropertyType(string Name, ValidRangeCondition AcceptedValues)
        {
            this.Name = Name;
            this.AcceptedValues = AcceptedValues;
        }


        /// <summary>
        /// Creates a new property type with a partcular name, and accepted lowerbound/upperbound values.
        /// </summary>
        /// <param name="Name">The name to assign to the property</param>
        /// <param name="Lowerbound">The accepted minimum value of the property</param>
        /// <param name="Upperbound">The accepted maximum value of the property</param>
        /// <param name="LowerInclusive">Whether the lowerbound is inclusive</param>
        /// <param name="UpperInclusive">Whether the upperbound is inclusive</param>
        public PropertyType(string Name, dynamic Lowerbound, dynamic Upperbound, bool LowerInclusive, bool UpperInclusive)
        {
            this.Name = Name;
            if (Lowerbound.GetType().IsPrimitive && Upperbound.GetType().IsPrimitive)
            {
                double LB = (double)Convert.ChangeType(Lowerbound, typeof(double));
                double UB = (double)Convert.ChangeType(Upperbound, typeof(double));
                this.AcceptedValues = new ValidRangeCondition(LB, UB, LowerInclusive, UpperInclusive);
            }
            else if (Lowerbound.GetType() == typeof(Vector) && Upperbound.GetType() == typeof(Vector))
            {
                Vector LB = (Vector)Convert.ChangeType(Lowerbound, typeof(Vector));
                Vector UB = (Vector)Convert.ChangeType(Upperbound, typeof(Vector));
                this.AcceptedValues = new ValidRangeCondition(LB, UB, LowerInclusive, UpperInclusive);
            }
            else
            {
                this.AcceptedValues = new ValidRangeCondition();
            }
        }

        /// <summary>
        /// The name of this property (such as "Mass").
        /// </summary>
        [Category("Particle KineticEnergy Type"), Description("The name of this property (such as \"Mass\")")]
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// The accepted range of values this property can have.
        /// </summary>
        [Category("Particle KineticEnergy Type"), Description("The accepted range of values this property can have")]
        public ValidRangeCondition AcceptedValues
        {
            get;
            set;
        }
    }
}
