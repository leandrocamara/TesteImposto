using Imposto.Core.ValueObjects;
using Xunit;

namespace Imposto.Test.Unit.Domain.ValueObjects
{
    public class UfTest
    {
        [Fact]
        public void CriarUf_SiglaValida_UfCriada()
        {
            // Arrange
            const string siglaUf = "AM";

            // Act
            var uf = new Uf(siglaUf);

            // Assert
            Assert.NotNull(uf);
            Assert.Equal(siglaUf, uf.Value());
        }

        [Fact]
        public void CriarUf_SiglaInvalida_ExcecaoUfInvalida()
        {
            // Arrange
            const string siglaUf = "ZZ";

            // Act
            var exception = Record.Exception(() => new Uf(siglaUf));

            // Assert
            Assert.NotNull(exception);
            Assert.Equal($"UF inválida! {siglaUf}", exception.Message);
        }

        [Fact]
        public void CriarUf_SiglaValidaSudeste_UfCriada()
        {
            // Arrange
            const string siglaUf = "SP";

            // Act
            var uf = new Uf(siglaUf);

            // Assert
            Assert.NotNull(uf);
            Assert.True(uf.SiglaSudeste());
            Assert.Equal(siglaUf, uf.Value());
        }
    }
}