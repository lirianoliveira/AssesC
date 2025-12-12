    using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace AssessmentC_
{
    internal class Exercicio2
    {
       

        public static string Cifrador (string texto,int i)
        {
            string normTexto = texto.Normalize(NormalizationForm.FormD);
            StringBuilder resultado = new StringBuilder ();
            foreach (char c in normTexto) {

                if (CharUnicodeInfo.GetUnicodeCategory(c) == UnicodeCategory.NonSpacingMark)
                {
                    continue;
                }

                if (char.IsLetter(c))
                {
                    char verificacao = char.IsUpper (c) ? 'A' : 'a';

                    int lAlfabeto= c;

                    int iAlfabeto = lAlfabeto - verificacao;

                    int Inovo = (iAlfabeto + i ) % 26;

                    char novaLetra = (char)(verificacao + Inovo);
                    
                    resultado.Append (novaLetra);
                } else
                {
                    resultado.Append (c);
                }
               
            }
            return resultado.ToString();
        }

        public class Exercicio
        {
            public static void Main(string[] args)
            {
                string nome = "Carlos Silva";

                Console.WriteLine ("Entrada: "+nome);

                string nomeCifra = Cifrador(nome, 2);
                Console.WriteLine("Saida: " + nomeCifra);

            }

        }
    }
}
