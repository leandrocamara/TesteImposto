using System.Collections.Generic;
using Imposto.Core.NotasFiscais;
using Imposto.Core.Pedidos;
using Xunit;

namespace Imposto.Test.Unit.Domain.NotasFiscais
{
    public class NotaFiscalTest
    {
        [Fact]
        public void CreateNotaFiscal_AllValidParams_Success()
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
    }
}