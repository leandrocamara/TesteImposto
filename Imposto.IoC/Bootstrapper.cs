using SimpleInjector;

namespace Imposto.IoC
{
    public static class Bootstrapper
    {
        public static void AddBootstrapperIoC(Container container)
        {
            Infrastructure.Repository.Bootstrapper.AddBootstrapperRepository(container);
            Core.Bootstrapper.AddBootstrapperDomain(container);
        }
    }
}