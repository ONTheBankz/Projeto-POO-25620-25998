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

        #region CLIENTES
        public bool InserirCliente()
        {
            Clientes clientes = new Clientes();
            IO io= new IO();
            string nome; 
            string email; 
            string password;
            int contacto; 
            DateTime dataNascimento; 
            string morada; 
            int nif;
            io.InserirCliente(out nome, out email, out password, out contacto, out dataNascimento, out morada, out nif);
             if (clientes.ExisteCliente(nif) == false)
            {
                Cliente cliente= new Cliente(nome, morada, email, password, contacto, dataNascimento, nif);
                clientes.InserirCliente(cliente);
                return true;
            }

            return false;
        }

        public bool ListarClientes()
        {
            Clientes clientes = new Clientes();
            clientes.ListarClientes();
            return true;
        }

        public bool GravarCliente(string c)
        {
            Clientes clientes = new Clientes();
            clientes.GravarCliente(c);  
            return true;
        }

        public bool LerCliente(string c)
        {
            Clientes clientes = new Clientes();
            clientes.LerCliente(c);
            return true;
        }

        #endregion

        #region ALOJAMENTOS

        public bool InserirAlojamento()
        {
            Alojamentos alojamentos = new Alojamentos();
            IO io = new IO();
            int idAlojamento;
            string nomeAlojamento;
            string tipoAlojamento;
            string localizacao;
            io.InserirAlojamento(out idAlojamento, out nomeAlojamento, out tipoAlojamento, out localizacao);
            if (alojamentos.ExisteAlojamento(idAlojamento) == false)
            {
                Alojamento alojamento = new Alojamento(idAlojamento, nomeAlojamento, tipoAlojamento, localizacao);
                alojamentos.InserirAlojamento(alojamento);
                return true;
            }

            return false;
        }

        public bool ListarAlojamentos()
        {
            Alojamentos alojamentos = new Alojamentos();
            alojamentos.ListarAlojamentos();
            return true;
        }

        public bool GravarAlojamento(string a)
        {
            Alojamentos alojamentos = new Alojamentos();
            alojamentos.GravarAlojamento(a);
            return true;
        }

        public bool LerAlojamento(string a)
        {
            Alojamentos alojamentos = new Alojamentos();
            alojamentos.LerAlojamento(a);
            return true;
        }

        #endregion
    }
}
