using System.Collections.Generic;
using System.Linq;
using Imposto.Core.NotasFiscais;
using Imposto.Core.Pedidos;
using Xunit;

namespace Imposto.Test.Unit.Domain.NotasFiscais
{
    public class NotaFiscalItemTest
    {
        [Fact]
        public void CriarNotaFiscalItem_EstadoDestinoNaoSudeste_NaoAplicarDesconto()
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
                EstadoDestino = "GO", // Centro-Oeste
                EstadoOrigem = "RJ",
                NomeCliente = "NomeCliente",
                ItensDoPedido = new List<PedidoItem> {pedidoItem}
            };

            // Act
            var notaFiscal = NotaFiscal.New(pedido);
            
            // Assert
            var notaFiscalItem = notaFiscal.ItensNotaFiscal.Last();
            Assert.NotNull(notaFiscalItem);
            Assert.Equal(0, notaFiscalItem.Desconto);
        }

        [Fact]
        public void CriarNotaFiscalItem_EstadoDestinoSudeste_AplicarDesconto()
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
                EstadoDestino = "MG", // Sudeste
                EstadoOrigem = "RJ",
                NomeCliente = "NomeCliente",
                ItensDoPedido = new List<PedidoItem> {pedidoItem}
            };

            // Act
            var notaFiscal = NotaFiscal.New(pedido);
            
            // Assert
            var notaFiscalItem = notaFiscal.ItensNotaFiscal.Last();
            Assert.NotNull(notaFiscalItem);
            Assert.Equal(0.10, notaFiscalItem.Desconto);
        }

        [Fact]
        public void CriarNotaFiscalItem_PedidoItemVazio_ExcecaoCamposObrigatorios()
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
                EstadoDestino = "MG",
                EstadoOrigem = "RJ",
                NomeCliente = "NomeCliente",
                ItensDoPedido = new List<PedidoItem> {pedidoItem}
            };

            var notaFiscal = NotaFiscal.New(pedido);

            // Act
            var exception = Record.Exception(() => NotaFiscalItem.New(notaFiscal, new PedidoItem()));

            // Assert
            Assert.NotNull(exception);
        }
    }
}