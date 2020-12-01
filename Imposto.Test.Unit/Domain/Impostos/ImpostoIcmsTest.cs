using Imposto.Core.Impostos;
using Imposto.Core.NotasFiscais;
using Imposto.Core.Pedidos;
using Imposto.Core.ValueObjects;
using Imposto.Test.Unit.Domain.NotasFiscais;
using Xunit;

namespace Imposto.Test.Unit.Domain.Impostos
{
    public class ImpostoIcmsTest
    {
        [Fact]
        public void CalcularIcms_PedidoItemBrinde_TipoAliquotaDefinidosBrinde()
        {
            // Arrange
            var pedido = NotaFiscalTest.NovoPedido();
            pedido.EstadoOrigem = "SP";
            pedido.EstadoDestino = "RJ";

            var novoPedidoItem = new PedidoItem
                {Brinde = true, CodigoProduto = "123", NomeProduto = "X", ValorItemPedido = 1000};

            var notaFiscal = NotaFiscal.New(pedido);
            var cfop = new Cfop(notaFiscal.EstadoOrigem, notaFiscal.EstadoDestino).Value();

            // Act
            var icms = new ImpostoIcms(notaFiscal, novoPedidoItem, cfop);

            // Assert
            Assert.NotNull(icms);
            Assert.Equal("60", icms.Tipo);
            Assert.Equal(0.18, icms.Aliquota);
            Assert.Equal(1000 * 0.18, icms.Valor);
        }

        [Fact]
        public void CalcularIcms_PedidoItemNaoBrinde_TipoAliquotaNaoDefinidosBrinde()
        {
            // Arrange
            var pedido = NotaFiscalTest.NovoPedido();
            pedido.EstadoOrigem = "SP";
            pedido.EstadoDestino = "RJ";

            var novoPedidoItem = new PedidoItem
                {Brinde = false, CodigoProduto = "123", NomeProduto = "X", ValorItemPedido = 1000};

            var notaFiscal = NotaFiscal.New(pedido);
            var cfop = new Cfop(notaFiscal.EstadoOrigem, notaFiscal.EstadoDestino).Value();

            // Act
            var icms = new ImpostoIcms(notaFiscal, novoPedidoItem, cfop);

            // Assert
            Assert.NotNull(icms);
            Assert.Equal("10", icms.Tipo);
            Assert.Equal(0.17, icms.Aliquota);
            Assert.Equal(1000 * 0.17, icms.Valor);
        }

        [Fact]
        public void CalcularIcms_Cfop6009_ReducaoBaseAplicada()
        {
            // Arrange
            var pedido = NotaFiscalTest.NovoPedido();
            pedido.EstadoOrigem = "SP";
            pedido.EstadoDestino = "SE";

            var novoPedidoItem = new PedidoItem
                {Brinde = false, CodigoProduto = "123", NomeProduto = "X", ValorItemPedido = 1000};

            var notaFiscal = NotaFiscal.New(pedido);
            var cfop = new Cfop(notaFiscal.EstadoOrigem, notaFiscal.EstadoDestino).Value(); // 6.009

            // Act
            var icms = new ImpostoIcms(notaFiscal, novoPedidoItem, cfop);

            // Assert
            Assert.NotNull(icms);
            Assert.Equal("10", icms.Tipo);
            Assert.Equal(0.17, icms.Aliquota);
            Assert.Equal(1000 * 0.17 * 0.9, icms.Valor);
        }
    }
}