using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

using DLL_Objetos;
using DLL_Dados;
using System.Diagnostics.Contracts;

namespace TP_POO_25620_25998
{
    public class IO
    {
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

            Console.WriteLine("Insira o tipo do quarto");
            tipo = Console.ReadLine();

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
    }
}

