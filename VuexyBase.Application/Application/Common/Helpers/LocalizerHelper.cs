using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuexyBase.Domain.Common.Attributes;

namespace VuexyBase.Application.Application.Common.Helpers
{
    public static class LocalizerHelper
    {
        public static string GetLocalizedName<T>(this T enumValue, string language) where T : Enum
        {
            // Get the type of the enum
            var type = enumValue.GetType();

            // Get the member info for the enum value
            var memberInfo = type.GetMember(enumValue.ToString());

            if (memberInfo.Length > 0)
            {
                // Get the LocalizedDisplay attribute if it exists
                var attribute = Attribute.GetCustomAttribute(memberInfo[0], typeof(LocalizedDisplayAttribute)) as LocalizedDisplayAttribute;

                if (attribute != null)
                {
                    // Return the appropriate language name
                    return language.ToLower() == "ar" ? attribute.NameAr : attribute.NameEn;
                }
            }

            // If no attribute is found, return the enum value as a string
            return enumValue.ToString();
        }

    }


}

