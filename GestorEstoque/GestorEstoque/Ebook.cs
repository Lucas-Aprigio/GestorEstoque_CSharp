using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GestorEstoque
{
    [System.Serializable]
    class Ebook: Produto, IEstoque
    {
        public string autor;
        private int vendas;

        public Ebook(string nome, float preco, string autor)
        {
            this.nome = nome;
            this.preco = preco;
            this.autor = autor;
        }

        public void AdicionarEntrada()
        {
            Console.WriteLine($"Não é possível dar entrada no estoque de um e-book!");
            Console.ReadLine();
        }

        public void AdicionarSaida()
        {
            Console.WriteLine($"Digite a quantidade de vendas: ");
            int qtd =int.Parse(Console.ReadLine());
            vendas += qtd;
            Console.WriteLine("Número de vendas registrado!");
            Console.ReadLine();

        }

        public void Exibir()
        {
            Console.WriteLine($"Nome: {nome}");
            Console.WriteLine($"Autor: {autor}");
            Console.WriteLine($"Preço: {preco}");
            Console.WriteLine($"Numero de vendas: {vendas}");
            Console.WriteLine("===========================");

        }
    }
}
