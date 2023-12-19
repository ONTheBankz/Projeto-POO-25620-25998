using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

using DLL_Objetos;
using DLL_Dados;

namespace TP_POO_25620_25998
{
    public class IO
    {
        #region CLIENTES
        public void InserirCliente(out string nome, out string email, out string password, out int contacto, out DateTime dataNascimento, out string morada, out int nif)
        {
            nome = string.Empty;
            email = string.Empty;
            password = string.Empty;    
            contacto = 0;
            dataNascimento = DateTime.MinValue;
            morada = string.Empty;
            nif = 0;

            Console.WriteLine("Insira o nome do cliente");          
            nome = Console.ReadLine();

            Console.WriteLine("Insira o email do cliente");
            email = Console.ReadLine();

            Console.WriteLine("Insira a password do cliente");
            password = Console.ReadLine();

            Console.WriteLine("Insira o contacto do cliente");
            contacto = int.Parse (Console.ReadLine());

            Console.WriteLine("Insira a data nascimento do cliente");
            dataNascimento = DateTime.Parse (Console.ReadLine());

            Console.WriteLine("Insira a morada do cliente");
            morada = Console.ReadLine();

            Console.WriteLine("Insira o nif do cliente");
            nif = int.Parse (Console.ReadLine());

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

        #endregion
    }
}

