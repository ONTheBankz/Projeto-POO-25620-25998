using System;
using System.Collections.Generic;
using System.Linq;
using DLL_Objetos;
using DLL_Dados;
using TP_POO_25620_25998;
using DLL_Exceptions;
using System.Runtime.InteropServices.ComTypes;
using System.Net.Http.Headers;

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
            Console.WriteLine("Cliente não encontrado ou removido. NIF não existe.");
            Console.WriteLine();
            return false;
        }

        public bool EditarCliente()
        {
            IO io = new IO();
            Clientes clientes = new Clientes();
            int op = 0;
            int nif = 0;
            int NIFC = 0;
            int contacto = 0;
            string nome = string.Empty;
            string morada = string.Empty;
            string email = string.Empty;
            string password = string.Empty;
            DateTime datanasc = DateTime.MinValue;

            io.EditarCliente(out op, out nome, out morada, out email, out password, out contacto, out datanasc, out nif, out NIFC);

            clientes.EditarCliente(op, nome, morada, email, password, contacto, datanasc, nif, NIFC);

            return true;
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
            Console.WriteLine("Cliente não encontrado ou removido. NIF não existe.");
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
            Console.WriteLine("Funcionário não encontrado ou removido. ID não existe.");
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
            Console.WriteLine("Quarto não encontrado ou removido. ID não existe.");
            Console.WriteLine();
            return false;
        }

        public bool ListarQuartos()
        {
            Quartos quartos = new Quartos();
            quartos.ListarQuartos();
            return true;
        }

        public bool ListarQuartosF()
        {
            IO io = new IO();
            io.ListarQuartoF();
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
            int id = 0;
            int numPessoas;
            int clienteNIF;
            int quartoID;
            int quantPessoas;
            DateTime dataInicio;
            DateTime dataFim;
            decimal precoTotal;
            decimal valorQuarto;

            id = reservas.ID(id);

            // Verifica se io.InserirReservaC foi bem-sucedida antes de prosseguir
            if (!io.InserirReservaC(out dataInicio, out dataFim, out numPessoas, out clienteNIF, out quartoID, out precoTotal))
            {
                return false;
            }

            try
            {
                Cliente cliente = new Cliente { NIF = clienteNIF };
                Quarto quarto = new Quarto { ID = quartoID };

                var quartoEscolhido = Quartos.QUARTO.FirstOrDefault(q => q.ID == quartoID);

                quantPessoas = quartos.ObterQuant(quartoEscolhido.Tipo);

                if (dataInicio == dataFim || dataInicio > dataFim)
                {
                    Console.Clear();
                    Console.WriteLine("Datas de reserva inválidas.");
                    Console.WriteLine();
                    return false;
                }

                if (numPessoas > quantPessoas)
                {
                    Console.Clear();
                    Console.WriteLine("Número de pessoas excede a capacidade do quarto.");
                    Console.WriteLine();
                    return false;
                }

                valorQuarto = quartoEscolhido.Valor;

                // Lógica para calcular o preço total da reserva
                int numDias = (int)(dataFim - dataInicio).TotalDays;
                decimal preco = valorQuarto * numDias;
                Console.WriteLine();
                Console.WriteLine($"Preço total da reserva: {preco}");
                Console.WriteLine();
                precoTotal = preco;

                Reserva reserva = new Reserva(id, dataInicio, dataFim, numPessoas, cliente, quarto, precoTotal);
                reservas.InserirReserva(reserva);
                return true;
            }

            catch (EReserva r)
            {
                throw new EReserva("Erro ao criar reserva" + "-" + r.Message);
            }
        }

        public bool InserirReservaA()
        {
            Reservas reservas = new Reservas();
            Clientes clientes = new Clientes();
            Quartos quartos = new Quartos();
            IO io = new IO();
            int id = 0;
            int numPessoas;
            int clienteNIF;
            int quartoID;
            int quantPessoas;
            DateTime dataInicio;
            DateTime dataFim;
            decimal precoTotal;
            decimal valorQuarto;

            id = reservas.ID(id);

            // Verifica se io.InserirReservaA foi bem-sucedida antes de prosseguir
            if (!io.InserirReservaA(out dataInicio, out dataFim, out numPessoas, out clienteNIF, out quartoID, out precoTotal))
            {
                return false;
            }

            try
            {
                if (clientes.ExisteCliente(clienteNIF))
                {
                    Cliente cliente = new Cliente { NIF = clienteNIF };
                    Quarto quarto = new Quarto { ID = quartoID };

                    var quartoEscolhido = Quartos.QUARTO.FirstOrDefault(q => q.ID == quartoID);

                    quantPessoas = quartos.ObterQuant(quartoEscolhido.Tipo);

                    if (dataInicio == dataFim || dataInicio > dataFim)
                    {
                        Console.Clear();
                        Console.WriteLine("Datas de reserva inválidas.");
                        Console.WriteLine();
                        return false;
                    }

                    if (numPessoas > quantPessoas)
                    {
                        Console.Clear();
                        Console.WriteLine("Número de pessoas excede a capacidade do quarto.");
                        Console.WriteLine();
                        return false;
                    }

                    valorQuarto = quartoEscolhido.Valor;

                    // Lógica para calcular o preço total da reserva
                    int numDias = (int)(dataFim - dataInicio).TotalDays;
                    decimal preco = valorQuarto * numDias;
                    Console.WriteLine();
                    Console.WriteLine($"Preço total da reserva: {preco}");
                    Console.WriteLine();
                    precoTotal = preco;

                    Reserva reserva = new Reserva(id, dataInicio, dataFim, numPessoas, cliente, quarto, precoTotal);
                    reservas.InserirReserva(reserva);
                    return true;
                }

                Console.Clear();
                Console.WriteLine("Não existe nenhum cliente com o NIF indicado");
                Console.WriteLine();
                return false;
            }

            catch (EReserva r)
            {
                throw new EReserva("Erro ao criar reserva" + "-" + r.Message);
            }
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
            Console.WriteLine("Reserva não encontrada ou removida. ID não existe.");
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
            Console.WriteLine("Reserva não encontrada ou removida. ID não existe.");
            Console.WriteLine();
            return false;
        }

        public bool ListarReservaC()
        {
            IO io = new IO();
            io.ListarReservaC();
            return true;
        }

        public bool ListarReservaA()
        {
            IO io = new IO();
            io.ListarReservaA();
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
            DateTime dataCheck_I;
            DateTime dataInicio;
            DateTime dataFim;
            int reservaID;
            int id = 0;

            id = check_ins.ID(id);

            io.InserirCheck_I(out reservaID, out dataCheck_I);

            try
            {
                if (reservas.ExisteReserva(reservaID))
                {
                    Reserva reserva = new Reserva { ID = reservaID };
                   
                    foreach (var check_in in Check_Ins.CHECKIN)
                    {
                        if (check_in.Reserva.ID == reservaID)
                        {
                            Console.Clear();
                            Console.WriteLine("Já existe um check-In para a reserva desejada");
                            Console.WriteLine();
                            return false;
                        }
                    }

                    var reservaEscolhida = Reservas.RESERVA.FirstOrDefault(r => r.ID == reservaID);

                    dataInicio = reservaEscolhida.DataInicio;
                    dataFim = reservaEscolhida.DataFim;

                    if (dataCheck_I < dataInicio || dataCheck_I >= dataFim)
                    {
                        Console.Clear();
                        Console.WriteLine("Não é possível efetuar check-In para a data desejada");
                        Console.WriteLine();
                        return false;
                    }

                    CheckIn checkin = new CheckIn(id, reserva, dataCheck_I);
                    check_ins.InserirCheck_I(checkin);
                    return true;
                }
                Console.Clear();
                Console.WriteLine("Não existe nenhuma reserva com o ID indicado");
                Console.WriteLine();
                return false;
            }

            catch (ECheck_In ci)
            {
                throw new ECheck_In("Erro ao criar check IN" + "-" + ci.Message);
            }
        }

        public bool RemoverCheck_I()
        {
            Check_Ins check_ins = new Check_Ins();
            IO io = new IO();
            int id;
            io.RemoverCheck_I(out id);

            if (check_ins.ExisteCheck_I(id))
            {
                CheckIn checkin = new CheckIn();
                checkin.ID = id;

                check_ins.RemoverCheck_I(checkin);

                return true;
            }
            Console.Clear();
            Console.WriteLine("Check IN não encontrado ou removido. ID não existe.");
            Console.WriteLine();
            return false;
        }

        public bool ListarCheck_I()
        {
            Check_Ins check_ins = new Check_Ins();
            check_ins.ListarCheck_I();
            return true;
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

        #region CHECK_OUTS

        public bool InserirCheck_O()
        {
            Check_Ins check_ins = new Check_Ins();
            Check_Outs check_outs = new Check_Outs();
            IO io = new IO();
            DateTime dataCheck_O;
            DateTime dataCI;
            DateTime reservaData;
            int checkIN;
            int reservaTemp;
            int id = 0;

            id = check_outs.ID(id);

            io.InserirCheck_O(out checkIN, out dataCheck_O);

            try
            {
                if (check_ins.ExisteCheck_I(checkIN))
                {
                    CheckIn checkin = new CheckIn { ID = checkIN };

                    foreach (var check_out in Check_Outs.CHECKOUT)
                    {
                        if (check_out.Check_In.ID == checkIN)
                        {
                            Console.Clear();
                            Console.WriteLine("Já existe um check-Out para a reserva desejada");
                            Console.WriteLine();
                            return false;
                        }
                    }

                    var checkinEscolhido = Check_Ins.CHECKIN.FirstOrDefault(ci => ci.ID == checkIN);

                        dataCI = checkinEscolhido.DataCheckIO;
                        reservaTemp = checkinEscolhido.Reserva.ID;

                    var reservaCI = Reservas.RESERVA.FirstOrDefault(r => r.ID == reservaTemp);

                        reservaData = reservaCI.DataFim;
                   
                    if (dataCheck_O <= dataCI || dataCheck_O > reservaData)
                    {
                        Console.Clear();
                        Console.WriteLine("Não é possível efetuar check-Out para a data desejada");
                        Console.WriteLine();
                        return false;
                    }

                    CheckOut checkout = new CheckOut(id, checkin, dataCheck_O);
                    check_outs.InserirCheck_O(checkout);
                    return true;
                }
                Console.Clear();
                Console.WriteLine("Não existe nenhum check-IN com o ID indicado");
                Console.WriteLine();
                return false;
            }

            catch (ECheck_Out co)
            {
                throw new ECheck_Out("Erro ao criar check OUT" + "-" + co.Message);
            }
        }

        public bool RemoverCheck_O()
        {
            Check_Outs check_outs = new Check_Outs();
            IO io = new IO();
            int id;
            io.RemoverCheck_O(out id);

            if (check_outs.ExisteCheck_O(id))
            {
                CheckOut checkout = new CheckOut();
                checkout.ID = id;

                check_outs.RemoverCheck_O(checkout);

                return true;
            }
            Console.Clear();
            Console.WriteLine("Check OUT não encontrado ou removido. ID não existe.");
            Console.WriteLine();
            return false;
        }

        public bool ListarCheck_O()
        {
            Check_Outs check_outs = new Check_Outs();
            check_outs.ListarCheck_O();
            return true;
        }

        public bool GravarCheck_O(string co)
        {
            Check_Outs check_outs = new Check_Outs();
            check_outs.GravarCheck_O(co);
            return true;
        }

        public bool LerCheck_O(string co)
        {
            Check_Outs check_outs = new Check_Outs();
            check_outs.LerCheck_O(co);
            return true;
        }

        #endregion
    }
}
