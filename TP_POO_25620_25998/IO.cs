﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

using DLL_Objetos;
using DLL_Dados;
using System.Diagnostics.Contracts;
using System.Runtime.InteropServices.ComTypes;

namespace TP_POO_25620_25998
{
    public class IO
    {
        private static int NIFClienteLogin;

        #region CLIENTES

        public void InserirCliente(out string nome, out string morada, out string email, out string password, out int contacto, out DateTime dataNascimento, out int nif)
        {
            nome = string.Empty;
            morada = string.Empty;
            email = string.Empty;
            password = string.Empty;
            contacto = 0;
            dataNascimento = DateTime.MinValue;
            nif = 0;

            Console.WriteLine("Insira o nome do cliente");
            nome = Console.ReadLine();

            Console.WriteLine("Insira a morada do cliente");
            morada = Console.ReadLine();

            Console.WriteLine("Insira o email do cliente");
            email = Console.ReadLine();

            Console.WriteLine("Insira a password do cliente");
            password = Console.ReadLine();

            Console.WriteLine("Insira o contacto do cliente");
            contacto = int.Parse(Console.ReadLine());

            Console.WriteLine("Insira a data nascimento do cliente");
            dataNascimento = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Insira o nif do cliente");
            nif = int.Parse(Console.ReadLine());

        }

        public void RemoverCliente(out int nif)
        {
            nif = 0;

            Console.WriteLine("Insira o NIF do cliente que deseja remover");
            Console.WriteLine();
            Console.WriteLine("{0,-20} {1,-20}", "Nome do Cliente", "NIF do Cliente");

            foreach (var cliente in Clientes.CLIENTE)
            {
                Console.WriteLine("{0,-20} {1,-20}", cliente.Nome, cliente.NIF);
            }

            Console.WriteLine();
            Console.Write("Digite o NIF do cliente: ");
            nif = int.Parse(Console.ReadLine());
        }

        public void LoginCliente(out string password, out int nif)
        {
            password = string.Empty;
            nif = 0;

            Console.WriteLine("Insira o nif do cliente");
            nif = int.Parse(Console.ReadLine());

            Console.WriteLine("Insira a password do cliente");
            password = Console.ReadLine();

            NIFClienteLogin = nif;
    }

        #endregion

        #region ADMINS

        public void LoginAdmin(out string password, out int id)
        {

            password = string.Empty;
            id = 0;

            Console.WriteLine("Insira o ID do admin");
            id = int.Parse(Console.ReadLine());

            Console.WriteLine("Insira a password do admin");
            password = Console.ReadLine();

        }

        #endregion

        #region FUNCIONARIOS
        public void InserirFunc(out int idFunc, out string nome, out string email, out string password, out int contacto, out DateTime dataNascimento, out int alojamentoID)
        {
            idFunc = 0;
            nome = string.Empty;
            email = string.Empty;
            password = string.Empty;
            contacto = 0;
            dataNascimento = DateTime.MinValue;
            alojamentoID = 0;

            Console.WriteLine("Insira o ID do funcionario");
            idFunc = int.Parse(Console.ReadLine());

            Console.WriteLine("Insira o nome do funcionario");
            nome = Console.ReadLine();

            Console.WriteLine("Insira o email do funcionario");
            email = Console.ReadLine();

            Console.WriteLine("Insira a password do funcionario");
            password = Console.ReadLine();

            Console.WriteLine("Insira o contacto do funcionario");
            contacto = int.Parse(Console.ReadLine());

            Console.WriteLine("Insira a data nascimento do funcionario");
            dataNascimento = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Escolha um alojamento:");

            foreach (var alojamento in Alojamentos.ALOJAMENTO)
            {
                Console.WriteLine($"{alojamento.ID}: {alojamento.Nome}");
            }

            alojamentoID = int.Parse(Console.ReadLine());
        }

