using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Globalization;
using SimplexUniverse.Physics;

namespace SimplexUniverse.TypeConverters
{
    public class TypeConverter_ParticleProperty : ExpandableObjectConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == typeof(ParticleProperty))
            {
                return true;
            }
            return base.CanConvertFrom(context, sourceType);
        }


        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            //if (value is string)
            //{
            //    return 
            //}
            return base.ConvertFrom(context, culture, value);
        }


        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                if (value != null)
                {
                    if ((value as ParticleProperty).Type != null)
                    {
                        return (value as ParticleProperty).Type.Name;
                    }
                    else
                    {
                        return "Unknown Type";
                    }
                }
                return "Null";
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
}
