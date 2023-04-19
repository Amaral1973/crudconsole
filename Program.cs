using static System.Console;
using System;
using System.Collections.Generic;

namespace CShp_Listas
{

    public class Pessoa
    {
        public Pessoa() { }

        public string Nome { get; set; }
        public int Idade { get; set; }
        public Pessoa(int idade, string nome)
        {
            this.Idade = idade;
            this.Nome = nome;
        }
    }

    class Program
    {
        static List<Pessoa> pessoas;

        static void Main(string[] args)
        {
            pessoas = new List<Pessoa>();
            MainMenu();
        }

        private static bool MainMenu()
        {
            Clear();
            Program program = new Program();
            WriteLine("<<<<<< CRUD >>>>>>>");
            WriteLine("Escolha uma opção:");
            WriteLine("1) Adicionar Pessoa");
            WriteLine("2) Localizar Pessoa");
            WriteLine("3) Editar Pessoa");
            WriteLine("4) Excluir Pessoa");
            WriteLine("5) Sair");
            Write("\r\nSelecione uma opção: ");

            switch (ReadLine())
            {
                case "1":
                    Adicionar();
                    return true;
                case "2":
                    Localizar();
                    return true;
                case "3":
                    //Editar();
                    return true;
                case "4":
                    Excluir();
                    return true;
                case "5":
                    Environment.Exit(0);
                    return false;
                default:
                    return true;
            }
        }

        static void Adicionar()
        {
            Clear();
            WriteLine("<<<<<< Adicionar >>>>>>");
            WriteLine("\n");
            WriteLine("Digite o nome da pessoa");
            string nomep = ReadLine();
            WriteLine("Digite a idade da pessoa");
            int idade = Convert.ToInt32(ReadLine());
            pessoas.Add(new Pessoa(idade, nomep));
            ForegroundColor = ConsoleColor.Green;
            WriteLine("Pessoa adicionada com sucesso!!!");
            ResetColor();
            foreach (Pessoa p in pessoas)
            {
                WriteLine(p.Nome + " " + p.Idade);
            }
            WriteLine("\n");
            WriteLine("Deseja voltar ao menu(s/n)?");
            string option = Convert.ToString(ReadLine());
            if (option == "s")
            {
                Clear();
                MainMenu();
            }
        }

        static void Localizar()
        {
            Clear();
            WriteLine("<<<<<< Localizar >>>>>>");
            WriteLine("\n");
            pessoas.ForEach(delegate (Pessoa p)
            {
                WriteLine(String.Format("{0} {1}", p.Nome, p.Idade));
            });
            WriteLine("\n");
            WriteLine("Digite o nome da pessoa que deseja localizar:");
            string nomel = ReadLine();
            List<Pessoa> nome = pessoas.FindAll(delegate (Pessoa p) { return p.Nome == nomel; });
            ForegroundColor = ConsoleColor.Green;
            WriteLine("\nPessoa Encontrada : ");
            ResetColor();
            nome.ForEach(delegate (Pessoa p)
            {
                WriteLine(String.Format("{0} {1}", p.Nome, p.Idade));
            });
            WriteLine("\n");
            WriteLine("Deseja voltar ao menu(s/n)?");
            string option = Convert.ToString(ReadLine());
            if (option == "s")
            {
                Clear();
                MainMenu();
            }
        }

        static void Excluir()
        {
            Clear();
            WriteLine("<<<<<< Excluir >>>>>>");
            WriteLine("\n");
            pessoas.ForEach(delegate (Pessoa p)
            {
                WriteLine(String.Format("{0} {1}", p.Nome, p.Idade));
            });
            WriteLine("\n");
            WriteLine("Digite o nome da pessoa que deseja Excluir:");
            string nomer = ReadLine();
            WriteLine("Digite a idade da pessoa que deseja Excluir:");
            string idader = ReadLine();
            pessoas.Remove(new Pessoa() { Idade = Convert.ToInt32(idader), Nome = nomer });
            WriteLine("\n");
            pessoas.ForEach(delegate (Pessoa p)
            {
                WriteLine(String.Format("{0} {1}", p.Nome, p.Idade));
            });
            WriteLine("Deseja voltar ao menu(s/n)?");
            string option = Convert.ToString(ReadLine());
            if (option == "s")
            {
                Clear();
                MainMenu();
            }
        }

        static void ListaNaoOrdenada()
        {
            Console.WriteLine("\nLista não ordenada");
            pessoas.ForEach(delegate (Pessoa p)
            {
                Console.WriteLine(String.Format("{0} {1}", p.Idade, p.Nome));
            });
        }

        static void ListaOrdenadaPorNome()
        {
            Console.WriteLine("\nLista Ordenada por Nome");
            pessoas.Sort(delegate (Pessoa p1, Pessoa p2)
            {
                return p1.Nome.CompareTo(p2.Nome);
            });
            pessoas.ForEach(delegate (Pessoa p)
            {
                Console.WriteLine(String.Format("{0} {1}", p.Idade, p.Nome));
            });
        }

        static void ListaOrdenadaPorIdade()
        {
            Console.WriteLine("\nLista Ordenada por Idade");
            pessoas.Sort(delegate (Pessoa p1, Pessoa p2)
            {
                return p1.Idade.CompareTo(p2.Idade);
            });
            pessoas.ForEach(delegate (Pessoa p)
            {
                Console.WriteLine(String.Format("{0} {1}", p.Idade, p.Nome));
            });
        }

        static void ListaInserirItemNaPosicao()
        {
            Console.WriteLine("\nInserindo uma pessoa na posição 1 e outra na posição 3");
            pessoas.Insert(1, new Pessoa() { Nome = "Bob Dylan", Idade = 78 });
            pessoas.Insert(3, new Pessoa() { Nome = "Jimmi Page", Idade = 81 });
        }

        static void ListaRemoverItem()
        {
            Console.WriteLine("\nRemovendo objeto Pessoa :  Nome=Macoratti, Idade=45");
            pessoas.Remove(new Pessoa() { Idade = 45, Nome = "Macoratti" });
        }

        static void ListaVerificarSeItemExiste()
        {
            Console.WriteLine("\nExiste na Lista Pessoa com Idade igual a 78 : {0}",
                pessoas.Exists(p => p.Idade == 78));
        }

        static void ListaConverterParaArray()
        {
            Console.WriteLine("\nConvertendo a lista para um Array");
            Pessoa[] ListaArray = pessoas.ToArray();
            foreach (Pessoa p in ListaArray)
            {
                Console.WriteLine(p.Nome + " " + p.Idade);
            }
        }

        static void ListaLocalizaPessoaMaisJovem()
        {
            List<Pessoa> jovem = pessoas.FindAll(delegate (Pessoa p) { return p.Idade < 30; });
            Console.WriteLine("\nIdade é menor que 30 : ");
            jovem.ForEach(delegate (Pessoa p)
            {
                Console.WriteLine(String.Format("{0} {1}", p.Idade, p.Nome));
            });
        }
    }
}
