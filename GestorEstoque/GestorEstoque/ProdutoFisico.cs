﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorEstoque
{
    [System.Serializable]
    class ProdutoFisico : Produto, IEstoque
    {
        public float frete;
        private int estoque;

        public ProdutoFisico(string nome, float preco, float frete)
        {
            this.nome = nome;
            this.preco = preco;
            this.frete = frete;
        }

        public void AdicionarEntrada()
        {
            Console.WriteLine($"Adicionar entrada no estoque do produto: {nome}");
            Console.WriteLine("Digite a quantidade a dar entrada:");
            int entrada = int.Parse(Console.ReadLine());
            estoque += entrada;
            Console.WriteLine("Entrada registrada");
            Console.ReadLine();
        }

        public void AdicionarSaida()
        {
            Console.WriteLine($"Adicionar saida no estoque do produto: {nome}");
            Console.WriteLine("Digite a quantidade a dar saída:");
            int saida = int.Parse(Console.ReadLine());
            if ((estoque - saida) >= 0)
            {
                estoque -= saida;
                Console.WriteLine("Saída registrada");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("A quantidade digitada é maior que o número disponivel em estoque!");
                Console.ReadLine();
            }
           

        }

        public void Exibir()
        {
            Console.WriteLine($"Nome: {nome}");
            Console.WriteLine($"Frete: {frete}");
            Console.WriteLine($"Preço: {preco}");
            Console.WriteLine($"Estoque: {estoque}");
            Console.WriteLine("===========================");

        }
    }
}
