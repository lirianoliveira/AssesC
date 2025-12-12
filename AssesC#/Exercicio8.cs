using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssesC_
{
    internal class Funcionario
    {


        public string Nome { get; set; }
        public string Cargo { get; set; }
        public decimal SalarioB { get; set; }

        public Funcionario(string nome, string cargo, decimal salarioB)
        {
            Nome = nome;
            Cargo = cargo;
            SalarioB = salarioB;
        }
        public virtual decimal SalarioT
        {
            get { return SalarioB; }
        }


        public void ExibirDados()
        {
            Console.WriteLine($"Nome: {Nome}");
            Console.WriteLine($"Cargo: {Cargo}");
            Console.WriteLine($"Salário: {SalarioB:C}");

            Console.WriteLine($"Salário Total (com bônus) {SalarioT}");


        }
        internal class Gerente : Funcionario
        {
            public Gerente(String nome, decimal SalarioB)
                : base(nome, "Gerente", SalarioB)
            {
            }
            public override decimal SalarioT
            {
                get
                {
                    decimal bonus = SalarioB * 0.20m;
                    return SalarioB + bonus;

                }

            }


            public static void Main(string[] args)
            {
                Funcionario novoF = new Funcionario("Lirian Oliveira", "Auxiliar", 2000.00M);
                novoF.ExibirDados();
                Console.WriteLine("-------------------------------");
                Gerente novoG = new Gerente("Kaio Oliveira", 4000.00M);
                novoG.ExibirDados();
            }
        }
    }
}
