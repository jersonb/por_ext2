using System.Collections.Generic;

namespace PorExtenso.Domain
{
    public class Centena : IValor
    {
        private readonly IComplemento _centena;

        public Centena(int numerico)
        {
            Numerico = numerico;

            if ((numerico % 100) == 0)
            {
                _centena = new CentenaRedonda();
            }
            else
            {
                _centena = new CentenaQuebrada();
            }
        }

        public int Numerico { get; }

        public string Extenso => _centena.ObterComplemento(Numerico);
    }

    internal class CentenaRedonda : IComplemento
    {
        public string ObterComplemento(int numero)
            => new Dictionary<int, string>
            {
                { 100, "cem"},
                { 200, "duzentos"},
                { 300, "trezentos"},
                { 400, "quatrocentos"},
                { 500, "quinhentos"},
                { 600, "seiscentos"},
                { 700, "setecentos"},
                { 800, "oitocentos"},
                { 900, "novecentos"},
            }[numero];
    }

    internal class CentenaQuebrada : IComplemento
    {
        public string ObterComplemento(int numero)
        {
            int centena = (numero / 100) * 100;
            int resto = numero - centena;

            var extenso = new CentenaRedonda().ObterComplemento(centena);
            
            if (centena == 100)
            {
                extenso = "cento";
            }

            if (resto < 10)
            {
                var unidade = new Unidade(resto);
                extenso += $" e {unidade.Extenso}";
            }
            else
            {
                var dezena = new Dezena(resto);
                extenso += $" e {dezena.Extenso}";
            }
            return extenso;
        }
    }
}