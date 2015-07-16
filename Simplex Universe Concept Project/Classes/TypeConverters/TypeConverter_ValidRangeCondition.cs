using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Globalization;
using SimplexUniverse.Math;

namespace SimplexUniverse.TypeConverters
{
    public class TypeConverter_ValidRangeCondition : ExpandableObjectConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == typeof(ValidRangeCondition))
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
                    ValidRangeCondition v = (value as ValidRangeCondition);
                    string ReturnString = "";

                    if (v.MinimumInclusive) ReturnString += "[";
                    else ReturnString += "(";

                    if (v.MinimumValue == double.PositiveInfinity) ReturnString += "Infinity, ";
                    else if (v.MinimumValue == double.NegativeInfinity) ReturnString += "-Infinity, ";
                    else ReturnString += v.MinimumValue.ToString("n") + ", ";

                    if (v.MaximumValue == double.PositiveInfinity) ReturnString += "Infinity";
                    else if (v.MaximumValue == double.NegativeInfinity) ReturnString += "-Infinity";
                    else ReturnString += v.MaximumValue.ToString("n");

                    if (v.MaximumInclusive) ReturnString += "]";
                    else ReturnString += ")";

                    if (v.ExcludedValues != null)
                    {
                        if (v.ExcludedValues.Count > 0)
                        {
                            ReturnString += " Excluding {";
                            for (int i = 0; i < v.ExcludedValues.Count; i++)
                            {
                                if (i == v.ExcludedValues.Count - 1)
                                {
                                    ReturnString += v.ExcludedValues[i].ToString("n");
                                }
                                else
                                {
                                    ReturnString += v.ExcludedValues[i].ToString("n") + ", ";
                                }
                            }
                            ReturnString += "}";
                        }
                    }

                    return ReturnString;
                }
                return "Null";
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
}
