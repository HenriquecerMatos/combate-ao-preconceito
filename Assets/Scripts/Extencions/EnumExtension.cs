using NUnit.Framework.Constraints;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Extencions
{
    public static class EnumExtension
    {
        /// <summary>
        /// Gets an attribute on an enum field value
        /// </summary>
        /// <typeparam name="T">The type of the attribute you want to retrieve</typeparam>
        /// <param name="enumVal">The enum value</param>
        /// <returns>The attribute of type T that exists on the enum value</returns>
        /// <example><![CDATA[string desc = myEnumVariable.GetAttributeOfType<DescriptionAttribute>().Description;]]></example>
        /// <example><![CDATA[string desc = myEnumVariable.GetAttributeOfType<ColorAttribute>().Description;]]></example>
        public static T GetAttributeOfType<T>(this Enum enumVal) where T : System.Attribute
        {
            var type = enumVal.GetType();
            var memInfo = type.GetMember(enumVal.ToString());
            var attributes = memInfo[0].GetCustomAttributes(typeof(T), false);
            return (attributes.Length > 0) ? (T)attributes[0] : null;
        }

        /// <summary>
        /// pegando o valor pela DescriptionAttribute
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Dictionary<int, string> ToDictionaryIntString<T>() where T : Enum
        {
            Dictionary<int, string> ret = new() ;
            foreach (var value in Enum.GetValues(typeof(T)))
            {
                FieldInfo fi = typeof(T).GetField(value.ToString());
                DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

                string description = (attributes.Length > 0) ? attributes[0].Description : value.ToString();
                ret.Add((int)value, description);
            }
            return ret;
        }

        /// <summary>
        /// valor da descrição
        /// </summary>
        /// <param name="enumVal"></param>
        /// <returns></returns>
        public static string ValorDescription(this Enum enumVal)
        {
            return enumVal.GetAttributeOfType<DescriptionAttribute>()?.Description ?? string.Empty;
        }
        /// <summary>
        /// valor do peso (float)
        /// </summary>
        /// <param name="enumVal"></param>
        /// <returns></returns>
        public static float ValorPeso(this Enum enumVal)
        {
            return enumVal.GetAttributeOfType<PesoAttribute>().Valor;
        }
    }
}
