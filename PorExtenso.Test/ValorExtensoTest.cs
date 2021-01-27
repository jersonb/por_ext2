using PorExtenso.Domain;
using Xunit;

namespace PorExtenso.Test
{
    public class ValorExtensoTest
    {
        [Theory]
        [InlineData(0, "zero")]
        [InlineData(1, "um")]
        [InlineData(2, "dois")]
        [InlineData(3, "três")]
        [InlineData(4, "quatro")]
        [InlineData(5, "cinco")]
        [InlineData(6, "seis")]
        [InlineData(7, "sete")]
        [InlineData(8, "oito")]
        [InlineData(9, "nove")]
        public void UnidadeTest(int numero, string esperado)
        {
            IValor valor = new Unidade(numero);
            Assert.Equal(esperado, valor.Extenso);
        }

        [Theory]
        [InlineData(10, "dez")]
        [InlineData(19, "dezenove")]
        [InlineData(20, "vinte")]
        [InlineData(21, "vinte e um")]
        [InlineData(29, "vinte e nove")]
        [InlineData(35, "trinta e cinco")]
        [InlineData(99, "noventa e nove")]
        public void DezenasTest(int numero, string esperado)
        {
            IValor valor = new Dezena(numero);
            Assert.Equal(esperado, valor.Extenso);
        }

        [Theory]
        [InlineData(100, "cem")]
        [InlineData(101, "cento e um")]
        [InlineData(220, "duzentos e vinte")]
        [InlineData(999, "novecentos e noventa e nove")]
        public void CentenasTest(int numero, string esperado)
        {
            IValor valor = new Centena(numero);
            Assert.Equal(esperado, valor.Extenso);
        }

        [Theory]
        [InlineData(0, "zero")]
        [InlineData(1, "um")]
        [InlineData(2, "dois")]
        [InlineData(3, "três")]
        [InlineData(29, "vinte e nove")]
        [InlineData(35, "trinta e cinco")]
        [InlineData(99, "noventa e nove")]
        [InlineData(101, "cento e um")]
        [InlineData(220, "duzentos e vinte")]
        [InlineData(-220, "duzentos e vinte negativo")]
        public void ValorTest(int numero, string esperado)
        {
            IValor valor = new Valor(numero);
            Assert.Equal(esperado, valor.Extenso);
        }
    }
}