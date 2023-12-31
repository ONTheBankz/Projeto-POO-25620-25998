using DLL_Exceptions;
using DLL_Regras;
using System;

public class MenuAdmin
{
    // Instância da classe Regras 
    private Regras regras;

    public MenuAdmin()
    {
        // Inicializa a instância da classe Regras
        regras = new Regras();
    }

    // Método para mostrar o menu principal de admin
    public void MostrarMenuA()
    {
        // Limpa o ecrã e mostra o menu
        Console.Clear();
        Console.WriteLine("===== Gestão de Alojamentos Turísticos =====");
        Console.WriteLine();
        Console.WriteLine("Escolha uma categoria:");
        Console.WriteLine();
        Console.WriteLine("1. CLIENTES");
        Console.WriteLine("2. FUNCIONÁRIOS");
        Console.WriteLine("3. ALOJAMENTOS");
        Console.WriteLine("4. QUARTOS");
        Console.WriteLine("5. RESERVAS");
        Console.WriteLine();
        Console.WriteLine("0. Sair");
        Console.WriteLine();
        Console.Write("Opção: ");

        // Obtém a opção da categoria escolhida pelo utilizador
        int opcaoCategoria = int.Parse(Console.ReadLine());
        Console.Clear(); // Limpa o ecrã antes de mostrar o resultado da opção escolhida

        // Estrutura switch para lidar com as opções de categoria
        switch (opcaoCategoria)
        {
            case 1: // Categoria CLIENTES
                Console.WriteLine("===== Gestão de Clientes =====");
                Console.WriteLine();
                Console.WriteLine("1. Inserir Cliente");
                Console.WriteLine("2. Remover Clientes");
                Console.WriteLine("3. Listar Clientes");
                Console.WriteLine();
                Console.WriteLine("4. Alterar Dados");
                Console.WriteLine("0. Voltar");
                Console.WriteLine();
                Console.Write("Opção: ");

                // Obtém a opção específica da categoria CLIENTES
                int opcaoCliente = int.Parse(Console.ReadLine());

                Console.Clear();

                // Estrutura switch para lidar com as opções específicas de CLIENTES
                switch (opcaoCliente)
                {
                    case 1:
                        Console.WriteLine("===== Inserir Cliente =====");
                        Console.WriteLine();
                        // Chama o método para inserir um cliente
                        regras.InserirCliente();
                        break;
                    case 2:
                        Console.WriteLine("===== Remover Clientes =====");
                        Console.WriteLine();
                        // Chama o método para remover clientes
                        regras.RemoverCliente();
                        break;
                    case 3:
                        Console.WriteLine("===== Listar Clientes =====");
                        Console.WriteLine();
                        // Chama o método para listar clientes
                        regras.ListarClientes();
                        break;
                    case 4:
                        Console.WriteLine("===== Alterar Dados Cliente =====");
                        Console.WriteLine();
                        // Chama o método para editar dados de um cliente
                        regras.EditarClienteA();
                        break;
                    case 0:
                        // Opção para voltar ao menu anterior
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
                break;

            case 2: // Categoria FUNCIONÁRIOS
                Console.WriteLine("===== Gestão de Funcionários =====");
                Console.WriteLine();
                Console.WriteLine("1. Inserir Funcionário");
                Console.WriteLine("2. Remover Funcionários");
                Console.WriteLine("3. Listar Funcionários");
                Console.WriteLine();
                Console.WriteLine("4. Alterar Dados");
                Console.WriteLine("0. Voltar");
                Console.WriteLine();
                Console.Write("Opção: ");

                // Obtém a opção específica da categoria FUNCIONÁRIOS
                int opcaoFuncionario = int.Parse(Console.ReadLine());

                Console.Clear();

                // Estrutura switch para lidar com as opções específicas de FUNCIONÁRIOS
                switch (opcaoFuncionario)
                {
                    case 1:
                        Console.WriteLine("===== Inserir Funcionário =====");
                        Console.WriteLine();
                        // Chama o método para inserir um funcionário
                        regras.InserirFunc();
                        break;
                    case 2:
                        Console.WriteLine("===== Remover Funcionários =====");
                        Console.WriteLine();
                        // Chama o método para remover funcionários
                        regras.RemoverFunc();
                        break;
                    case 3:
                        Console.WriteLine("===== Listar Funcionários =====");
                        Console.WriteLine();
                        // Chama o método para listar funcionários
                        regras.ListarFunc();
                        break;
                    case 4:
                        Console.WriteLine("===== Alterar Dados Funcionário =====");
                        Console.WriteLine();
                        // Chama o método para editar dados de um funcionário
                        regras.EditarFuncA();
                        break;
                    case 0:
                        // Opção para voltar ao menu anterior
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
                break;

            case 3: // Categoria ALOJAMENTOS
                Console.WriteLine("===== Gestão de Alojamentos =====");
                Console.WriteLine();
                Console.WriteLine("1. Inserir Alojamento");
                Console.WriteLine("2. Remover Alojamentos");
                Console.WriteLine("3. Listar Alojamentos");
                Console.WriteLine();
                Console.WriteLine("0. Voltar");
                Console.WriteLine();
                Console.Write("Opção: ");

                // Obtém a opção específica da categoria ALOJAMENTOS
                int opcaoAlojamento = int.Parse(Console.ReadLine());

                Console.Clear();

                // Estrutura switch para lidar com as opções específicas de ALOJAMENTOS
                switch (opcaoAlojamento)
                {
                    case 1:
                        Console.WriteLine("===== Inserir Alojamento =====");
                        Console.WriteLine();
                        // Chama o método para inserir um alojamento
                        regras.InserirAlojamento();
                        break;
                    case 2:
                        Console.WriteLine("===== Remover Alojamentos =====");
                        Console.WriteLine();
                        // Chama o método para remover alojamentos
                        regras.RemoverAlojamento();
                        break;
                    case 3:
                        Console.WriteLine("===== Listar Alojamentos =====");
                        Console.WriteLine();
                        // Chama o método para listar alojamentos
                        regras.ListarAlojamentos();
                        break;
                    case 0:
                        // Opção para voltar ao menu anterior
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
                break;

            case 4: // Categoria QUARTOS
                Console.WriteLine("===== Gestão de Quartos =====");
                Console.WriteLine();
                Console.WriteLine("1. Inserir Quarto");
                Console.WriteLine("2. Remover Quartos");
                Console.WriteLine("3. Listar Quartos");
                Console.WriteLine();
                Console.WriteLine("0. Voltar");
                Console.WriteLine();
                Console.Write("Opção: ");

                // Obtém a opção específica da categoria QUARTOS
                int opcaoQuarto = int.Parse(Console.ReadLine());

                Console.Clear();

                // Estrutura switch para lidar com as opções específicas de QUARTOS
                switch (opcaoQuarto)
                {
                    case 1:
                        Console.WriteLine("===== Inserir Quarto =====");
                        Console.WriteLine();
                        // Chama o método para inserir um quarto
                        regras.InserirQuarto();
                        break;
                    case 2:
                        Console.WriteLine("===== Remover Quartos =====");
                        Console.WriteLine();
                        // Chama o método para remover quartos
                        regras.RemoverQuarto();
                        break;
                    case 3:
                        Console.WriteLine("===== Listar Quartos =====");
                        Console.WriteLine();
                        // Chama o método para listar quartos
                        regras.ListarQuartos();
                        break;
                    case 0:
                        // Opção para voltar ao menu anterior
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
                break;

            case 5: // Categoria RESERVAS
                Console.Clear();
                Console.WriteLine("===== Gestão de Reservas =====");
                Console.WriteLine();
                Console.WriteLine("1. Fazer Reserva");
                Console.WriteLine("2. Cancelar Reserva");
                Console.WriteLine("3. Listar Reservas");
                Console.WriteLine();
                Console.WriteLine("0. Sair");
                Console.WriteLine();
                Console.Write("Opção: ");

                // Obtém a opção específica da categoria RESERVAS
                int opcaoReserva = int.Parse(Console.ReadLine());

                Console.Clear();

                // Estrutura switch para lidar com as opções específicas de RESERVAS
                switch (opcaoReserva)
                {
                    case 1:
                        Console.WriteLine("===== Fazer Reserva =====");
                        Console.WriteLine();
                        try
                        {
                            // Chama o método para fazer uma reserva
                            regras.InserirReservaA();
                        }
                        catch (EReserva r)
                        {
                            // Trata exceção relacionada a reservas
                            Console.WriteLine("Erro" + "-" + r.Message);
                        }
                        break;
                    case 2:
                        Console.WriteLine("===== Cancelar Reserva =====");
                        Console.WriteLine();
                        // Chama o método para cancelar uma reserva
                        regras.RemoverReservaA();
                        break;
                    case 3:
                        Console.WriteLine("===== Listar Reservas =====");
                        Console.WriteLine();
                        // Chama o método para listar reservas
                        regras.ListarReservaA();
                        break;
                    case 0:
                        // Opção para sair do menu
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
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
            MostrarMenuA();
        }
    }
}
