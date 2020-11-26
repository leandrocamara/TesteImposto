using Imposto.Core.NotasFiscais.Interfaces;
using Imposto.Core.Pedidos;

namespace Imposto.Core.NotasFiscais
{
    public class NotaFiscalService : INotaFiscalService
    {
        public void GerarNotaFiscal(Pedido pedido)
        {
            var notaFiscal = new NotaFiscal();
            notaFiscal.EmitirNotaFiscal(pedido);
        }
    }
}
