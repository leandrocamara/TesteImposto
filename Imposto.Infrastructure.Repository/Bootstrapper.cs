using Imposto.Core.NotasFiscais.Interfaces;
using Imposto.Infrastructure.Repository.Repositories;
using SimpleInjector;

namespace Imposto.Infrastructure.Repository
{
    public static class Bootstrapper
    {
        public static void AddBootstrapperRepository(Container container)
        {
            container.Register<INotaFiscalRepository, NotaFiscalRepository>();
        }
    }
}