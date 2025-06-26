using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Localization;
using Newtonsoft.Json;
using VuexyBase.Application.Common.Helpers;

namespace VuexyBase.Application.Services.Localization
{
    public class LocalizationService : IStringLocalizer
    {
        private List<JsonLocalization> localization = new List<JsonLocalization>();
        private string currentCultureName;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LocalizationService(IHostEnvironment hostEnvironment, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;

            string rootProject = hostEnvironment.ContentRootPath;
            string applicationProjectRoot = Path.GetFullPath(Path.Combine(rootProject, "..", "VuexyBase.Application"));
            string filePath = Path.Combine(applicationProjectRoot, "Application", "Services", "Localization", "localization.json");

            if (File.Exists(filePath))
            {
                localization = JsonConvert.DeserializeObject<List<JsonLocalization>>(File.ReadAllText(filePath)) ?? new List<JsonLocalization>();
            }
            else
            {
                // Log the missing file error if needed
                throw new FileNotFoundException($"Localization file not found at: {filePath}");
            }
        }

        public LocalizedString this[string name]
        {
            get
            {
                var value = GetString(name);
                return new LocalizedString(name, value ?? name, resourceNotFound: value == null);
            }
        }

        public LocalizedString this[string name, params object[] arguments]
        {
            get
            {
                var format = GetString(name);
                var value = string.Format(format ?? name, arguments);
                return new LocalizedString(name, value, resourceNotFound: format == null);
            }
        }

        public IEnumerable<LocalizedString> GetAllStrings(bool includeParentCultures)
        {
            var culture = GetCurrentCulture();
            return localization
                .Where(l => l.LocalizedValue.ContainsKey(culture))
                .Select(l => new LocalizedString(l.Key, l.LocalizedValue[culture], resourceNotFound: false));
        }

        private string GetString(string name)
        {
            var culture = GetCurrentCulture();

            var localizedItem = localization.FirstOrDefault(l => l.Key == name && l.LocalizedValue.ContainsKey(culture));
            return localizedItem?.LocalizedValue[culture] ?? name; // Fallback to name if not found
        }

        private string GetCurrentCulture()
        {
            var culture = _httpContextAccessor?.HttpContext?
                .Features.Get<IRequestCultureFeature>()?
                .RequestCulture.UICulture.TwoLetterISOLanguageName;

            return string.IsNullOrEmpty(culture) ? "ar" : culture;
        }
    }

    public class JsonLocalization
    {
        public string Key { get; set; }
        public Dictionary<string, string> LocalizedValue { get; set; } = new Dictionary<string, string>();
    }

    
}
