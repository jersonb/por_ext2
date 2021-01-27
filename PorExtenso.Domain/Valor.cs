using System;

namespace PorExtenso.Domain
{
    public class Valor : IValor
    {
        private readonly IValor _valor;
        private bool Negativo { get; set; }

        public Valor(int numerico)
        {
            if (numerico < 0)
            {
                Negativo = true;
                numerico *= -1;
            }

            Numerico = numerico;

            _valor = numerico switch
            {
                int n when n < 10 => new Unidade(Numerico),
                int n when n < 100 => new Dezena(Numerico),
                int n when n < 1000 => new Centena(Numerico),
                _ => throw new NotImplementedException(),
            };
        }

        public int Numerico { get; }

        public string Extenso => Negativo ? _valor.Extenso + " negativo" : _valor.Extenso;
    }

}