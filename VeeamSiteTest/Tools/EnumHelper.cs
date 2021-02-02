using System;
using System.ComponentModel;
using System.Reflection;

namespace VeeamSiteTest.Tools
{
    public static class EnumHelper
    {
        public static string GetDescription(Enum value)
        {
            var name = value.ToString();
            var fieldInfo = value.GetType().GetField(name);
            var attribute =
                (DescriptionAttribute)fieldInfo.GetCustomAttribute(typeof(DescriptionAttribute), false);

            return attribute.Description;
        }
    }
}
