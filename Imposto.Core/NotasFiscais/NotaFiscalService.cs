using Imposto.Core.NotasFiscais.Interfaces;
using Imposto.Core.Pedidos;
using Imposto.Core.Services;

namespace Imposto.Core.NotasFiscais
{
    public class NotaFiscalService : INotaFiscalService
    {
        private readonly INotaFiscalRepository _repository;
        private readonly ITemplateService _templateService;

        public NotaFiscalService(INotaFiscalRepository repository, ITemplateService templateService)
        {
            _repository = repository;
            _templateService = templateService;
        }

        public void GerarNotaFiscal(Pedido pedido)
        {
            var notaFiscal = NotaFiscal.New(pedido);

            _templateService.GenerateXml(notaFiscal, notaFiscal.Serie.ToString());

            _repository.Add(notaFiscal);
        }
    }
}