using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
        static void Main ()
    {
        List<string> estoque = new List<string>();
        bool rodando = true;

        while (rodando)
        {
            Console.Clear();
            Console.WriteLine("=== SISTEMA DE ESTOQUE ===");
            Console.WriteLine("1 - Adicionar item");
            Console.WriteLine("2 - Remover item");
            Console.WriteLine("3 - Mostrar Estoque");
            Console.WriteLine("4 - Sair");
            Console.Write("Escolha: ");

            string? opcao = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(opcao))
            {
                Console.WriteLine("Opção Inválida!");
            }
            else if (opcao == "1")
            {
                Console.Write("Nome do item: ");
                string? nome = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(nome))
                {
                    Console.WriteLine("Nome inválido!");
                }
                else
                {
                    estoque.Add(nome.ToLower());
                    Console.WriteLine("Item adicionado!");
                }
            }
            else if (opcao == "2")
            {
                Console.Write("Nome do item que deseja remover: ");
                string? nome = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(nome))
                {
                    Console.WriteLine("Nome Inválido!");
                }
                else
                {
                    nome = nome.ToLower();
                    if (estoque.Contains(nome))
                    {
                        estoque.Remove(nome);
                        Console.WriteLine("Item removido!");
                    }
                    else
                    {
                        Console.WriteLine("Item não encontrado!");
                    }
                }
            }
            else if (opcao == "3")
            {
                Console.WriteLine("\n === ESTOQUE ATUAL ===");

                if (estoque.Count == 0)
                {
                    Console.WriteLine("Estoque vazio!");
                }
                else
                {
                    var agrupado = estoque
                    .GroupBy(i => i)
                    .Select(g => new { Nome = g.Key, quantidade = g.Count() });

                    foreach (var item in agrupado)
                        Console.WriteLine($"{item.quantidade}{item.Nome}");
                }
            }
            else if (opcao == "4")
            {
                rodando = false;
            }
            else
            {
                Console.WriteLine("Opção Inválida!");
            }

            Console.WriteLine("\nPressione uma tecla para continuar...");
            Console.ReadKey();
        }
    }
}