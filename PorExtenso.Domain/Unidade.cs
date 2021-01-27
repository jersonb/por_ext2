using System.Collections.Generic;

namespace PorExtenso.Domain
{
    public class Unidade : IValor
    {
        public Unidade(int numerico)
        {
            Numerico = numerico;
        }

        public int Numerico { get; }

        public string Extenso => new Dictionary<int, string>
        {
            { 0, "zero" },
            { 1, "um" },
            { 2, "dois" },
            { 3, "três" },
            { 4, "quatro" },
            { 5, "cinco" },
            { 6, "seis" },
            { 7, "sete" },
            { 8, "oito" },
            { 9, "nove" }
        }[Numerico];
    }
}