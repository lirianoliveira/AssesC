using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssesC_
{
    internal class ContaBanco

    {
        public string Titular { get; set; }
        public decimal Saldo = 0m;

        public void Depositar(decimal valor)
        {
            if( valor <= 0 )
            {
                Console.WriteLine("O valor do depósito deve ser positivo!");
                return;
            }
            Saldo += valor;
            Console.WriteLine($"O depósito no valor de {valor:C}, foi realizado com suceso!");
            return;


        }

        public void Sacar (decimal Valor)
        {
            Console.WriteLine($"Tentativa de saque de {Valor}");
            if (Valor > Saldo)
            {
                Console.WriteLine("Saldo insuficiente para realizar o saque!");
                return;

            }
            if (Valor <=0 )
            {
                Console.WriteLine("O valor do saque deve ser positivo!");
                return;
            }

            Saldo -= Valor;
            Console.WriteLine($"Saque no valor de {Valor:C} realizado com sucesso!");
        }
        public void exibirSaldo()
        {
            Console.WriteLine($"O saldo atual é de: {Saldo:C}");
        }
        public static void Main(string[] args)
        {
            ContaBanco conta = new ContaBanco
            {
                Titular = "Lirian Oliveira"
            };
            Console.WriteLine($"Titular:{conta.Titular} ");


            //Depósito
            conta.Depositar(200.00m);
            conta.exibirSaldo();
            Console.WriteLine("----------");
            //Saque
            conta.Sacar(50.00m);
            conta.exibirSaldo();
            Console.WriteLine("----------");
            //Saque Inválido
            conta.Sacar(360.00m);
            conta.exibirSaldo();
            Console.WriteLine("----------");
            //Depósito inválido
            conta.Depositar(-50.00m);
            conta.exibirSaldo();





        }
    }
}