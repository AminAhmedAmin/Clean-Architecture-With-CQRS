using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuexyBase.Domain.Enums.Validation;

namespace VuexyBase.Application.Application.Common.Helpers
{
    public static class FluentValidationHelper
    {
        public static string Message<T>(string lang, string propName, ValidationTypesEnum type, IStringLocalizer localizer, params object[] inputs)
        {
            var propDescription = GetDisplayName<T>(propName, lang);
            var messageInputs = AppendToParams(propDescription, inputs);
            // Example: your keys should be like "Required", "MaxLength", etc.
            var localizedMessage = localizer[type.ToString(),messageInputs];

            return string.Format(localizedMessage, messageInputs);
        }

        public static string GetDisplayName<T>(string propName, string lang)
        {
            if (lang == "en")
                return propName;

            var propertyAttribute = typeof(T).GetMember(propName)[0].GetCustomAttributes(typeof(DisplayNameAttribute), inherit: false);

            if (!propertyAttribute.Any())
                return propName;

            var descriptionAttribute = propertyAttribute[0] as DisplayNameAttribute;

            return descriptionAttribute.DisplayName;
        }

        public static T[] AppendToParams<T>(T first, params T[] items)
        {
            T[] result = new T[items.Length + 1];

            result[0] = first;

            items.CopyTo(result, 1);

            return result;
        }
    }
}
