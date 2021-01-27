using System;
using System.Collections.Generic;

namespace PorExtenso.Domain
{
    public partial class Dezena : IValor
    {
        private readonly IComplemento _dezena;

        public Dezena(int numerico)
        {
            Numerico = numerico;

            _dezena = numerico switch
            {
                int n when (n % 10) == 0 => new DezenasRedondas(),
                int n when n < 20 => new DezenasIniciais(),
                int n when n > 20 => new DezenasFinais(),
                _ => throw new NotImplementedException()
            };
        }

        public string Extenso => _dezena.ObterComplemento(Numerico);

        public int Numerico { get; }
    }

    internal class DezenasIniciais : IComplemento
    {
        public string ObterComplemento(int numero)
           => new Dictionary<int, string>
           {
                {11,"onze" },
                {12,"doze" },
                {13,"treze" },
                {14,"quatorze" },
                {15,"quinze" },
                {16,"dezesseis" },
                {17,"dezessete" },
                {18,"dezoito" },
                {19,"dezenove" },
           }[numero];
    }

    internal class DezenasRedondas : IComplemento
    {
        public string ObterComplemento(int numero)
           => new Dictionary<int, string>
           {
                {10,"dez" },
                {20,"vinte" },
                {30,"trinta" },
                {40,"quarenta" },
                {50,"cinquenta" },
                {60,"sessetenta" },
                {80,"oitenta" },
                {90,"noventa" }
           }[numero];
    }

    internal class DezenasFinais : IComplemento
    {
        public string ObterComplemento(int numero)
        {
            int dezena = (numero / 10) * 10;
            int unidade = numero - dezena;

            var dezenaExtenso = new DezenasRedondas().ObterComplemento(dezena);
            var unidadeExtenso = new Unidade(unidade).Extenso;

            return $"{dezenaExtenso} e {unidadeExtenso}";
        }
    }
}