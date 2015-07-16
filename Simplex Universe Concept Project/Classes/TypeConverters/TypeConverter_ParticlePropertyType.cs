using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Globalization;
using SimplexUniverse.Physics;

namespace SimplexUniverse.TypeConverters
{
    public class TypeConverter_ParticlePropertyType : ExpandableObjectConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == typeof(PropertyType))
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
                    return (value as PropertyType).Name;
                }
                return "Unknown Type";
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
}
