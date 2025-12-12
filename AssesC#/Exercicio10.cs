using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssesC_
{
    internal class Exercicio10
    {
        public class jogo 
        {
            public static void Main(string[] args) { 
                Random random = new Random();
                int numero  = random.Next(1, 51);

                const int tentativas = 5;
                int chute = 0;
                Console.WriteLine(numero); // validação do número correto
                Console.WriteLine("Jogo de Adivinhação (1 a 50)");
                Console.WriteLine($"Você tem {tentativas} tentativas");

                int contador;

                for (contador = 0; contador < tentativas; contador++) {
                    Console.WriteLine($"Tentativa {contador + 1} de {tentativas}");
                    Console.WriteLine("Informe um número de 1 a 50 e boa sorte!");
                    string entrada = Console.ReadLine();

                    if(!int.TryParse(entrada, out chute) || chute <1 || chute > 50)
                    {
                        Console.WriteLine("Entrada inválida,  ou não está no intervalo de 1 a 50");
                        contador--;
                        continue;
                    }
                    if (chute == numero)
                    {
                        break;

                    }
                    else if (chute < numero) {
                        Console.WriteLine("O número é maior");
                    } else
                    {
                        Console.WriteLine("O número é menor");
                    }


                }
                if (chute == numero)
                {
                    Console.WriteLine($"Parabéns! Você acertou, o número é o {numero}");

                }
                else
                {
                    Console.WriteLine($"Você esgotou suas tentivas, o número secreto era o {numero}");
                }
            
                Console.ReadKey();
            }
        }
    }
}
