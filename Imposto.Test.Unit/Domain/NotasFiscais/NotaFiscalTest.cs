using System.Collections.Generic;
using Imposto.Core.NotasFiscais;
using Imposto.Core.Pedidos;
using Xunit;

namespace Imposto.Test.Unit.Domain.NotasFiscais
{
    public class NotaFiscalTest
    {
        [Fact]
        public void GerarNotaFiscal_PedidoValido_NotaFiscalGerada()
        {
            // Arrange
            var pedidoItem = new PedidoItem
            {
                Brinde = true,
                CodigoProduto = "123",
                NomeProduto = "NomeProduto",
                ValorItemPedido = 100
            };

            var pedido = new Pedido
            {
                EstadoDestino = "SP",
                EstadoOrigem = "MG",
                NomeCliente = "NomeCliente",
                ItensDoPedido = new List<PedidoItem> {pedidoItem}
            };

            // Act
            var notaFiscal = NotaFiscal.New(pedido);

            // Assert
            Assert.NotNull(notaFiscal);
            Assert.NotEmpty(notaFiscal.ItensNotaFiscal);
        }

        [Fact]
        public void GerarNotaFiscal_PedidoVazio_ExcecaoCamposObrigatorios()
        {
            // Arrange
            var pedido = new Pedido();

            // Act
            var exception = Record.Exception(() => NotaFiscal.New(pedido));

            // Assert
            Assert.NotNull(exception);
        }

        public static Pedido NovoPedido()
        {
            var pedidoItem = new PedidoItem
            {
                Brinde = false,
                CodigoProduto = "123",
                NomeProduto = "NomeProduto",
                ValorItemPedido = 0
            };

            return new Pedido
            {
                EstadoDestino = "",
                EstadoOrigem = "",
                NomeCliente = "NomeCliente",
                ItensDoPedido = new List<PedidoItem> {pedidoItem}
            };
        }
    }
}