using System.Collections.Specialized;
using SimpleInjector;

namespace Imposto.IoC
{
    public static class Bootstrapper
    {
        public static void AddBootstrapperIoC(Container container, NameValueCollection appSettings)
        {
            Core.Bootstrapper.AddBootstrapperDomain(container);
            Infrastructure.Template.Bootstrapper.AddBootstrapperTemplate(container);
            Infrastructure.Repository.Bootstrapper.AddBootstrapperRepository(container);
            Configuration.Bootstrapper.AddBootstrapperConfiguration(container, appSettings);
        }
    }
}