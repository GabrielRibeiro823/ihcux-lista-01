using System;
using System.Collections.Generic;

namespace CantinaConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== SISTEMA DE PEDIDOS - CANTINA UNIVERSITÁRIA ===");
                Console.WriteLine("Comandos disponíveis a qualquer momento: 'voltar' ou 'cancelar'");
                Console.WriteLine();

                int etapa = 1;
                int? codigoProduto = null;
                int? quantidade = null;

                while (etapa <= 3)
                {
                    if (etapa == 1)
                    {
                        Console.WriteLine("[Passo 1 de 3] Seleção de Item");
                        Console.Write("Digite o código do produto (1 a 10): ");
                        string input = Console.ReadLine()?.ToLower();

                        if (input == "cancelar") { etapa = 0; break; }
                        if (input == "voltar") { Console.WriteLine("Você já está na primeira etapa."); continue; }

                        if (int.TryParse(input, out int codigo))
                        {
                            if (codigo >= 1 && codigo <= 10)
                            {
                                codigoProduto = codigo;
                                etapa = 2;
                                Console.WriteLine();
                            }
                            else
                            {
                                Console.WriteLine($"Código {codigo} não encontrado. Nossos códigos vão de 1 a 10. Tente novamente.");
                                Console.WriteLine();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Entrada inválida. Por favor, digite um número correspondente ao código do produto.");
                            Console.WriteLine();
                        }
                    }
                    else if (etapa == 2)
                    {
                        Console.WriteLine("[Passo 2 de 3] Definição de Quantidade");
                        Console.Write($"Produto selecionado: {codigoProduto}. Digite a quantidade desejada: ");
                        string input = Console.ReadLine()?.ToLower();

                        if (input == "cancelar") { etapa = 0; break; }
                        if (input == "voltar") { etapa = 1; Console.Clear(); Console.WriteLine("=== SISTEMA DE PEDIDOS - CANTINA UNIVERSITÁRIA ===\n"); continue; }

                        if (int.TryParse(input, out int qtd) && qtd > 0)
                        {
                            quantidade = qtd;
                            etapa = 3;
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.WriteLine("Quantidade inválida. Por favor, digite um número inteiro maior que zero.");
                            Console.WriteLine();
                        }
                    }
                    else if (etapa == 3)
                    {
                        Console.WriteLine("[Passo 3 de 3] Confirmação do Pedido");
                        Console.WriteLine($"Resumo: {quantidade}x Produto Código {codigoProduto}");
                        Console.Write("Confirmar pedido? (sim/voltar/cancelar): ");
                        string input = Console.ReadLine()?.ToLower();

                        if (input == "sim")
                        {
                            Console.WriteLine("\nPedido realizado com sucesso! Obrigado.");
                            Console.WriteLine("Pressione qualquer tecla para iniciar um novo pedido...");
                            Console.ReadKey();
                            etapa = 4;
                        }
                        else if (input == "voltar")
                        {
                            etapa = 2;
                            Console.Clear();
                            Console.WriteLine("=== SISTEMA DE PEDIDOS - CANTINA UNIVERSITÁRIA ===\n");
                        }
                        else if (input == "cancelar")
                        {
                            etapa = 0;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Opção inválida. Digite 'sim' para finalizar, 'voltar' para corrigir ou 'cancelar' para desistir.");
                            Console.WriteLine();
                        }
                    }
                }

                if (etapa == 0)
                {
                    Console.WriteLine("\nPedido cancelado.");
                    Console.WriteLine("Pressione qualquer tecla para reiniciar...");
                    Console.ReadKey();
                }
            }
        }
    }
}