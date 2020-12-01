using System.Collections.Specialized;

namespace Imposto.Configuration
{
    public class ConfigurationAppSettings
    {
        private readonly NameValueCollection _appSettings;

        public ConfigurationAppSettings(NameValueCollection appSettings)
        {
            _appSettings = appSettings;
        }

        public string GetValue(string key) => _appSettings[key];
    }
}