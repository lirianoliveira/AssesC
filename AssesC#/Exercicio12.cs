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

    public class Contato
    {
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }

        public override string ToString()
        {
            return $"{Nome},{Telefone},{Email}";
        }
        public static Contato FromString(string linha)
        {
            string[] partes = linha.Split(",");
            if (partes.Length >= 3) {
                return new Contato
                {
                    Nome = partes[0],
                    Telefone = partes[1],
                    Email = partes[2]
                };

            }
            return null;
        }

    }

    public abstract class ContatoFormatter
    {
        public abstract void ExibirContatos(List<Contato> contatos);
    }
    public class TabelaFormatter : ContatoFormatter
    {
        public override void ExibirContatos(List<Contato> contatos)
        {
            Console.WriteLine("lista de contatos (Tabela)");
            int aNome = 20, aTelefone = 18, aEmail = 30;
            int laguraT = aNome + aTelefone + aEmail +9;

            string linhasA = new string('-',laguraT);
            Console.WriteLine(linhasA);
            Console.WriteLine($"| {("Nome").PadRight(aNome)} | {("Telefone").PadRight(aTelefone)} | {("E-mail").PadRight(aEmail)} |");
            Console.WriteLine(linhasA);

            foreach (var c in contatos)
            {
                Console.WriteLine($"| {c.Nome.PadRight(aNome)} | {c.Telefone.PadRight(aTelefone)} | {c.Email.PadRight(aEmail)} |");
            }

            Console.WriteLine(linhasA);
        }
    }

    public class MakdownFormatter : ContatoFormatter {
        public override void ExibirContatos(List<Contato> contatos)
        {
            Console.WriteLine("## Lista de Contatos");
            foreach (var c in contatos)
            {
                Console.WriteLine($"**Nome**: {c.Nome}");
                Console.WriteLine($"📞 Telefone: {c.Telefone}");
                Console.WriteLine($"📧 E-mail: {c.Email}");

            }
        }
    }


    public class RawTextFormatter : ContatoFormatter
    {
        public override void ExibirContatos(List<Contato> contatos)
        {
            Console.WriteLine("Contatos (RawTextFormatter)");
            foreach (var c in contatos)
            {
                Console.WriteLine($"{c.Nome} | {c.Telefone} | {c.Email}");
            }
        }
    }



    internal class Exercicio12
    {
        private const string NomeA = "contatos.txt";



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

            public static List<Contato> CarregarLista(){
           
            List<Contato>contatos = new List<Contato>();

            if (!File.Exists(NomeA))
            {
                return contatos;
            }
            try
            {
                string[] linhas = File.ReadAllLines(NomeA);
               

                foreach (string linha in linhas)
                {
                    if (string.IsNullOrWhiteSpace(linha)) continue;
                    string[] partes = linha.Split(",");
                    if (partes.Length>=3)
                    {
                       
                        contatos.Add(new Contato
                        {
                            Nome = partes[0],
                            Telefone = partes[1],
                            Email = partes[2],
                        });
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
            return contatos;
               
            }
        
        public static void Menu()
        {
            int opc;
            do
            {
                Console.WriteLine("Agenda de contantos");
                Console.WriteLine("\n1- Adicionar novo contato \n2- Listar contantos cadastrados \n3- Sair");
                Console.Write("Escolha um opção: ");
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
                        Console.WriteLine("Escolha o formato de exibição: ");
                        Console.WriteLine("1- Tabela");
                        Console.WriteLine("2- Markdown");
                        Console.WriteLine("3- RawTextFormatte");
                        Console.WriteLine("Escolh uma opção:");
                        string escolha = Console.ReadLine();
                        ContatoFormatter formatter;
                        if(escolha == "1")
                            formatter = new TabelaFormatter();
                        else if (escolha == "2")
                            formatter = new MakdownFormatter();
                        else 
                            formatter = new RawTextFormatter();

                        List<Contato> contatos = CarregarLista();
                        formatter.ExibirContatos(contatos);

                        break;

                    case 3:
                        Console.WriteLine("Programa encerrado..");
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
            Menu();
        }


       

    }
}
