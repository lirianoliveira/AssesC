using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssesC_
{
    internal class Aluno
    {
        public string Nome {  get; set; }
        public int Matricula { get; set; }
        public string Curso { get; set; }
        public double MediaNotas { get; set; }


        public void ExibirInfo ()
        {
            Console.WriteLine("Dados Aluno");
            Console.WriteLine($"Nome: {Nome}");
            Console.WriteLine($"Matricula: {Matricula}");
            Console.WriteLine($"Curso: {Curso}");
            Console.WriteLine($"Situação: {VerificarApr()}");
        }

        public  string VerificarApr()
        {
            if (MediaNotas >= 7)
            {
                return "Aprovado!";
            } else
            {
                return "Reprovado!";
                
            }

        }
        public static void Main(string[] args)
        {
            Aluno novoAluno = new Aluno
            {
                Nome = "Lirian Oliveira",
                Matricula = 1234,
                Curso = "ADS", 
                MediaNotas = 9
            };
            novoAluno.ExibirInfo();
            Console.WriteLine("------------------------");

            Aluno novoAluno2 = new Aluno
            {
                Nome = "Osvaldo Melo",
                Matricula = 124,
                Curso = "ADS",
                MediaNotas = 5
            };

            novoAluno2.ExibirInfo();

            Console.ReadKey();
        }
    }
}
