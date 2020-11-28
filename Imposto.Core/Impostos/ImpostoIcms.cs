using Imposto.Core.NotasFiscais;
using Imposto.Core.Pedidos;

namespace Imposto.Core.Impostos
{
    public class ImpostoIcms : Imposto
    {
        public string Tipo { get; set; }

        public ImpostoIcms(NotaFiscal notaFiscal, PedidoItem pedidoItem, string cfop) : base(notaFiscal, pedidoItem)
        {
            DefinirAliquota();
            AplicarReducaoBase(cfop);
            CalcularValor();
        }

        private void DefinirAliquota()
        {
            if (PedidoItem.Brinde)
            {
                Tipo = "60";
                Aliquota = 0.18;
            }
            else
            {
                Tipo = NotaFiscal.EstadoDestino == NotaFiscal.EstadoOrigem ? "60" : "10";
                Aliquota = NotaFiscal.EstadoDestino == NotaFiscal.EstadoOrigem ? 0.18 : 0.17;
            }
        }

        private void AplicarReducaoBase(string cfop)
        {
            if (cfop.Equals("6.009"))
                Base *= 0.90; // Redução de base
        }
    }
}