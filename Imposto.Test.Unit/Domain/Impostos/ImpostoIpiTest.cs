using Imposto.Core.Impostos;
using Imposto.Core.NotasFiscais;
using Imposto.Core.Pedidos;
using Imposto.Test.Unit.Domain.NotasFiscais;
using Xunit;

namespace Imposto.Test.Unit.Domain.Impostos
{
    public class ImpostoIpiTest
    {
        [Fact]
        public void CalcularIpi_PedidoItemBrinde_AliquotaDefinidosBrinde()
        {
            // Arrange
            var pedido = NotaFiscalTest.NovoPedido();
            pedido.EstadoOrigem = "SP";
            pedido.EstadoDestino = "RJ";

            var novoPedidoItem = new PedidoItem
                {Brinde = true, CodigoProduto = "123", NomeProduto = "X", ValorItemPedido = 1000};

            var notaFiscal = NotaFiscal.New(pedido);

            // Act
            var ipi = new ImpostoIpi(notaFiscal, novoPedidoItem);

            // Assert
            Assert.NotNull(ipi);
            Assert.Equal(0, ipi.Aliquota);
            Assert.Equal(0, ipi.Valor);
        }

        [Fact]
        public void CalcularIpi_PedidoItemNaoBrinde_AliquotaDefinidosNaoBrinde()
        {
            // Arrange
            var pedido = NotaFiscalTest.NovoPedido();
            pedido.EstadoOrigem = "SP";
            pedido.EstadoDestino = "RJ";

            var novoPedidoItem = new PedidoItem
                {Brinde = false, CodigoProduto = "123", NomeProduto = "X", ValorItemPedido = 1000};

            var notaFiscal = NotaFiscal.New(pedido);

            // Act
            var ipi = new ImpostoIpi(notaFiscal, novoPedidoItem);

            // Assert
            Assert.NotNull(ipi);
            Assert.Equal(0.10, ipi.Aliquota);
            Assert.Equal(1000 * 0.10, ipi.Valor);
        }
    }
}