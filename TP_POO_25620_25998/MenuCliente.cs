﻿using DLL_Regras;
using System;

public class MenuCliente
{
    private Regras regras;

    public MenuCliente()
    {
        regras = new Regras();
    }

    public void MostrarMenuC()
    {
        Console.Clear();
        Console.WriteLine("===== Gestão de Alojamentos Turísticos =====");
        Console.WriteLine();
        Console.WriteLine("1. Fazer Reserva");
        Console.WriteLine("2. Cancelar Reserva");
        Console.WriteLine("3. Listar Reservas");
        Console.WriteLine();
        Console.WriteLine("4. Alterar Dados");
        Console.WriteLine("0. Sair");
        Console.WriteLine();
        Console.Write("Opção: ");

        int opcaoCliente = int.Parse(Console.ReadLine());

        Console.Clear();

        switch (opcaoCliente) 
        {
            case 1:
                Console.WriteLine("===== Fazer Reserva =====");
                Console.WriteLine();
                //regras.CriarReserva();
                break;
            case 2:
                Console.WriteLine("===== Cancelar Reserva =====");
                Console.WriteLine();
                //regras.CancelarReserva
                break;
            case 3:
                Console.WriteLine("===== Listar Reservas =====");
                Console.WriteLine();
                //regras.ListarReserva
                break;
            case 4:
                Console.WriteLine("===== Alterar Dados =====");
                Console.WriteLine();
                //regras.EditarCliente
                break;
            case 0:
                Console.WriteLine("A sair do programa!");
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