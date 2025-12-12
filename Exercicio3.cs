using System;
using System.Collections.Generic;
using System.Text;

namespace AssessmentC_
{
    internal class Exercicio3
    {
        private static double Calculo(double a, double b, int operacao) { 
            
            switch (operacao){

                case 1: 
                return a + b;
                    case 2:
                    return a - b;
                    case 3:
                    return a * b;
                    case 4: 
              

                    if (b == 0) {
                        throw new DivideByZeroException("Não é possivel dividir por zero");
                    }
                    return a / b;

}
        
 
        }
        public static void Main(string[] args) {
            double n1, n2;
            int operacao;


            Console.WriteLine("Informe o primeiro número: ");
            if (double.TryParse(Console.ReadLine(), out n1))
            {
                console.WriteLine("O número informado é inválido, tente novamente");
                return;
            }
            Console.WriteLine("Informe o segundo número: ");
            if (double.TryParse(Console.ReadLine(), out n2))
            {
                console.WriteLine("O número informado é inválido, tente novamente");
                return;
            }

            Console.WriteLine("Informe o número da operação desejada: ");
            Console.WriteLine("1 - Soma \n 2 - Subtração \n 3 - Multiplicação \n 4 - Divisão");
            if (!int.TryParse(Console.ReadLine(), out operacao ||  operacao <1) {
                console.WriteLine("A operação escolhida é inválida, tente novamente");
                return;
            }

            try
            {
                double resultado = Calculo(n1, n2, operacao);

                Console.WriteLine("Resultado: " + resultado);

            }
            catch {

                Console.WriteLine("Erro, operação inválida");
            }
         

          

        }

    }

}
