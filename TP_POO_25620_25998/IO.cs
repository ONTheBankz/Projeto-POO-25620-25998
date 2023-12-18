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
        public void InserirCliente(out string nome, out string email, out int contacto, out DateTime dataNascimento, out string morada, out int nif)
        {
            nome = string.Empty;
            email = string.Empty;
            contacto = 0;
            dataNascimento = DateTime.MinValue;
            morada = string.Empty;
            nif = 0;

            Console.WriteLine("Insira o seu nome");          
            nome = Console.ReadLine();

            Console.WriteLine("Insira o seu email");
            email = Console.ReadLine();

            Console.WriteLine("Insira o seu contacto");
            contacto = int.Parse (Console.ReadLine());

            Console.WriteLine("Insira a sua data nascimento");
            dataNascimento = DateTime.Parse (Console.ReadLine());

            Console.WriteLine("Insira a sua morada");
            morada = Console.ReadLine();

            Console.WriteLine("Insira o seu nif");
            nif = int.Parse (Console.ReadLine());

        }
    }
}
