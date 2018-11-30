using System;
using System.ComponentModel;
using System.Globalization;
using HomeTaxer.Client.Properties;

namespace HomeTaxer.Client.Configuration
{
   /// <summary>
   /// TypeConverter ��� bool
   /// </summary>
   class BooleanTypeConverter : BooleanConverter
   {
      public override object ConvertTo(ITypeDescriptorContext context, 
         CultureInfo culture,
         object value, 
         Type destType)
      {
         return (bool)value ?
            Resources.Yes : Resources.No;
      }

      public override object ConvertFrom(ITypeDescriptorContext context, 
         CultureInfo culture,
         object value)
      {
         return (string)value == Resources.Yes;
      }
   }
}
