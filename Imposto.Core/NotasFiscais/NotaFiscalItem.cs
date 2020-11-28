using System.Xml.Serialization;
using Imposto.Core.Pedidos;
using Imposto.Core.ValueObjects;

namespace Imposto.Core.NotasFiscais
{
    public class NotaFiscalItem
    {
        public int Id { get; set; }
        public int IdNotaFiscal { get; set; }
        public string Cfop { get; set; }
        public string TipoIcms { get; set; }
        public double BaseIcms { get; set; }
        public double AliquotaIcms { get; set; }
        public double ValorIcms { get; set; }
        public string NomeProduto { get; set; }
        public string CodigoProduto { get; set; }

        [XmlIgnore]
        public NotaFiscal NotaFiscal { get; set; }

        public static NotaFiscalItem New(NotaFiscal notaFiscal, PedidoItem pedidoItem)
        {
            var notaFiscalItem = new NotaFiscalItem
            {
                NotaFiscal = notaFiscal,
                NomeProduto = pedidoItem.NomeProduto,
                CodigoProduto = pedidoItem.CodigoProduto,
                Cfop = new Cfop(notaFiscal.EstadoOrigem, notaFiscal.EstadoDestino).Value()
            };

            notaFiscalItem.DefinirTipoAliquotaIcms(pedidoItem);
            notaFiscalItem.DefinirBaseIcms(pedidoItem);
            notaFiscalItem.CalcularValorIcms();

            notaFiscalItem.Validate();

            return notaFiscalItem;
        }

        private void DefinirTipoAliquotaIcms(PedidoItem pedidoItem)
        {
            if (pedidoItem.Brinde)
            {
                TipoIcms = "60";
                AliquotaIcms = 0.18;
            }
            else
            {
                TipoIcms = NotaFiscal.EstadoDestino == NotaFiscal.EstadoOrigem ? "60" : "10";
                AliquotaIcms = NotaFiscal.EstadoDestino == NotaFiscal.EstadoOrigem ? 0.18 : 0.17;
            }
        }

        private void DefinirBaseIcms(PedidoItem pedidoItem)
        {
            BaseIcms = pedidoItem.ValorItemPedido;

            if (Cfop == "6.009")
                BaseIcms *= 0.90; // Redução de base
        }

        private void CalcularValorIcms()
        {
            ValorIcms = BaseIcms * AliquotaIcms;
        }

        private void Validate()
        {
            // TODO: Validar propriedades da NotaFiscalItem
        }

        private NotaFiscalItem()
        {
        }
    }
}