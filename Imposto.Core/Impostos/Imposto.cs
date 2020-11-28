using Imposto.Core.NotasFiscais;
using Imposto.Core.Pedidos;

namespace Imposto.Core.Impostos
{
    public abstract class Imposto
    {
        public double Base { get; protected set; }
        public double Aliquota { get; protected set; }
        public double Valor { get; protected set; }

        protected NotaFiscal NotaFiscal { get; }
        protected PedidoItem PedidoItem { get; }

        protected Imposto(NotaFiscal notaFiscal, PedidoItem pedidoItem)
        {
            NotaFiscal = notaFiscal;
            PedidoItem = pedidoItem;
            Base = PedidoItem.ValorItemPedido;
        }

        protected void CalcularValor()
        {
            Valor = Base * Aliquota;
        }
    }
}