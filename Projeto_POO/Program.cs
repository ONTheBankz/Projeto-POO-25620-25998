using System;
using DLL_Classes;
using DLL_Classes_II;

namespace Projeto_POO
{
    class Program
    {
        static void Main(string[] args)
        {
            // Criar uma instância de Cliente
            Cliente cliente = new Cliente
            {
                Nome = "João Silva",
                Morada = "Rua Principal, 123",
                Email = "joao.silva@example.com",
                DataNascimento = new DateTime(1990, 5, 15),
                Contacto = 123456789,
                NIF = 123456789
            };

            Cliente cliente2 = new Cliente
            {
                Nome = "Artur Jorge",
                Morada = "Rua dos Amores, 24",
                Email = "artur@example.com",
                DataNascimento = new DateTime(1990, 5, 15),
                Contacto = 123456789,
                NIF = 235115886
            };

            // Criar uma instância de Alojamento
            Alojamento alojamento = new Alojamento
            {
                ID = 1,
                Nome = "Hotel ABC",
                Tipo = "Hotel",
                Localizacao = "Cidade XYZ"
            };

            // Criar uma instância de Alojamento
            Alojamento alojamento2 = new Alojamento
            {
                ID = 2,
                Nome = "Casa XXX",
                Tipo = "Alojamento Local",
                Localizacao = "Porto"
            };

            // Criar uma instância de Quarto associada ao Alojamento
            Quarto quarto = new Quarto
            {
                ID = 101,
                Alojamento = alojamento,
                Tipo = "Quarto Duplo",
                Num = 150,
                Disponibilidade = true,
                Valor = 150.0m
            };

            // Criar uma instância de Quarto associada ao Alojamento
            Quarto quarto2 = new Quarto
            {
                ID = 130,
                Alojamento = alojamento2,
                Tipo = "Suite",
                Num = 10,
                Disponibilidade = true,
                Valor = 100.0m
            };

            // Criar uma instância de Reserva associada ao Cliente, Alojamento e Quarto
            Reserva reserva = new Reserva
            {
                ID = 100,
                Alojamento = alojamento,
                Cliente = cliente2,
                NumPessoas = 2,
                DataInicio = new DateTime(2023, 12, 1),
                DataFim = new DateTime(2023, 12, 7)            
            };

            CheckIn checkin = new CheckIn
            {
                ID = 1001,
                Reserva = reserva,
                DataCheckIn = new DateTime(2023, 12, 7),
            };

            // Exibir os detalhes da reserva
            Console.WriteLine(reserva);  
            Console.WriteLine(checkin);

            // Aguarde o utilizador pressionar Enter antes de fechar o console
            Console.ReadLine();
        }
    }
}