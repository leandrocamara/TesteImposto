using System.Data.Entity;
using System.Data.SqlClient;
using Imposto.Core.NotasFiscais;
using Imposto.Core.NotasFiscais.Interfaces;

namespace Imposto.Infrastructure.Repository.Repositories
{
    public class NotaFiscalRepository : RepositoryBase<NotaFiscal>, INotaFiscalRepository
    {
        public NotaFiscalRepository(DbContext context) : base(context)
        {
        }

        public void Add(NotaFiscal notaFiscal)
        {
            // Save(notaFiscal);
            // Context.SaveChanges();
            Context.Database.ExecuteSqlCommand(ProcedureNotaFiscal, GetParamsProcedureNotaFiscal(notaFiscal));
        }

        private object[] GetParamsProcedureNotaFiscal(NotaFiscal notaFiscal)
        {
            return new object[]
            {
                new SqlParameter("@pId", notaFiscal.Id),
                new SqlParameter("@pNumeroNotaFiscal", notaFiscal.NumeroNotaFiscal),
                new SqlParameter("@pSerie", notaFiscal.Serie),
                new SqlParameter("@pNomeCliente", notaFiscal.NomeCliente),
                new SqlParameter("@pEstadoDestino", notaFiscal.EstadoDestino),
                new SqlParameter("@pEstadoOrigem", notaFiscal.EstadoOrigem)
            };
        }

        private const string ProcedureNotaFiscal = 
            "P_NOTA_FISCAL @pId, @pNumeroNotaFiscal, @pSerie, @pNomeCliente, @pEstadoDestino, @pEstadoOrigem";
    }
}