using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AssesC_
{
    internal class Exercicio9
    {
        public class Produto
        {
            public string nome;
            public int quantidade;
            public decimal valor;
        }
        public class Estoque
        {
            private const string NomeA = "estoque.txt";
            private const int limiteProdutos = 5;

            public static void InserirP()
            {
                try
                {
                    int linhasExis = 0;
                    if (File.Exists(NomeA))
                    {
                        linhasExis = File.ReadAllLines(NomeA).Length;

                    }
                    if (linhasExis >= limiteProdutos)
                    {
                        Console.WriteLine("Limite de produtos atingidos");
                        return;
                    }
                } catch { Console.WriteLine("Erro ao checar limite"); }

                Console.WriteLine("Inserir novo produto");
                Produto novoPro = new Produto();

                Console.Write("Nome do produto: ");
                novoPro.nome = Console.ReadLine();

                Console.Write("Quantidade em estoque: ");
                bool validacao = int.TryParse(Console.ReadLine(), out novoPro.quantidade);
                if (!validacao || novoPro.quantidade < 0)
                {
                    Console.WriteLine("Quantidade inválida, não foi possivel cadastrar o produto");
                    return;
                }
                Console.Write("Preço Unitário: R$ ");
                bool validacaoPr = decimal.TryParse(Console.ReadLine(), NumberStyles.Currency, CultureInfo.CurrentCulture, out novoPro.valor);
                if (!validacaoPr || novoPro.valor <= 0)
                {
                    Console.WriteLine("Preço inválido!");
                    return;
                }
                try
                {
                    String linhaProduto = $"{novoPro.nome}, {novoPro.quantidade}, {novoPro.valor.ToString(CultureInfo.InvariantCulture)}";
                    using (StreamWriter save = File.AppendText(NomeA)) {
                        save.WriteLine(linhaProduto);
                    }
                    Console.WriteLine("Produto cadastrado com sucesso!");
                }
                catch {
                    Console.WriteLine("Erro ao salvar produto");
                }







            }
            public static void listaProdutos()


            {
                try
                {
                    string[] linhas = File.ReadAllLines(NomeA);
                    if (linhas.Length == 0)
                    {
                        Console.WriteLine("Nenhum produto cadastrado");
                        return;
                    }


                    foreach (string linha in linhas)
                    {
                        if (string.IsNullOrWhiteSpace(linha)) continue;
                        string[] partes = linha.Split(',');
                        if (partes.Length == 3 && int.TryParse(partes[1], out int quantidade) && decimal.TryParse(partes[2], 
                            NumberStyles.Any, CultureInfo.InvariantCulture, out decimal valor))
                        {
                            string nome = partes[0];
                            Console.WriteLine($"Produto: {nome} | Quantidade: {quantidade} | Preço {valor:C}");
                        }
                        else
                        {
                            Console.WriteLine($"Formato incorreto na linha {linha}!");
                        }
                    }

                }
                catch
                {
                    Console.WriteLine("Erro ao processar");
                    return;
                }
            }




            public static void Menu()
            {
                int opc;
                do
                {
                    Console.WriteLine("Gerencimento de estoque");
                    Console.WriteLine("\n1- Inserir Produto \n2- Listar Produtos \n3- Sair");
                    Console.Write("Escolhe uma opção: ");

                    if (!int.TryParse(Console.ReadLine(), out opc))
                    {
                        opc = 0;
                    }
                    switch (opc)
                    {
                        case 1:
                            Estoque.InserirP();
                            break;
                        case 2:
                            Estoque.listaProdutos();
                            break;
                        case 3:
                            Console.WriteLine("Sistema encerrado!");
                            break;
                        default:
                            Console.WriteLine("Opção inválida, tente novamente");
                            break;


                    }


                } while (opc != 3);
                Console.ReadKey();

            }
            public static void Main(string[] args)
            {
                Estoque.Menu();
            }





        }
    }
}
