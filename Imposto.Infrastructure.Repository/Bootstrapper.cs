using System.Data.Entity;
using Imposto.Core.NotasFiscais.Interfaces;
using Imposto.Infrastructure.Repository.Context;
using Imposto.Infrastructure.Repository.Repositories;
using SimpleInjector;

namespace Imposto.Infrastructure.Repository
{
    public static class Bootstrapper
    {
        public static void AddBootstrapperRepository(Container container)
        {
            container.Register<DbContext, ImpostoDbContext>(Lifestyle.Singleton);
            container.Register<INotaFiscalRepository, NotaFiscalRepository>();
        }
    }
}