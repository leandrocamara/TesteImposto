using SimpleInjector;

namespace Imposto.Infrastructure.Template
{
    public static class Bootstrapper
    {
        public static void AddBootstrapperTemplate(Container container)
        {
            container.Register<TemplateService>(Lifestyle.Singleton);
        }
    }
}