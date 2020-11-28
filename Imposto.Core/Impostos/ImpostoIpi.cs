using Imposto.Core.NotasFiscais;
using Imposto.Core.Pedidos;

namespace Imposto.Core.Impostos
{
    public class ImpostoIpi : Imposto
    {
        public ImpostoIpi(NotaFiscal notaFiscal, PedidoItem pedidoItem) : base(notaFiscal, pedidoItem)
        {
            DefinirAliquota();
            CalcularValor();
        }

        private void DefinirAliquota()
        {
            Aliquota = PedidoItem.Brinde ? 0 : 0.10;
        }
    }
}