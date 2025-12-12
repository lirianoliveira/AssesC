using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AssesC_
{
    internal class Exercicio5
    {
        private static readonly DateTime dataFormatura = new DateTime(2026, 02, 15);
        private static DateTime LerData()
        {

            DateTime dataAtual;
            bool entrada;

            do
            {
                Console.WriteLine("Digite sua data atual DD/MM/AAAA: ");
                entrada = DateTime.TryParse(Console.ReadLine(), out dataAtual);
                if (!entrada)
                {
                    Console.WriteLine("Data inválida");
                    entrada = false;

                }
                else if (dataAtual > DateTime.Today)
                {
                        Console.WriteLine("Erro: A data informada não pode ser no futuro!");
                    entrada = false;
                }

            } while (!entrada);
            return dataAtual;

        }
        private static (int anos, int meses, int Dias) CalcularData(DateTime dataInicio, DateTime dataFinal)
        {
            int anos = dataFinal.Year - dataInicio.Year;
            int meses = dataFinal.Month - dataInicio.Month;
            int dias =  dataFinal.Day - dataInicio.Day;
            if (dias < 0) {
                meses--;
                int diasMesAnt = DateTime.DaysInMonth(dataFinal.Year, (dataFinal.Month == 1) ? 12 : dataFinal.Month - 1);
                dias += diasMesAnt;
            }
            if (meses < 0) {
                anos--;
                meses += 12;
            }
            if (anos < 0) return (0, 0, 0);
            return (anos, meses, dias);


        }
        private static void ExibirDataFormatura(DateTime dataAtual)
        {
            if (dataAtual > dataFormatura)
            {
                Console.WriteLine("Parabéns! Você já deveria estar formado!");
                return;
            }
            var diferenca = CalcularData(dataAtual, dataFormatura);
            int anos = diferenca.anos;
            int meses = diferenca.meses;
            int dias = diferenca.Dias;
            int mesesT = anos * 12 + meses;
       

            if(mesesT < 6)
            {

                Console.WriteLine($"Faltam apenas {meses} mese(s), {dias} dias(s), para sua fomatura.\nA reta final chegou! Prepare-se para a formatura!");
            } else
            {
                Console.WriteLine($"Faltam {anos} ano(s), {meses} mese(s), {dias} dia(s), para sua fomatura.");
            }

        }
        public static void Main(string[] args)
        {
            Console.WriteLine("Calculadora de tempo até a formatura");
            Console.WriteLine($"Sua data de formatura é: {dataFormatura.ToShortDateString()}");

            DateTime dataAtual = LerData();
            ExibirDataFormatura(dataAtual);
            Console.ReadKey();


        }
    }
}
