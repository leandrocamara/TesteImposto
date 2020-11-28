using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
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
            AddProcedures(notaFiscal);
        }

        private void AddProcedures(NotaFiscal notaFiscal)
        {
            Context.Database.ExecuteSqlCommand(ProcedureNotaFiscal, GetParamsProcedureNotaFiscal(notaFiscal));

            var ultimaNotaFiscal = EntitySet.OrderBy(nf => nf.Id).ToList().Last();

            foreach (var notaFiscalItem in notaFiscal.ItensNotaFiscal)
            {
                Context.Database.ExecuteSqlCommand(
                    ProcedureNotaFiscalItem, GetParamsProcedureNotaFiscalItem(ultimaNotaFiscal.Id, notaFiscalItem));
            }
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

        private object[] GetParamsProcedureNotaFiscalItem(int notaFiscalId, NotaFiscalItem notaFiscalItem)
        {
            return new object[]
            {
                new SqlParameter("@pId", notaFiscalItem.Id),
                new SqlParameter("@pIdNotaFiscal", notaFiscalId),
                new SqlParameter("@pCfop", notaFiscalItem.Cfop),
                new SqlParameter("@pTipoIcms", notaFiscalItem.TipoIcms),
                new SqlParameter("@pBaseIcms", notaFiscalItem.BaseIcms),
                new SqlParameter("@pAliquotaIcms", notaFiscalItem.AliquotaIcms),
                new SqlParameter("@pValorIcms", notaFiscalItem.ValorIcms),
                new SqlParameter("@pNomeProduto", notaFiscalItem.NomeProduto),
                new SqlParameter("@pCodigoProduto", notaFiscalItem.CodigoProduto)
            };
        }

        private const string ProcedureNotaFiscal =
            "P_NOTA_FISCAL @pId, @pNumeroNotaFiscal, @pSerie, @pNomeCliente, @pEstadoDestino, @pEstadoOrigem";

        private const string ProcedureNotaFiscalItem =
            "P_NOTA_FISCAL_ITEM @pId, @pIdNotaFiscal, @pCfop, @pTipoIcms, @pBaseIcms, @pAliquotaIcms, @pValorIcms, @pNomeProduto, @pCodigoProduto";
    }
}