using System;
using System.Xml.Serialization;
using Imposto.Core.Impostos;
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
        public double BaseIpi { get; set; }
        public double AliquotaIpi { get; set; }
        public double ValorIpi { get; set; }
        public string NomeProduto { get; set; }
        public string CodigoProduto { get; set; }

        [XmlIgnore] public NotaFiscal NotaFiscal { get; set; }

        public static NotaFiscalItem New(NotaFiscal notaFiscal, PedidoItem pedidoItem)
        {
            var cfop = new Cfop(notaFiscal.EstadoOrigem, notaFiscal.EstadoDestino).Value();
            var icms = new ImpostoIcms(notaFiscal, pedidoItem, cfop);
            var ipi = new ImpostoIpi(notaFiscal, pedidoItem);

            var notaFiscalItem = new NotaFiscalItem
            {
                NotaFiscal = notaFiscal,
                NomeProduto = pedidoItem.NomeProduto,
                CodigoProduto = pedidoItem.CodigoProduto,
                Cfop = cfop,
                TipoIcms = icms.Tipo,
                BaseIcms = icms.Base,
                AliquotaIcms = icms.Aliquota,
                ValorIcms = icms.Valor,
                BaseIpi = ipi.Base,
                AliquotaIpi = ipi.Aliquota,
                ValorIpi = ipi.Valor
            };

            notaFiscalItem.Validate();

            return notaFiscalItem;
        }

        private void Validate()
        {
            if (NotaFiscal == null)
                throw new Exception("É obrigatório vincular o Item à uma Nota Fiscal");
            
            if (string.IsNullOrEmpty(NomeProduto))
                throw new Exception("O Nome do Produto é obrigatório");

            if (string.IsNullOrEmpty(CodigoProduto))
                throw new Exception("O Código do Produto é obrigatório");
        }

        private NotaFiscalItem()
        {
        }
    }
}