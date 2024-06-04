﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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

        public static string ValorDescription(this Enum enumVal)
        {
            return enumVal.GetAttributeOfType<DescriptionAttribute>()?.Description ?? string.Empty;
        }

        public static float ValorPeso(this Enum enumVal)
        {
            return enumVal.GetAttributeOfType<PesoAttribute>().Valor;
        }
    }
}
