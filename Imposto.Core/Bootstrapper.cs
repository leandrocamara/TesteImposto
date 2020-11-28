using Imposto.Core.NotasFiscais;
using Imposto.Core.NotasFiscais.Interfaces;
using SimpleInjector;

namespace Imposto.Core
{
    public static class Bootstrapper
    {
        public static void AddBootstrapperDomain(Container container)
        {
            container.Register<INotaFiscalService, NotaFiscalService>();
        }
    }
}