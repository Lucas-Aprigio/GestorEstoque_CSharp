using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace GestorEstoque
{
    class Program
    {
        static List<IEstoque>produtos = new List<IEstoque>();
        enum Menu { Listar=1, Adicionar, Remover, Entrada, Saida, Sair}
        static void Main(string[] args)
        {
            Carregar();
            bool continua = true;
            while (continua)
            {
                Console.WriteLine("Sistema de estoque");
                Console.WriteLine("1-Lista\n2-Adicionar\n3-Remover\n4-Registrar entrada\n5-Registrar saida\n6-Sair");
                int opcao= int.Parse(Console.ReadLine());
                Menu escolha = (Menu)opcao;

                if (opcao > 0 && opcao < 7)
                {
                    switch (escolha)
                    {
                        case Menu.Listar:
                            Listagem();
                            break;

                        case Menu.Adicionar:
                            Cadastro();
                            break;

                        case Menu.Remover:
                            Remover();
                            break;

                        case Menu.Entrada:
                            Entrada();
                            break;

                        case Menu.Saida:
                            Saida();
                            break;

                        case Menu.Sair:
                            continua = false;
                            break;

                    }

                }
                else
                {
                    continua = false;
                }
                Console.Clear();

            }

        }

        static void Listagem()
        {
            Console.WriteLine("Lista de produtos");
            int i = 0;
            foreach(IEstoque produto in produtos)
            {
                Console.WriteLine("ID: " + i);
                produto.Exibir();
                i++;

            }
            Console.ReadLine();
        }

        static void Remover()
        {
            Listagem();
            Console.WriteLine("Digite o ID do elemento que você quer dar entrada: ");
            int id = int.Parse(Console.ReadLine());
            if (id >= 0 && id < produtos.Count)
            {
                produtos.RemoveAt(id);
                Salvar();
            }
        }

        static void Entrada()
        {
            Listagem();
            Console.WriteLine("Digite o ID do elemento que você quer dar entrada: ");
            int id = int.Parse(Console.ReadLine());
            if (id >= 0 && id < produtos.Count)
            {
                produtos[id].AdicionarEntrada();
                Salvar();
            }

        }

        static void Saida()
        {
            Listagem();
            Console.WriteLine("Digite o ID do elemento que você quer registrar saída: ");
            int id = int.Parse(Console.ReadLine());
            if (id >= 0 && id < produtos.Count)
            {
                produtos[id].AdicionarSaida();
                Salvar();
            }

        }


        static void Cadastro()
        {
            Console.WriteLine("Cadastro de Produtos");
            Console.WriteLine("1-Produto Fisico\n2-Ebook\n3-Curso");
            int opcao = int.Parse(Console.ReadLine());
            switch (opcao)
            {
                case 1:
                    CadastrarPFisico();
                    break;

                case 2:
                    CadastrarEbook();
                    break;

                case 3:
                    CadastrarCurso();
                    break;
            }
        }

        static void CadastrarPFisico()
        {
            Console.WriteLine("Cadastrando produto fisico: ");
            Console.WriteLine("Digite o nome:");
            string nome= Console.ReadLine();
            Console.WriteLine("Digite o preco: ");
            float preco = float.Parse(Console.ReadLine());
            Console.WriteLine("Digite o frete: ");
            float frete = float.Parse(Console.ReadLine());
            ProdutoFisico pf= new ProdutoFisico(nome, preco, frete);
            produtos.Add(pf);
            Salvar();
        }

        static void CadastrarEbook()
        {
            Console.WriteLine("Cadastrando Ebook: ");
            Console.WriteLine("Digite o nome:");
            string nome = Console.ReadLine();
            Console.WriteLine("Digite o preco: ");
            float preco = float.Parse(Console.ReadLine());
            Console.WriteLine("Autor: ");
            string autor = Console.ReadLine();
            Ebook eb = new Ebook(nome, preco, autor);
            produtos.Add(eb);
            Salvar();

        }
        static void CadastrarCurso()
        {
            Console.WriteLine("Cadastrando Curso: ");
            Console.WriteLine("Digite o nome:");
            string nome = Console.ReadLine();
            Console.WriteLine("Digite o preco: ");
            float preco = float.Parse(Console.ReadLine());
            Console.WriteLine("Autor: ");
            string autor = Console.ReadLine();
            Curso cs = new Curso(nome, preco, autor);
            produtos.Add(cs);
            Salvar();
        }

        static void Salvar()
        {
            FileStream stream = new FileStream("produtos.dat", FileMode.OpenOrCreate);
            BinaryFormatter encoder = new BinaryFormatter();

            encoder.Serialize(stream, produtos);

            stream.Close();
        }
        static void Carregar()
        {
            FileStream stream = new FileStream("produtos.dat", FileMode.OpenOrCreate);
            BinaryFormatter encoder = new BinaryFormatter();

            try
            {
                produtos = (List<IEstoque>)encoder.Deserialize(stream);
                if(produtos == null)
                {
                    produtos=new List<IEstoque>();  
                }
            }
            catch(Exception ex)
            {
                produtos = new List<IEstoque>();
            }

            stream.Close();
            

        }
    }
}
