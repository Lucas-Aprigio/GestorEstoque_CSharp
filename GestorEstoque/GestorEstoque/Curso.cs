using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GestorEstoque
{
    [System.Serializable]
    class Curso: Produto, IEstoque
    {
        public string autor;
        private int vagas;

        public Curso(string nome, float preco, string autor)
        {
            this.nome= nome;
            this.preco = preco;
            this.autor = autor;
            
        }

        public void AdicionarEntrada()
        {
            Console.WriteLine($"Adicionar número de vagas do curso: {nome}");
            Console.WriteLine("Digite a quantidade de vagas a dar entrada: ");
            int entrada = int.Parse(Console.ReadLine());
            vagas += entrada;
            Console.WriteLine("Entrada registrada");
            Console.ReadLine();

        }

        public void AdicionarSaida()
        {
            Console.WriteLine($"Adicionar saida na quantidade de vagas do curso: {nome}");
            Console.WriteLine("Digite a quantidade a dar saída:");
            int saida = int.Parse(Console.ReadLine());
            if ((vagas - saida) >= 0)
            {
                vagas -= saida;
                Console.WriteLine("Saída registrada");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("A quantidade digitada é maior que o número de vagas disponíveis!");
                Console.ReadLine();
            }

        }

        public void Exibir()
        {
            Console.WriteLine($"Nome: {nome}");
            Console.WriteLine($"Autor: {autor}");
            Console.WriteLine($"Preço: {preco}");
            Console.WriteLine($"Vagas restantes: {vagas}");
            Console.WriteLine("===========================");
            
        }
    }
}
