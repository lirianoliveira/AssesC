using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssesC_
{
    internal class Exercicio4
    {
        private static DateTime CalcularData(DateTime aniversario)
        {
            DateTime dataHoje = DateTime.Today;
            int dia = aniversario.Day;
            int mes = aniversario.Month;
            int ano = aniversario.Year;

            DateTime proxAniversario;

            try
            {
                proxAniversario = new DateTime(ano, mes, dia);
            }
            catch (ArgumentOutOfRangeException)
            {

                if (mes == 2 && dia == 29 && !DateTime.IsLeapYear(ano))
                {
                    ano++;
                }
                try
                {
                    proxAniversario = new DateTime(ano, mes, dia);
                }
                catch (ArgumentOutOfRangeException)
                {
                    int anoC = dataHoje.Year;
                    if (mes < dataHoje.Month || (mes == dataHoje.Month && dia <= dataHoje.Day))
                    {
                        anoC++;
                    }
                    while (true)
                    {
                        if (DateTime.IsLeapYear(anoC) && mes == 2 && dia == 29)
                        {
                            proxAniversario = new DateTime(anoC, mes, dia);
                            break;

                        }
                        else if (mes != 2 || dia != 29)
                        {
                            proxAniversario = new DateTime(anoC, mes, dia);
                            break;
                        }
                        anoC++;
                    }

                }

            }
            if (proxAniversario < dataHoje)
            {
                try
                {
                    proxAniversario = new DateTime(dataHoje.Year + 1, mes, dia);

                }
                catch (ArgumentOutOfRangeException)
                {
                    proxAniversario = new DateTime(dataHoje.Year + 1, 3, 1);
                }
            }
            return proxAniversario;
        }

        private static DateTime LerData()
        {
      
             DateTime dataNascimento;
             bool entrada;

            do
            {
                Console.WriteLine("Digite sua data de Nascimento DD/MM/AAAA: ");
                entrada = DateTime.TryParse(Console.ReadLine(), out dataNascimento);
                if (!entrada || dataNascimento > DateTime.Today)
                {
                    Console.WriteLine("Data inválida");
                    entrada = false;
                }

            } while (!entrada);
             return dataNascimento;
      
        }
        private static void  DiasFaltantes(int diasFaltantes, DateTime proxAni)
        {
            if (diasFaltantes == 0) {
                Console.WriteLine("Parabéns, hoje é seu aniversário!!");
            } else if (diasFaltantes > 0 && diasFaltantes <= 7)
            {
                Console.WriteLine($"Faltam {diasFaltantes} dias para seu aniversário");
            }
            else if (diasFaltantes > 0)
            {
                Console.WriteLine($"Seu próximo aniversário será em: {proxAni.ToShortDateString()}, faltam {diasFaltantes} dias, para seu aniversário.");
            } else
            {
                Console.WriteLine("Verifique se sua data de nascimento está correta");
            }
        }


        public static void Main(string[] args)
        {
            Console.WriteLine("Calcular próximo aniversário");
            DateTime dataNasci = LerData();
            DateTime proxiAni = CalcularData(dataNasci);

            TimeSpan inter = proxiAni.Subtract(DateTime.Today);
                int faltaDias = (int)inter.TotalDays;

            DiasFaltantes(faltaDias, proxiAni);
            Console.ReadKey();
        }
          
        
    }

}
