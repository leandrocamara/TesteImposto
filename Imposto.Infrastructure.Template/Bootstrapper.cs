using Imposto.Core.Services;
using SimpleInjector;

namespace Imposto.Infrastructure.Template
{
    public static class Bootstrapper
    {
        public static void AddBootstrapperTemplate(Container container)
        {
            container.Register<ITemplateService, TemplateService>();
        }
    }
}