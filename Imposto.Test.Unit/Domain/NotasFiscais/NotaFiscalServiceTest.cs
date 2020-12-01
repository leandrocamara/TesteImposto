using System.Collections.Generic;
using Imposto.Core.NotasFiscais;
using Imposto.Core.NotasFiscais.Interfaces;
using Imposto.Core.Pedidos;
using Imposto.Core.Services;
using Moq;
using Xunit;

namespace Imposto.Test.Unit.Domain.NotasFiscais
{
    public class NotaFiscalServiceTest
    {
        private readonly NotaFiscalService _notaFiscalService;
        private readonly Mock<INotaFiscalRepository> _repositoryMock;
        private readonly Mock<ITemplateService> _templateServiceMock;

        public NotaFiscalServiceTest()
        {
            _repositoryMock = new Mock<INotaFiscalRepository>();
            _templateServiceMock = new Mock<ITemplateService>();
            _notaFiscalService = new NotaFiscalService(_repositoryMock.Object, _templateServiceMock.Object);
        }

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
            var exception = Record.Exception(() => _notaFiscalService.GerarNotaFiscal(pedido));

            // Assert
            Assert.Null(exception);
        }
    }
}