﻿using DLL_Regras;
using System;

public class MenuAdmin
{
    private Regras regras;

    public MenuAdmin()
    {
        regras = new Regras();
    }

    public void MostrarMenuA()
    {
        Console.Clear();
        Console.WriteLine("===== Gestão de Alojamentos Turísticos =====");
        Console.WriteLine();
        Console.WriteLine("Escolha uma categoria:");
        Console.WriteLine();
        Console.WriteLine("1. CLIENTES");
        Console.WriteLine("2. FUNCIONÁRIOS");
        Console.WriteLine("3. ALOJAMENTOS");
        Console.WriteLine("4. QUARTOS");
        Console.WriteLine();
        Console.WriteLine("0. Sair");
        Console.WriteLine();
        Console.Write("Opção: ");

        int opcaoCategoria = int.Parse(Console.ReadLine());
        Console.Clear(); // Limpa a tela antes de exibir o resultado da opção escolhida

        switch (opcaoCategoria)
        {
            case 1:
                Console.WriteLine("===== Gestão de Clientes =====");
                Console.WriteLine();
                Console.WriteLine("1. Inserir Cliente");
                Console.WriteLine("2. Listar Clientes");
                Console.WriteLine("0. Voltar");
                Console.WriteLine();
                Console.Write("Opção: ");

                int opcaoCliente = int.Parse(Console.ReadLine());

                Console.Clear();

                switch (opcaoCliente)
                {
                    case 1:
                        Console.WriteLine("===== Inserir Cliente =====");
                        Console.WriteLine();
                        regras.InserirCliente();
                        break;
                    case 2:
                        Console.WriteLine("===== Listar Clientes =====");
                        Console.WriteLine();
                        regras.ListarClientes();
                        break;
                    case 0:

                        break;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }

                break;
            case 2:
                Console.WriteLine("===== Gestão de Funcionários =====");
                Console.WriteLine();
                Console.WriteLine("1. Inserir Funcionário");
                Console.WriteLine("2. Listar Funcionários");
                Console.WriteLine("0. Voltar");
                Console.WriteLine();
                Console.Write("Opção: ");

                int opcaoFuncionario = int.Parse(Console.ReadLine());

                Console.Clear();

                switch (opcaoFuncionario)
                {
                    case 1:
                        Console.WriteLine("===== Inserir Funcionário =====");
                        Console.WriteLine();
                        regras.InserirFunc();
                        break;
                    case 2:
                        Console.WriteLine("===== Listar Funcionários =====");
                        Console.WriteLine();
                        regras.ListarFunc();
                        break;
                    case 0:

                        break;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }

                break;
            case 3:
                Console.WriteLine("===== Gestão de Alojamentos =====");
                Console.WriteLine();
                Console.WriteLine("1. Inserir Alojamento");
                Console.WriteLine("2. Listar Alojamentos");
                Console.WriteLine("0. Voltar");
                Console.WriteLine();
                Console.Write("Opção: ");

                int opcaoAlojamento = int.Parse(Console.ReadLine());

                Console.Clear();

                switch (opcaoAlojamento)
                {
                    case 1:
                        Console.WriteLine("===== Inserir Alojamento =====");
                        Console.WriteLine();
                        regras.InserirAlojamento();
                        break;
                    case 2:
                        Console.WriteLine("===== Listar Alojamentos =====");
                        Console.WriteLine();
                        regras.ListarAlojamentos();
                        break;
                    case 0:

                        break;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }

                break;
            case 4:
                Console.WriteLine("===== Gestão de Quartos =====");
                Console.WriteLine();
                Console.WriteLine("1. Inserir Quarto");
                Console.WriteLine("2. Listar Quartos");
                Console.WriteLine("0. Voltar");
                Console.WriteLine();
                Console.Write("Opção: ");

                int opcaoQuarto = int.Parse(Console.ReadLine());

                Console.Clear();

                switch (opcaoQuarto)
                {
                    case 1:
                        Console.WriteLine("===== Inserir Quarto =====");
                        Console.WriteLine();
                        regras.InserirQuarto();
                        break;
                    case 2:
                        Console.WriteLine("===== Listar Quartos =====");
                        Console.WriteLine();
                        regras.ListarQuartos();
                        break;
                    case 0:

                        break;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }

                break;
            case 0:
                Console.WriteLine("A sair do programa!");
                break;
            default:
                Console.WriteLine("Opção inválida. Tente novamente.");
                break;
        }

        if (opcaoCategoria != 0)
        {
            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
            MostrarMenuA();
        }
    }
}