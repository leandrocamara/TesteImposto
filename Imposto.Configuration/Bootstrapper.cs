using System.Collections.Specialized;
using SimpleInjector;

namespace Imposto.Configuration
{
    public static class Bootstrapper
    {
        public static void AddBootstrapperConfiguration(Container container, NameValueCollection appSettings)
        {
            container.RegisterInstance(new ConfigurationAppSettings(appSettings));
        }
    }
}