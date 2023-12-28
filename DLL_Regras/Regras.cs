using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DLL_Objetos;
using DLL_Dados;
using TP_POO_25620_25998;
using System.Runtime.Remoting.Messaging;
using System.Diagnostics.Contracts;

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

        public bool RemoverCliente()
        {
            Clientes clientes = new Clientes();
            IO io = new IO();
            int nif;
            io.RemoverCliente(out nif);

            if (clientes.ExisteCliente(nif))
            {
                Cliente cliente = new Cliente();
                cliente.NIF = nif;

                clientes.RemoverCliente(cliente);

                return true;
            }
            Console.Clear();
            Console.WriteLine("Cliente não encontrado ou não removido. NIF não existe.");
            Console.WriteLine();
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

        public bool RemoverAlojamento()
        {
            Alojamentos alojamentos = new Alojamentos();
            IO io = new IO();
            int id;
            io.RemoverAlojamento(out id);

            if (alojamentos.ExisteAlojamento(id))
            {
                Alojamento alojamento = new Alojamento();
                alojamento.ID = id;

                alojamentos.RemoverAlojamento(alojamento);

                return true;
            }
            Console.Clear();
            Console.WriteLine("Cliente não encontrado ou não removido. NIF não existe.");
            Console.WriteLine();
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

            io.InserirFunc(out idFunc, out nome, out email, out password, out contacto, out dataNascimento, out alojamentoID);

            if (funcionarios.ExisteFunc(idFunc) == false)
            {
                Alojamento alojamento = new Alojamento { ID = alojamentoID };

                Funcionario funcionario = new Funcionario(idFunc, nome, email, password, contacto, dataNascimento, alojamento);
                funcionarios.InserirFunc(funcionario);
                return true;
            }

            return false;
        }

        public bool RemoverFunc()
        {
            Funcionarios funcionarios = new Funcionarios();
            IO io = new IO();
            int id;
            io.RemoverFunc(out id);

            if (funcionarios.ExisteFunc(id))
            {
                Funcionario funcionario = new Funcionario();
                funcionario.ID = id;

                funcionarios.RemoverFunc(funcionario);

                return true;
            }
            Console.Clear();
            Console.WriteLine("Funcionário não encontrado ou não removido. ID não existe.");
            Console.WriteLine();
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

            io.InserirQuarto(out idQuarto, out tipo, out disponibilidade, out valor, out alojamentoID);
            if (quartos.ExisteQuarto(idQuarto) == false)
            {
                Alojamento alojamento = new Alojamento { ID = alojamentoID };

                Quarto quarto = new Quarto(idQuarto, tipo, disponibilidade, valor, alojamento);
                quartos.InserirQuarto(quarto);
                return true;
            }

            return false;
        }

        public bool RemoverQuarto()
        {
            Quartos quartos = new Quartos();
            IO io = new IO();
            int id;
            io.RemoverQuarto(out id);

            if (quartos.ExisteQuarto(id))
            {
                Quarto quarto = new Quarto();
                quarto.ID = id;

                quartos.RemoverQuarto(quarto);

                return true;
            }
            Console.Clear();
            Console.WriteLine("Quarto não encontrado ou não removido. ID não existe.");
            Console.WriteLine();
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

        #region RESERVAS

        public bool InserirReservaC()
        {
            Reservas reservas = new Reservas();
            Quartos quartos = new Quartos();
            IO io = new IO();
            int id;
            DateTime dataInicio;
            DateTime dataFim;
            int numPessoas;
            int clienteNIF;
            int quartoID;
            int quantPessoas;
            decimal precoTotal;

            Random random = new Random();

            // Loop para gerar um ID de reserva único
            do
            {
                id = random.Next(1, 1000); // Defina o intervalo conforme necessário
            } while (reservas.ExisteReserva(id));

            // Verifica se io.InserirClienteC foi bem-sucedido antes de prosseguir
            if (io.InserirReservaC(out dataInicio, out dataFim, out numPessoas, out clienteNIF, out quartoID, out precoTotal))
            {
                Cliente cliente = new Cliente { NIF = clienteNIF };
                Quarto quarto = new Quarto { ID = quartoID };
                Reserva reserva = new Reserva(id, dataInicio, dataFim, numPessoas, cliente, quarto, precoTotal);

                var quartoEscolhido = Quartos.QUARTO.FirstOrDefault(q => q.ID == quartoID);

                quantPessoas = quartos.ObterQuant(quartoEscolhido.Tipo);

                if (numPessoas > quantPessoas)
                {
                    Console.Clear();
                    Console.WriteLine("Número de pessoas excede a capacidade do quarto.");
                    Console.WriteLine();
                    return false;
                }

                reservas.InserirReserva(reserva);
                return true;
            }

            return false;
        }

        public bool InserirReservaA()
        {
            Reservas reservas = new Reservas();
            Clientes clientes = new Clientes();
            Quartos quartos = new Quartos();
            IO io = new IO();
            int id;
            DateTime dataInicio;
            DateTime dataFim;
            int numPessoas;
            int clienteNIF;
            int quartoID;
            int quantPessoas;
            decimal precoTotal;

            Random random = new Random();

            // Loop para gerar um ID de reserva único
            do
            {
                id = random.Next(1, 100); // Defina o intervalo conforme necessário
            } while (reservas.ExisteReserva(id));

            // Verifica se io.InserirReservaA foi bem-sucedido antes de prosseguir
            if (io.InserirReservaA(out dataInicio, out dataFim, out numPessoas, out clienteNIF, out quartoID, out precoTotal))
            {
                if (clientes.ExisteCliente(clienteNIF))
                {
                    Cliente cliente = new Cliente { NIF = clienteNIF };
                    Quarto quarto = new Quarto { ID = quartoID };
                    Reserva reserva = new Reserva(id, dataInicio, dataFim, numPessoas, cliente, quarto, precoTotal);

                    var quartoEscolhido = Quartos.QUARTO.FirstOrDefault(q => q.ID == quartoID);

                    quantPessoas = quartos.ObterQuant(quartoEscolhido.Tipo);

                    if (numPessoas > quantPessoas)
                    {
                        Console.Clear();
                        Console.WriteLine("Número de pessoas excede a capacidade do quarto.");
                        Console.WriteLine();
                        return false;
                    }

                    reservas.InserirReserva(reserva);
                    return true;
                }
                Console.Clear();
                Console.WriteLine("Não existe nenhum cliente com o NIF indicado");
                Console.WriteLine();
            }

            return false;
        }

        public bool RemoverReservaC()
        {
            Reservas reservas = new Reservas();
            IO io = new IO();
            int id;
            io.RemoverReservaC(out id);

            if (reservas.ExisteReserva(id))
            {
                Reserva reserva = new Reserva();
                reserva.ID = id;

                reservas.RemoverReserva(reserva);
                return true;
            }
            Console.Clear();
            Console.WriteLine("Reserva não encontrada ou não removida. ID não existe.");
            Console.WriteLine();
            return false;
        }

        public bool RemoverReservaA()
        {
            Reservas reservas = new Reservas();
            IO io = new IO();
            int id;
            io.RemoverReservaA(out id);

            if (reservas.ExisteReserva(id))
            {
                Reserva reserva = new Reserva();
                reserva.ID = id;

                reservas.RemoverReserva(reserva);
                return true;
            }
            Console.Clear();
            Console.WriteLine("Reserva não encontrada ou não removida. ID não existe.");
            Console.WriteLine();
            return false;
        }

        public bool ListarReserva()
        {
            Reservas reservas = new Reservas();
            reservas.ListarReserva();
            return true;
        }

        public bool GravarReserva(string r)
        {
            Reservas reservas = new Reservas();
            reservas.GravarReserva(r);
            return true;
        }

        public bool LerReserva(string r)
        {
            Reservas reservas = new Reservas();
            reservas.LerReserva(r);
            return true;
        }

        #endregion

        #region CHECK_INS

        public bool InserirCheck_I()
        {
            Reservas reservas = new Reservas();
            Check_Ins check_ins = new Check_Ins();
            IO io = new IO();
            int id;
            DateTime dataCheck_I;
            DateTime dataInicio;
            DateTime dataFim;
            int reservaID;

            Random random = new Random();

            // Loop para gerar um ID de check_in único
            do
            {
                id = random.Next(1, 100); // Defina o intervalo conforme necessário
            } while (check_ins.ExisteCheck_I(id));

            io.InserirCheck_I(out reservaID, out dataCheck_I);
            if (check_ins.ExisteCheck_I(id) == false)
            {
                if (reservas.ExisteReserva(reservaID))
                {
                    Reserva reserva = new Reserva { ID = reservaID };
                    CheckIn checkin = new CheckIn(id, reserva, dataCheck_I);

                    var reservaEscolhida = Reservas.RESERVA.FirstOrDefault(r => r.ID == reservaID);

                    dataInicio = reservaEscolhida.DataInicio;
                    dataFim = reservaEscolhida.DataFim;

                    if (dataCheck_I < dataInicio || dataCheck_I > dataFim)
                    {
                        Console.Clear();
                        Console.WriteLine("Não é possível efetuar check-In para a data desejada");
                        Console.WriteLine();
                        return false;
                    }

                    check_ins.InserirCheck_I(checkin);
                    return true;
                }
                Console.Clear();
                Console.WriteLine("Não existe nenhuma reserva com o ID indicado");
                Console.WriteLine();
            }

            return false;
        }

        public bool GravarCheck_I(string ci)
        {
            Check_Ins check_ins = new Check_Ins();
            check_ins.GravarCheck_I(ci);
            return true;
        }

        public bool LerCheck_I(string ci)
        {
            Check_Ins check_ins = new Check_Ins();
            check_ins.LerCheck_I(ci);
            return true;
        }

        #endregion
    }
}
