using HeCopUI_Framework.Structs;
using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Globalization;
using System.Reflection;

namespace HeCopUI_Framework.Converter
{
    public class CornerRadiusConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType) =>
            sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);

        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType) =>
            destinationType == typeof(InstanceDescriptor) || base.CanConvertTo(context, destinationType);

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if (value is string str)
            {
                str = str.Trim();
                if (string.IsNullOrEmpty(str)) return null;

                if (culture == null)
                    culture = CultureInfo.CurrentCulture;

                string separator = culture.TextInfo.ListSeparator;
                string[] parts = str.Split(new string[] { separator }, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length != 4)
                    throw new ArgumentException($"Cannot parse '{str}' as CornerRadius.");

                for (int i = 0; i < parts.Length; i++)
                    parts[i] = parts[i].Trim();

                float[] vals = Array.ConvertAll(parts, s => float.Parse(s, culture));
                return new CornerRadius(vals[0], vals[1], vals[2], vals[3]);
            }

            return base.ConvertFrom(context, culture, value);
        }


        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (value is CornerRadius cr)
            {
                if (culture == null)
                    culture = CultureInfo.CurrentCulture;

                if (destinationType == typeof(string))
                {
                    return string.Join(culture.TextInfo.ListSeparator + " ",
                        new object[] { cr.TopLeft, cr.TopRight, cr.BottomLeft, cr.BottomRight });
                }
                else if (destinationType == typeof(InstanceDescriptor))
                {
                    return cr.ShouldSerializeAll()
                        ? new InstanceDescriptor(typeof(CornerRadius).GetConstructor(new[] { typeof(float) }),
                                                 new object[] { cr.All })
                        : new InstanceDescriptor(typeof(CornerRadius).GetConstructor(new[] { typeof(float), typeof(float), typeof(float), typeof(float) }),
                                                 new object[] { cr.TopLeft, cr.TopRight, cr.BottomLeft, cr.BottomRight });
                }
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }

        public override object CreateInstance(ITypeDescriptorContext context, IDictionary propertyValues)
        {
            if (propertyValues is null) throw new ArgumentNullException(nameof(propertyValues));

            return new CornerRadius(
                (float)propertyValues[nameof(CornerRadius.TopLeft)],
                (float)propertyValues[nameof(CornerRadius.TopRight)],
                (float)propertyValues[nameof(CornerRadius.BottomLeft)],
                (float)propertyValues[nameof(CornerRadius.BottomRight)]
            );
        }

        public override bool GetCreateInstanceSupported(ITypeDescriptorContext context) => true;
        public override bool GetPropertiesSupported(ITypeDescriptorContext context) => true;

        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
        {
            var properties = TypeDescriptor.GetProperties(typeof(CornerRadius), attributes);
            //return properties.Sort(nameof(CornerRadius.All), nameof(CornerRadius.TopLeft), nameof(CornerRadius.TopRight), nameof(CornerRadius.BottomLeft), nameof(CornerRadius.BottomRight));

            string[] order = new string[] { "All", "TopLeft", "TopRight", "BottomLeft", "BottomRight" };

            return properties.Sort(order);
        }
    }
}
