using Imposto.Core.ValueObjects;
using Xunit;

namespace Imposto.Test.Unit.Domain.ValueObjects
{
    public class CfopTest
    {
        [Fact]
        public void CriarCfop_EstadosOrigemDestinoValidos_CfopCriado()
        {
            // Arrange
            const string estadoOrigem = "MG";
            const string estadoDestino = "RJ";

            // Act
            var cfop = new Cfop(estadoOrigem, estadoDestino);

            // Assert
            Assert.NotNull(cfop);
            Assert.Equal("6.000", cfop.Value());
        }

        [Fact]
        public void CriarCfop_EstadosOrigemDestinoNaoContemplados_CfopNaoCriado()
        {
            // Arrange
            const string estadoOrigem = "GO";
            const string estadoDestino = "AM";

            // Act
            var cfop = new Cfop(estadoOrigem, estadoDestino);

            // Assert
            Assert.NotNull(cfop);
            Assert.Empty(cfop.Value());
        }

        [Fact]
        public void CriarCfop_EstadoOrigemSpEstadoDestinoRo_Cfop6006()
        {
            // Arrange
            const string estadoOrigem = "SP";
            const string estadoDestino = "RO";

            // Act
            var cfop = new Cfop(estadoOrigem, estadoDestino);

            // Assert
            Assert.NotNull(cfop);
            Assert.Equal("6.006", cfop.Value());
        }
    }
}