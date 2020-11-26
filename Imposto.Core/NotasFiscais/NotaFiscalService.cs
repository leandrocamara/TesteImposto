using Imposto.Core.NotasFiscais.Interfaces;
using Imposto.Core.Pedidos;

namespace Imposto.Core.NotasFiscais
{
    public class NotaFiscalService : INotaFiscalService
    {
        private readonly INotaFiscalRepository _repository;
        
        public NotaFiscalService(INotaFiscalRepository repository)
        {
            _repository = repository;
        }

        public void GerarNotaFiscal(Pedido pedido)
        {
            var notaFiscal = new NotaFiscal();
            notaFiscal.EmitirNotaFiscal(pedido);

            _repository.Add(notaFiscal);
        }
    }
}