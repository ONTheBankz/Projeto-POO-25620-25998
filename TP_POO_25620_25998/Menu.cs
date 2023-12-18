using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

using DLL_Objetos;
using DLL_Dados;
using DLL_Regras;

namespace TP_POO_25620_25998
{
    public class Menu
    {
        public void MostrarMenu()
        {
            Clientes c = new Clientes();
            Regras regras = new Regras();

            Console.WriteLine("===== Gestão de Alojamentos Turísticos =====");
            Console.WriteLine("1. Inserir Cliente");
            Console.WriteLine("2. Outras opções...");
            Console.WriteLine("0. Sair");
            Console.Write("Escolha uma opção: ");

            int opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    regras.InserirCliente();
                    break;
                case 2:
                    // Adicione outras opções conforme necessário
                    break;
                case 0:
                    Console.WriteLine("Saindo do programa. Até logo!");
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }

            // Chama recursivamente o menu até que o usuário escolha sair (opção 0)
            if (opcao != 0)
            {
                Console.WriteLine("\nPressione qualquer tecla para continuar...");
                Console.ReadKey();
                Console.Clear();
                MostrarMenu();
            }
        }
    }
}
