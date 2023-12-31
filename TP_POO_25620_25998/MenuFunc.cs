using DLL_Exceptions;
using DLL_Regras;
using System;

public class MenuFunc
{
    // Instância da classe Regras
    private Regras regras;

    public MenuFunc()
    {
        // Inicializa a instância da classe Regras
        regras = new Regras();
    }

    // Método para mostrar o menu do funcionário
    public void MostrarMenuF()
    {
        // Limpa o ecrã e mostra o menu do funcionário
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

        // Obtém a opção da categoria escolhida pelo utilizador
        if (int.TryParse(Console.ReadLine(), out int opcaoCategoria))
        {
            Console.Clear();

            // Estrutura switch para lidar com as opções escolhidas pelo funcionário
            switch (opcaoCategoria)
            {
                case 1: // Opção CHECK_IN
                    Console.WriteLine("===== Gestão de Check_IN's =====");
                    Console.WriteLine();
                    Console.WriteLine("1. Fazer Check_IN");
                    Console.WriteLine("2. Remover Check_IN");
                    Console.WriteLine("3. Listar Check_IN");
                    Console.WriteLine("0. Voltar");
                    Console.WriteLine();
                    Console.Write("Opção: ");

                    // Obtém a opção específica da categoria CHECK_IN
                    if (int.TryParse(Console.ReadLine(), out int opcaoCheck_I))
                    {
                        Console.Clear();

                        // Estrutura switch para lidar com as opções relacionadas ao CHECK_IN
                        switch (opcaoCheck_I)
                        {
                            case 1: // Opção Fazer Check_IN
                                Console.WriteLine("===== Fazer Check_IN =====");
                                Console.WriteLine();
                                try
                                {
                                    // Chama o método para o funcionário fazer um CHECK_IN
                                    regras.InserirCheck_I();
                                }
                                catch (ECheck_In ci)
                                {
                                    // Trata exceção relacionada a CHECK_IN
                                    Console.WriteLine("Erro" + "-" + ci.Message);
                                }
                                break;

                            case 2: // Opção Remover Check_IN
                                Console.WriteLine("===== Remover Check_IN =====");
                                Console.WriteLine();
                                // Chama o método para o funcionário remover um CHECK_IN
                                regras.RemoverCheck_I();
                                break;

                            case 3: // Opção Listar Check_IN
                                Console.WriteLine("===== Listar Check_IN's =====");
                                Console.WriteLine();
                                // Chama o método para listar os CHECK_IN's
                                regras.ListarCheck_I();
                                break;

                            case 0: // Opção Voltar
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

                case 2: // Opção CHECK_OUT
                    Console.WriteLine("===== Gestão de Check_OUT's =====");
                    Console.WriteLine();
                    Console.WriteLine("1. Fazer Check_OUT");
                    Console.WriteLine("2. Remover Check_OUT");
                    Console.WriteLine("3. Listar Check_OUT");
                    Console.WriteLine("0. Voltar");
                    Console.WriteLine();
                    Console.Write("Opção: ");

                    // Obtém a opção específica da categoria CHECK_OUT
                    if (int.TryParse(Console.ReadLine(), out int opcaoCheck_O))
                    {
                        Console.Clear();

                        // Estrutura switch para lidar com as opções relacionadas ao CHECK_OUT
                        switch (opcaoCheck_O)
                        {
                            case 1: // Opção Fazer Check_OUT
                                Console.WriteLine("===== Fazer Check_OUT =====");
                                Console.WriteLine();
                                try
                                {
                                    // Chama o método para o funcionário fazer um CHECK_OUT
                                    regras.InserirCheck_O();
                                }
                                catch (ECheck_Out co)
                                {
                                    // Trata exceção relacionada a CHECK_OUT
                                    Console.WriteLine("Erro" + "-" + co.Message);
                                }
                                break;

                            case 2: // Opção Remover Check_OUT
                                Console.WriteLine("===== Remover Check_OUT =====");
                                Console.WriteLine();
                                // Chama o método para o funcionário remover um CHECK_OUT
                                regras.RemoverCheck_O();
                                break;

                            case 3: // Opção Listar Check_OUT
                                Console.WriteLine("===== Listar Check_OUT's =====");
                                Console.WriteLine();
                                // Chama o método para listar os CHECK_OUT's
                                regras.ListarCheck_O();
                                break;

                            case 0: // Opção Voltar
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

                case 3: // Opção QUARTOS
                    Console.WriteLine("===== Gestão de Quartos =====");
                    Console.WriteLine();
                    Console.WriteLine("1. Inserir Quarto");
                    Console.WriteLine("2. Listar Quartos");
                    Console.WriteLine("0. Voltar");
                    Console.WriteLine();
                    Console.Write("Opção: ");

                    // Obtém a opção específica da categoria QUARTOS
                    if (int.TryParse(Console.ReadLine(), out int opcaoQuarto))
                    {
                        Console.Clear();

                        // Estrutura switch para lidar com as opções relacionadas aos QUARTOS
                        switch (opcaoQuarto)
                        {
                            case 1: // Opção Inserir Quarto
                                Console.WriteLine("===== Inserir Quarto =====");
                                Console.WriteLine();
                                // Chama o método para o funcionário inserir um quarto
                                regras.InserirQuarto();
                                break;

                            case 2: // Opção Listar Quartos
                                Console.WriteLine("===== Listar Quartos =====");
                                Console.WriteLine();
                                // Chama o método para listar os quartos
                                regras.ListarQuartosF();
                                break;

                            case 0: // Opção Voltar
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

                case 4: // Opção Alterar Dados
                    Console.WriteLine("===== Alterar Dados =====");
                    Console.WriteLine();
                    // Chama o método para editar os dados do funcionário
                    regras.EditarFuncF();
                    break;

                case 0: // Opção Sair
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
