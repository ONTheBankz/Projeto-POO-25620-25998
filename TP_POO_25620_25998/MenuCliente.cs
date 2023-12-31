using DLL_Regras;
using System;
using DLL_Exceptions;

public class MenuCliente
{
    // Instância da classe Regras
    private Regras regras;

    public MenuCliente()
    {
        // Inicializa a instância da classe Regras
        regras = new Regras();
    }

    // Método para mostrar o menu do cliente
    public void MostrarMenuC()
    {
        // Limpa o ecrã e mostra o menu do cliente
        Console.Clear();
        Console.WriteLine("===== Gestão de Alojamentos Turísticos =====");
        Console.WriteLine();
        Console.WriteLine("1. Fazer Reserva");
        Console.WriteLine("2. Cancelar Reserva");
        Console.WriteLine("3. Listar Reservas");
        Console.WriteLine();
        Console.WriteLine("0. Sair");
        Console.WriteLine();
        Console.Write("Opção: ");

        // Obtém a opção escolhida pelo cliente
        int opcaoCliente = int.Parse(Console.ReadLine());

        Console.Clear();

        // Estrutura switch para lidar com as opções escolhidas pelo cliente
        switch (opcaoCliente)
        {
            case 1: // Opção Fazer Reserva
                Console.WriteLine("===== Fazer Reserva =====");
                Console.WriteLine();
                try
                {
                    // Chama o método para o cliente fazer uma reserva
                    regras.InserirReservaC();
                }
                catch (EReserva r)
                {
                    // Trata exceção relacionada a reservas
                    Console.WriteLine("Erro" + "-" + r.Message);
                }
                break;

            case 2: // Opção Cancelar Reserva
                Console.WriteLine("===== Cancelar Reserva =====");
                Console.WriteLine();
                // Chama o método para o cliente cancelar uma reserva
                regras.RemoverReservaC();
                break;

            case 3: // Opção Listar Reservas
                Console.WriteLine("===== Listar Reservas =====");
                Console.WriteLine();
                // Chama o método para listar as reservas do cliente
                regras.ListarReservaC();
                break;

            case 4: // Opção Alterar Dados
                Console.WriteLine("===== Alterar Dados =====");
                Console.WriteLine();
                // Chama o método para editar os dados do cliente
                regras.EditarClienteC();
                break;

            case 0: // Opção Sair
                break;

            default:
                Console.WriteLine("Opção inválida. Tente novamente.");
                break;
        }

        if (opcaoCliente != 0)
        {
            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
            MostrarMenuC();
        }
    }
}
