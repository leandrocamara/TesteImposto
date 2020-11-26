using System;
using Imposto.Core.NotasFiscais;
using Imposto.Core.NotasFiscais.Interfaces;
using Imposto.Infrastructure.Template;

namespace Imposto.Infrastructure.Repository.Repositories
{
    public class NotaFiscalRepository : INotaFiscalRepository
    {
        private readonly TemplateService _templateService;

        public NotaFiscalRepository(TemplateService templateService)
        {
            _templateService = templateService;
        }

        public void Add(NotaFiscal notaFiscal)
        {
            try
            {
                _templateService.GenerateXml(notaFiscal, notaFiscal.Serie.ToString());

                // TODO: Executar as procedures, para persistência dos dados da NotaFiscal e seus Itens.
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}