        public void RemoverFunc(out int id)
        {
            id = 0;

            Console.WriteLine("Insira o ID do funcionário que deseja remover");
            Console.WriteLine();
            Console.WriteLine("{0,-20} {1,-20}", "Nome do Funcionário", "ID do Funcionário");

            foreach (var funcionario in Funcionarios.FUNCIONARIO)
            {
                Console.WriteLine("{0,-20} {1,-20}", funcionario.Nome, funcionario.ID);
            }

            Console.WriteLine();
            Console.Write("Digite o ID do funcionário: ");
            id = int.Parse(Console.ReadLine());
        }

        public void LoginFunc(out string password, out int id)
        {

            password = string.Empty;
            id = 0;

            Console.WriteLine("Insira o ID do funcionário");
            id = int.Parse(Console.ReadLine());

            Console.WriteLine("Insira a password do funcionário");
            password = Console.ReadLine();

        }

        #endregion

        #region ALOJAMENTOS

        public void InserirAlojamento(out int idAlojamento, out string nomeAlojamento, out string tipoAlojamento, out string localizacao)
        {
            idAlojamento = 0;
            nomeAlojamento = string.Empty;
            tipoAlojamento = string.Empty;
            localizacao = string.Empty;

            Console.WriteLine("Insira o ID do Alojamento");
            idAlojamento = int.Parse(Console.ReadLine());

            Console.WriteLine("Insira o nome do alojamento");
            nomeAlojamento = Console.ReadLine();

            Console.WriteLine("Insira o tipo do alojamento");
            tipoAlojamento = Console.ReadLine();

            Console.WriteLine("Insira a localizacao do alojamento");
            localizacao = Console.ReadLine();
        }

        public void RemoverAlojamento(out int id)
        {
            id = 0;

            Console.WriteLine("Insira o ID do alojamento que deseja remover");
            Console.WriteLine();
            Console.WriteLine("{0,-20} {1,-20}", "Nome do Alojamento", "ID do Alojamento");

            foreach (var alojamento in Alojamentos.ALOJAMENTO)
            {
                Console.WriteLine("{0,-20} {1,-20}", alojamento.Nome, alojamento.ID);
            }

            Console.WriteLine();
            Console.Write("Digite o ID do alojamento: ");
            id = int.Parse(Console.ReadLine());
        }

        #endregion

        #region QUARTOS

        public void InserirQuarto(out int id, out string tipo, out bool disponibilidade, out decimal valor, out int alojamentoID)
        {
            id = 0;
            tipo = string.Empty;
            disponibilidade = false;
            valor = 0;
            alojamentoID = 0;

            Console.WriteLine("Insira o ID do quarto");
            id = int.Parse(Console.ReadLine());

            Console.WriteLine("Escolha o tipo do quarto (1 - Duplo, 2 - Triplo, 3 - Familiar, 4 - Suíte):");
            int tipoEscolhido = int.Parse(Console.ReadLine());

            switch (tipoEscolhido)
            {
                case 1:
                    tipo = "Duplo";
                    break;

                case 2:
                    tipo = "Triplo";
                    break;

                case 3:
                    tipo = "Familiar";
                    break;

                case 4:
                    tipo = "Suíte";
                    break;
                
                default:
                    Console.WriteLine();
                    Console.WriteLine("Tipo de quarto não reconhecido.");
                    return; 
            }

            Console.WriteLine("Insira a disponibilidade (S/N)");
            string disponibilidadeInput = Console.ReadLine();

            disponibilidade = (disponibilidadeInput.Trim().ToUpper() == "S");

            if (!disponibilidade && disponibilidadeInput.Trim().ToUpper() != "N")
            {
                Console.WriteLine("Valor inválido. Insira S ou N.");
            }

            Console.WriteLine("Insira o valor por noite do quarto");
            valor = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Escolha um alojamento:");

            foreach (var alojamento in Alojamentos.ALOJAMENTO)
            {
                Console.WriteLine($"{alojamento.ID}: {alojamento.Nome}");
            }

            alojamentoID = int.Parse(Console.ReadLine());
        }

