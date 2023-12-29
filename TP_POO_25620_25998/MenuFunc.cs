using DLL_Exceptions;
using DLL_Regras;
using System;

public class MenuFunc
{
    private Regras regras;

    public MenuFunc()
    {
        regras = new Regras();
    }

    public void MostrarMenuF()
    {
        Console.Clear();
        Console.WriteLine("===== Gestão de Alojamentos Turísticos =====");
        Console.WriteLine();
        Console.WriteLine("Escolha uma categoria:");
        Console.WriteLine();
        Console.WriteLine("1. CHECK_IN");
        Console.WriteLine("2. CHECK_OUT");
        Console.WriteLine("3. QUARTOS");
        Console.WriteLine();
        Console.WriteLine("4. Alterar Dados");
        Console.WriteLine("0. Sair");
        Console.WriteLine();
        Console.Write("Opção: ");

        if (int.TryParse(Console.ReadLine(), out int opcaoCategoria))
        {
            Console.Clear();

            switch (opcaoCategoria)
            {
                case 1:
                    Console.WriteLine("===== Gestão de Check_IN's =====");
                    Console.WriteLine();
                    Console.WriteLine("1. Fazer Check_IN");
                    Console.WriteLine("2. Remover Check_IN");
                    Console.WriteLine("3. Listar Check_IN");
                    Console.WriteLine("0. Voltar");
                    Console.WriteLine();
                    Console.Write("Opção: ");

                    if (int.TryParse(Console.ReadLine(), out int opcaoCheck_I))
                    {
                        Console.Clear();

                        switch (opcaoCheck_I)
                        {
                            case 1:
                                Console.WriteLine("===== Fazer Check_IN =====");
                                Console.WriteLine();
                                try
                                {
                                    regras.InserirCheck_I();
                                }

                                catch (ECheck_In ci)
                                {
                                    Console.WriteLine("Erro" + "-" + ci.Message);
                                }
                                break;
                            case 2:
                                Console.WriteLine("===== Remover Check_IN =====");
                                Console.WriteLine();
                                regras.RemoverCheck_I();
                                break;
                            case 3:
                                Console.WriteLine("===== Listar Check_IN's =====");
                                Console.WriteLine();
                                regras.ListarCheck_I();
                                break;
                            case 0:
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
                    break;

                case 2:
                    Console.WriteLine("===== Gestão de Check_OUT's =====");
                    Console.WriteLine();
                    Console.WriteLine("1. Fazer Check_OUT");
                    Console.WriteLine("2. Remover Check_OUT");
                    Console.WriteLine("3. Listar Check_OUT");
                    Console.WriteLine("0. Voltar");
                    Console.WriteLine();
                    Console.Write("Opção: ");

                    if (int.TryParse(Console.ReadLine(), out int opcaoCheck_O))
                    {
                        Console.Clear();

                        switch (opcaoCheck_O)
                        {
                            case 1:
                                Console.WriteLine("===== Fazer Check_OUT =====");
                                Console.WriteLine();
                                try
                                {
                                    regras.InserirCheck_O();
                                }

                                catch (ECheck_Out co)
                                {
                                    Console.WriteLine("Erro" + "-" + co.Message);
                                }
                                break;
                            case 2:
                                Console.WriteLine("===== Remover Check_OUT =====");
                                Console.WriteLine();
                                regras.RemoverCheck_O();
                                break;
                            case 3:
                                Console.WriteLine("===== Listar Check_OUT's =====");
                                Console.WriteLine();
                                regras.ListarCheck_O();
                                break;
                            case 0:
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
                    break;
                    
                case 3:
                    Console.WriteLine("===== Gestão de Quartos =====");
                    Console.WriteLine();
                    Console.WriteLine("1. Inserir Quarto");
                    Console.WriteLine("2. Listar Quartos");
                    Console.WriteLine("0. Voltar");
                    Console.WriteLine();
                    Console.Write("Opção: ");

                    if (int.TryParse(Console.ReadLine(), out int opcaoQuarto))
                    {
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
                                regras.ListarQuartosF();
                                break;
                            case 0:
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
                    break;

                case 4:
                    Console.WriteLine("===== Alterar Dados =====");
                    Console.WriteLine();
                    //regras.EditarFunc
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
                MostrarMenuF();
            }
        }
        else
        {
            Console.WriteLine("Opção inválida. Tente novamente.");
        }
    }
}
