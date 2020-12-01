using Imposto.Core.Pedidos;

namespace Imposto.Core.NotasFiscais.Interfaces
{
    public interface INotaFiscalService
    {
        void GerarNotaFiscal(Pedido pedido);
    }
}