        public void RemoverQuarto(out int id)
        {
            id = 0;

            Console.WriteLine("Insira o ID do quarto que deseja remover");
            Console.WriteLine();
            Console.WriteLine("{0,-20} {1,-20} {2,-20}", "Tipo de Quarto", "ID do Quarto", "ID do Alojamento");

            foreach (var quarto in Quartos.QUARTO)
            {
                Console.WriteLine("{0,-20} {1,-20} {2,-20}", quarto.Tipo, quarto.ID, quarto.Alojamento.ID);
            }

            Console.WriteLine();
            Console.Write("Digite o ID do quarto: ");
            id = int.Parse(Console.ReadLine());
        }

        #endregion

        #region RESERVAS

        public void InserirReserva(out int id, out DateTime dataInicio, out DateTime dataFim, out int numPessoas, out int clienteNIF, out int alojamentoID, out int quartoID, out decimal precoTotal)
        {
            decimal valorQuarto = 0;
            int quantPessoas = 0;
            clienteNIF = NIFClienteLogin;

            Console.WriteLine("Insira o ID da reserva");
            id = int.Parse(Console.ReadLine());
            Console.WriteLine();

            // Títulos para ALOJAMENTOS
            Console.WriteLine("ALOJAMENTOS");
            Console.WriteLine();
            Console.WriteLine("{0,-20} {1,-20}", "Nome do Alojamento", "ID do Alojamento");

            foreach (var alojamento in Alojamentos.ALOJAMENTO)
            {
                Console.WriteLine("{0,-20} {1,-20}", alojamento.Nome, alojamento.ID);
            }

            Console.WriteLine();
            Console.Write("Digite o ID do alojamento: ");
            alojamentoID = int.Parse(Console.ReadLine());

            // Variável local para armazenar alojamentoID
            int alojamentoTemp = alojamentoID;

            // Títulos para datas e Nº de Pessoas
            Console.WriteLine();
            Console.WriteLine("Insira a data de início da reserva (formato dd/MM/yyyy)");
            dataInicio = DateTime.Parse(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine("Insira a data de fim da reserva (formato dd/MM/yyyy)");
            dataFim = DateTime.Parse(Console.ReadLine());

            Console.WriteLine();
            Console.Write("Digite o Nº de Pessoas: ");
            numPessoas = int.Parse(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine("QUARTOS");
            Console.WriteLine();
            Console.WriteLine("{0,-20} {1,-20} {2,-20}", "Tipo do Quarto", "ID do Quarto", "Valor Estadia (por dia)");

            // Mostrar quartos disponíveis no alojamento selecionado
            foreach (var quarto in Quartos.QUARTO.Where(q => q.Alojamento.ID == alojamentoTemp && q.Disponibilidade == true))
            {
                Console.WriteLine("{0,-20} {1,-20} {2,-20}", quarto.Tipo, quarto.ID, quarto.Valor);
            }

            Console.WriteLine();
            Console.Write("Digite o ID do quarto: ");
            quartoID = int.Parse(Console.ReadLine());

            int quartoTemp = quartoID;
           
            var quartoEscolhido = Quartos.QUARTO.FirstOrDefault(q => q.ID == quartoTemp);

            // Verificar se o número de pessoas escolhido é compatível com o quarto
            quantPessoas = ObterQuant(quartoEscolhido.Tipo);
            valorQuarto = quartoEscolhido.Valor;

            if (numPessoas > quantPessoas || numPessoas < quantPessoas)
            {
                precoTotal = 0;
                Console.WriteLine();
                Console.WriteLine("Número de pessoas é maior ou menor do que a capacidade do quarto.");
                Console.WriteLine();
                return;
            }

            // Lógica para calcular o preço total da reserva
            int numDias = (int)(dataFim - dataInicio).TotalDays;
            decimal preco = valorQuarto * numDias;
            Console.WriteLine();
            Console.WriteLine($"Preço total da reserva: {preco}");
            Console.WriteLine();
            precoTotal = preco;
        }

        private int ObterQuant(string tipoQuarto)
        {
            switch (tipoQuarto.ToLower())
            {
                case "duplo":
                    return 2;
                case "triplo":
                    return 3;
                case "familiar":
                    return 4;
                case "suíte":
                    return 5;
                default:
                    return 0; 
            }
        }

        #endregion
    }
}

