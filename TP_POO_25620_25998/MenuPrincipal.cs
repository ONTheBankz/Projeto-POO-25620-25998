using DLL_Regras;
using System;

public class MenuPrincipal
{
    // Instância da classe Regras
    private Regras regras;

    public MenuPrincipal()
    {
        // Inicializa a instância da classe Regras
        regras = new Regras();
    }

    // Método para mostrar o menu principal
    public void MostrarMenuP()
    {
        // Limpa o ecrã e mostra o menu principal
        Console.Clear();
        Console.WriteLine("===== Gestão de Alojamentos Turísticos =====");
        Console.WriteLine();
        Console.WriteLine("Escolha um tipo de conta:");
        Console.WriteLine();
        Console.WriteLine("1. CLIENTE");
        Console.WriteLine("2. ADMIN");
        Console.WriteLine("3. FUNCIONÁRIO");
        Console.WriteLine("0. Sair");
        Console.WriteLine();
        Console.Write("Opção: ");

        // Obtém a opção da categoria escolhida pelo utilizador
        if (int.TryParse(Console.ReadLine(), out int opcaoCategoria))
        {
            Console.Clear(); // Limpa o ecrã antes de mostrar o resultado da opção escolhida

            // Estrutura switch para lidar com as opções escolhidas pelo utilizador
            switch (opcaoCategoria)
            {
                case 1: // Opção Cliente
                    Console.WriteLine("===== Login Cliente =====");
                    Console.WriteLine();
                    // Verifica se o login do cliente é bem-sucedido
                    if (regras.LoginCliente())
                    {
                        // Autenticação bem-sucedida, mostra o menu do cliente
                        MenuCliente mc = new MenuCliente();
                        mc.MostrarMenuC();
                    }
                    break;

                case 2: // Opção Admin
                    Console.WriteLine("===== Login Admin =====");
                    Console.WriteLine();
                    // Verifica se o login do admin é bem-sucedido
                    if (regras.LoginAdmin())
                    {
                        // Autenticação bem-sucedida, mostra o menu do admin
                        MenuAdmin ma = new MenuAdmin();
                        ma.MostrarMenuA();
                    }
                    break;

                case 3: // Opção Funcionário
                    Console.WriteLine("===== Login Funcionário =====");
                    Console.WriteLine();
                    // Verifica se o login do funcionário é bem-sucedido
                    if (regras.LoginFunc())
                    {
                        // Autenticação bem-sucedida, mostra o menu do funcionário
                        MenuFunc mf = new MenuFunc();
                        mf.MostrarMenuF();
                    }
                    break;

                case 0: // Opção Sair
                    Console.WriteLine("A sair do programa!");
                    break;

                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }
        else
        {
            Console.WriteLine("Opção inválida. Tente novamente.");
        }
    }
}
