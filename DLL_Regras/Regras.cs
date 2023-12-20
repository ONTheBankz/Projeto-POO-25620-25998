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
            IO io = new IO();
            string nome;
            string morada;
            string email;
            string password;
            int contacto;
            DateTime dataNascimento;
            int nif;

            io.InserirCliente(out nome, out morada, out email, out password, out contacto, out dataNascimento, out nif);
            if (clientes.ExisteCliente(nif) == false)
            {
                Cliente cliente = new Cliente(nome, morada, email, password, contacto, dataNascimento, nif);
                clientes.InserirCliente(cliente);
                return true;
            }

            return false;
        }

        public bool LoginCliente()
        {
            Clientes clientes = new Clientes();
            IO io = new IO();
            string password;
            int nif;

            io.LoginCliente(out password, out nif);
            if (clientes.AuthCliente(nif, password) == true)
            {
                // Autenticação bem-sucedida
                return true;
            }

            // Autenticação falhou
            Console.Clear();
            Console.WriteLine("Falha na autenticação.");
            Console.ReadKey();
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

        #region FUNCIONARIOS

        public bool InserirFunc()
        {
            Funcionarios funcionarios = new Funcionarios();
            IO io = new IO();
            int idFunc;
            string nome;
            string email;
            string password;
            int contacto;
            DateTime dataNascimento;
            int alojamentoID;

            io.InserirFunc(Alojamentos.ALOJAMENTO, out idFunc, out nome, out email, out password, out contacto, out dataNascimento, out alojamentoID);

            if (funcionarios.ExisteFunc(idFunc) == false)
            {
                Alojamento alojamento = new Alojamento { ID = alojamentoID };

                Funcionario funcionario = new Funcionario(idFunc, nome, email, password, contacto, dataNascimento, alojamento);
                funcionarios.InserirFunc(funcionario);
                return true;
            }

            return false;
        }

        public bool ListarFunc()
        {
            Funcionarios funcionarios = new Funcionarios();
            funcionarios.ListarFunc();
            return true;
        }

        public bool GravarFunc(string f)
        {
            Funcionarios funcionarios = new Funcionarios();
            funcionarios.GravarFunc(f);
            return true;
        }

        public bool LerFunc(string f)
        {
            Funcionarios funcionarios = new Funcionarios();
            funcionarios.LerFunc(f);
            return true;
        }

        public bool LoginFunc()
        {
            Funcionarios funcionarios = new Funcionarios();
            IO io = new IO();
            string password;
            int id;

            io.LoginFunc(out password, out id);
            if (funcionarios.AuthFunc(id, password) == true)
            {
                // Autenticação bem-sucedida
                return true;
            }

            // Autenticação falhou
            Console.Clear();
            Console.WriteLine("Falha na autenticação.");
            Console.ReadKey();
            return false;
        }

        #endregion

        #region QUARTOS

        public bool InserirQuarto()
        {
            Quartos quartos = new Quartos();
            IO io = new IO();
            int idQuarto;
            string tipo;
            bool disponibilidade;
            decimal valor;
            int alojamentoID;

            io.InserirQuarto(Alojamentos.ALOJAMENTO, out idQuarto, out tipo, out disponibilidade, out valor, out alojamentoID);
            if (quartos.ExisteQuarto(idQuarto) == false)
            {
                Alojamento alojamento = new Alojamento { ID = alojamentoID };

                Quarto quarto = new Quarto(idQuarto, tipo, disponibilidade, valor, alojamento);
                quartos.InserirQuarto(quarto);
                return true;
            }

            return false;
        }

        public bool ListarQuartos()
        {
            Quartos quartos = new Quartos();
            quartos.ListarQuartos();
            return true;
        }

        public bool GravarQuarto(string q)
        {
            Quartos quartos = new Quartos();
            quartos.GravarQuarto(q);
            return true;
        }

        public bool LerQuarto(string q)
        {
            Quartos quartos = new Quartos();
            quartos.LerQuarto(q);
            return true;
        }

        #endregion

        #region ADMINS

        public bool LerAdmin(string a)
        {
            Admins admins = new Admins();
            admins.LerAdmin(a);
            return true;
        }

        public bool LoginAdmin()
        {
            Admins admins = new Admins();
            IO io = new IO();
            string password;
            int id;

            io.LoginAdmin(out password, out id);
            if (admins.AuthAdmin(id, password) == true)
            {
                // Autenticação bem-sucedida
                return true;
            }

            // Autenticação falhou
            Console.Clear();
            Console.WriteLine("Falha na autenticação.");
            Console.ReadKey();
            return false;
        }

        #endregion
    }
}
