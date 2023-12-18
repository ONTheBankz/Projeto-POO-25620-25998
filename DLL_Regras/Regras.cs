using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DLL_Objetos;
using DLL_Dados;
using TP_POO_25620_25998;

namespace DLL_Regras
{
    public class Regras
    {

        public bool InserirCliente()
        {
            Clientes clientes = new Clientes();
            IO io= new IO();
            string nome; 
            string email; 
            int contacto; 
            DateTime dataNascimento; 
            string morada; 
            int nif;
            io.InserirCliente(out nome, out email, out contacto, out dataNascimento, out morada, out nif);
             if (clientes.ExisteCliente(nif) == false)
            {
                Cliente cliente= new Cliente(nome, morada, email, contacto, dataNascimento, nif);
                clientes.InserirCliente(cliente);
                return true;
            }

            return false;
        }

    }
}
