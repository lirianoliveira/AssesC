using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AssesC_
{
    internal class Exercicio11
    {
        private const string NomeA = "contantos.txt";



        public static void adicionarContato()
        {
            Console.WriteLine("Adicionar novo contato");
            Console.Write("Nome: ");
            string nome = Console.ReadLine();
            Console.Write("Telefone: ");
            string telefone = Console.ReadLine();
            Console.Write("E-mail: ");
            string email = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(nome) || string.IsNullOrWhiteSpace(telefone))
            {
                Console.WriteLine("Nome e Telefone são obrigatórios, contanto não cadastrado");
                return;

            }
            string NovoContato = $"{nome},{telefone},{email}";
            try
            {
                using (StreamWriter writer = File.AppendText(NomeA))
                {
                    writer.WriteLine(NovoContato);

                }
                Console.WriteLine("Contato adicionado com sucesso.");

            } catch
            {
                Console.WriteLine("Erro ao salvar contato");
            } 
        }

            public static void listaContatos(){
            Console.WriteLine("Contatos cadastrados: ");

            if (!File.Exists(NomeA))
            {
                Console.WriteLine("Nenhum contato cadastrado.");
            }
            try
            {
                string[] linhas = File.ReadAllLines(NomeA);
                if (linhas.Length == 0)
                {
                    Console.WriteLine("Nenhum contato cadastrado.");
                    return;
                }
                Console.WriteLine($"Total de Contatos: {linhas.Length}");

                foreach (string linha in linhas)
                {
                    if (string.IsNullOrWhiteSpace(linha)) continue;
                    string[] partes = linha.Split(",");
                    if (partes.Length>=3)
                    {
                        Console.WriteLine($"Nome: {partes[0],-20} | Telefone: {partes[1],-18} | E-mail: {partes[2]}");
                    } else
                    {
                        Console.WriteLine("Formato incorreto");
                    }
                }
            }
            catch
            {
                Console.WriteLine("Erro ao ler arquivo");
            }
               
            }
        
        public static void Menu()
        {
            int opc;
            do
            {
                Console.WriteLine("Agenda de contantos");
                Console.WriteLine("\n1- Adicionar novo contato \n2- Listar contantos cadastrados \n3- Sair");
                Console.Write("Escolhar um opção: ");
                if (!int.TryParse(Console.ReadLine(), out opc))
                {
                    opc = 0;
                }
                switch (opc)
                {
                    case 1:
                        adicionarContato();
                        break;
                    case 2:
                        listaContatos();
                        break;
                    case 3:
                        Console.WriteLine("Programa encerrado..");
                        break;
                    default:
                        Console.WriteLine("Opção inválida, tente novamente");
                        break;
                }

            } while (opc != 3); {
              
            }
            Console.ReadKey();
        }

        public static void Main(string[] args)
        {
            Menu();
        }



       

    }
}
