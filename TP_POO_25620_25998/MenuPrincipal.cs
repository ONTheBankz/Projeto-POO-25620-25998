using DLL_Regras;
using System;

public class MenuPrincipal
{
    private Regras regras;

    public MenuPrincipal()
    {
        regras = new Regras();
    }
    public void MostrarMenuP()
    {
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

        int opcaoCategoria = int.Parse(Console.ReadLine());
        Console.Clear(); // Limpa a tela antes de exibir o resultado da opção escolhida

        switch (opcaoCategoria)
        {
            case 1:
                Console.WriteLine("===== Login Cliente  =====");
                Console.WriteLine();
                if (regras.LoginCliente())
                {
                    // Autenticação bem-sucedida, mostra o menu
                    MenuCliente mc = new MenuCliente();
                    mc.MostrarMenuC();
                }
                break;

            case 2:
                Console.WriteLine("===== Login Admin =====");
                Console.WriteLine();
                if (regras.LoginAdmin())
                {
                    // Autenticação bem-sucedida, mostra o menu do funcionário
                    MenuAdmin ma = new MenuAdmin();
                    ma.MostrarMenuA();
                }
                break;

            case 3:
                Console.WriteLine("===== Login Funcionário  =====");
                Console.WriteLine();
                if (regras.LoginFunc())
                {
                    // Autenticação bem-sucedida, mostra o menu
                    MenuFunc mf = new MenuFunc();
                    mf.MostrarMenuF();
                }
                break;
        
            case 0:
                Console.WriteLine("A sair do programa!");
                break;

            default:
                Console.WriteLine("Opção inválida. Tente novamente.");
                break;
        }

    }
}
