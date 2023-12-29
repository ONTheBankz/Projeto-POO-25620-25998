using System;
using System.Collections.Generic;
using System.Linq;

using DLL_Objetos;
using DLL_Dados;
using DLL_Exceptions;

namespace TP_POO_25620_25998
{
    public class IO
    {
        private static int NIFClienteLogin;
        private static int IDFunc;

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

            Console.WriteLine();
            Console.WriteLine("Insira a morada do cliente");
            morada = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine("Insira o email do cliente");
            email = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine("Insira a password do cliente");
            password = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine("Insira o contacto do cliente");
            contacto = int.Parse(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine("Insira a data nascimento do cliente");
            dataNascimento = DateTime.Parse(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine("Insira o nif do cliente");
            nif = int.Parse(Console.ReadLine());
            Console.WriteLine();
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
            Console.WriteLine();
        }

        public bool EditarCliente(out int op, out string nome, out string morada, out string email, out string password, out int contacto, out DateTime datanasc, out int nif, out int NIFC)
        {
            op = 0;
            NIFC = 0;
            int opção;
            nome = string.Empty;
            morada = string.Empty;
            email = string.Empty;
            password = string.Empty;
            contacto = 0;
            datanasc = DateTime.MinValue;
            nif = 0;
          
            Console.WriteLine("Insira o NIF do Cliente: ");
            NIFC = int.Parse(Console.ReadLine());

            Console.WriteLine("O que pretende alterar: (1 - nome, 2 - morada, 3 - email, 4 - password, 5 - contacto, 6 - data de nascimento, 7 - NIF ");
            opção = int.Parse(Console.ReadLine());

            op = opção; // Defina a opção escolhida

            switch (opção)
            {
                case 1:
                    Console.WriteLine("Insira o novo nome: ");
                    nome = Console.ReadLine();
                    return true;

                case 2:
                    Console.WriteLine("Insira a nova morada: ");
                    morada = Console.ReadLine();
                    return true;

                case 3:
                    Console.WriteLine("Insira o novo email: ");
                    email = Console.ReadLine();
                    return true;

                case 4:
                    Console.WriteLine("Insira a nova password: ");
                    password = Console.ReadLine();
                    return true;

                case 5:
                    Console.WriteLine("Insira o novo contacto: ");
                    contacto = int.Parse(Console.ReadLine());
                    return true;

                case 6:
                    Console.WriteLine("Insira a nova data de nascimento (formato: dd/mm/yyyy): ");
                    datanasc = DateTime.Parse(Console.ReadLine());
                    return true;

                case 7:
                    Console.WriteLine("Insira o novo NIF: ");
                    nif = int.Parse(Console.ReadLine());
                    return true;

                default:
                    // Operação não suportada
                    Console.WriteLine("Operação não suportada.");
                    return false;
            }
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

            Console.WriteLine();
            Console.WriteLine("Insira o nome do funcionario");
            nome = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine("Insira o email do funcionario");
            email = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine("Insira a password do funcionario");
            password = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine("Insira o contacto do funcionario");
            contacto = int.Parse(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine("Insira a data nascimento do funcionario");
            dataNascimento = DateTime.Parse(Console.ReadLine());

            Console.WriteLine();
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
            Console.WriteLine();
        }

        public void LoginFunc(out string password, out int id)
        {
            password = string.Empty;
            id = 0;

            Console.WriteLine("Insira o ID do funcionário");
            id = int.Parse(Console.ReadLine());

            Console.WriteLine("Insira a password do funcionário");
            password = Console.ReadLine();

            IDFunc = id;
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

            Console.WriteLine();
            Console.WriteLine("Insira o nome do alojamento");
            nomeAlojamento = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine("Insira o tipo do alojamento");
            tipoAlojamento = Console.ReadLine();

            Console.WriteLine();
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
            Console.WriteLine();
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

            Console.WriteLine();
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

            Console.WriteLine();
            Console.WriteLine("Insira a disponibilidade (S/N)");
            string disponibilidadeInput = Console.ReadLine();

            disponibilidade = (disponibilidadeInput.Trim().ToUpper() == "S");

            if (!disponibilidade && disponibilidadeInput.Trim().ToUpper() != "N")
            {
                Console.WriteLine("Valor inválido. Insira S ou N.");
            }

            Console.WriteLine();
            Console.WriteLine("Insira o valor por noite do quarto");
            valor = decimal.Parse(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine("Escolha um alojamento:");

            foreach (var alojamento in Alojamentos.ALOJAMENTO)
            {
                Console.WriteLine($"{alojamento.ID}: {alojamento.Nome}");
            }

            alojamentoID = int.Parse(Console.ReadLine());
        }

        public void ListarQuartoF()
        {
            Quartos quartos = new Quartos(); // Cria uma instância de Quartos.

            foreach (var quarto in Quartos.QUARTO)
            {
                // Verifica se o quarto pertence ao alojamento do funcionário
                if (Funcionarios.FUNCIONARIO.Any(f => f.ID == IDFunc && f.Alojamento.ID == quarto.Alojamento.ID))
                {
                    Console.WriteLine("ID Quarto: {0}\nTipo Quarto: {1}\nDisponibilidade: {2}\nValor por Noite: {3}\nID Alojamento: {4}\n",
                                 quarto.ID, quarto.Tipo, quarto.Disponibilidade, quarto.Valor, quarto.Alojamento.ID);
                }
            }
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
            Console.WriteLine();
        }

        #endregion

        #region RESERVAS

        public bool InserirReservaC(out DateTime dataInicio, out DateTime dataFim, out int numPessoas, out int clienteNIF, out int quartoID, out decimal PrecoTotal)
        {
            string tipoQ;
            decimal valorQ;
            int idQ;
            int alojQ;        
            PrecoTotal = 0;
            clienteNIF = NIFClienteLogin;

            // Títulos para datas e Nº de Pessoas
            Console.WriteLine("Insira a data de início da reserva (formato dd/MM/yyyy)");
            dataInicio = DateTime.Parse(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine("Insira a data de fim da reserva (formato dd/MM/yyyy)");
            dataFim = DateTime.Parse(Console.ReadLine());

            Console.WriteLine();
            Console.Write("Digite o Nº de Pessoas: ");
            numPessoas = int.Parse(Console.ReadLine());

            Console.WriteLine("QUARTOS");
            Console.WriteLine();
            Console.WriteLine("{0,-20} {1,-20} {2,-20} {3,-20} {4,-20}", "ID do Quarto", "Tipo do Quarto", "Valor Estadia", "Nome Alojamento", "Tipo Alojamento");

            // Mostrar todos os quartos disponíveis
            foreach (var quarto in Quartos.QUARTO.Where(q => q.Disponibilidade == true))
            {
                idQ = quarto.ID;
                tipoQ = quarto.Tipo;
                valorQ = quarto.Valor;
                alojQ = quarto.Alojamento.ID;

                // Mostrar informações do quarto
                foreach (var alojamento in Alojamentos.ALOJAMENTO.Where(a => a.ID == alojQ))
                {
                    Console.WriteLine("{0,-20} {1,-20} {2,-20} {3,-20} {4,-20}", idQ, tipoQ, valorQ, alojamento.Nome, alojamento.Tipo);
                }
            }

            Console.WriteLine();
            Console.Write("Digite o ID do quarto: ");
            quartoID = int.Parse(Console.ReadLine());

            return true;
        }

        public bool InserirReservaA(out DateTime dataInicio, out DateTime dataFim, out int numPessoas, out int clienteNIF, out int quartoID, out decimal PrecoTotal)
        {
            bool QuartoDisp = false;
            PrecoTotal = 0;

            // Títulos para CLIENTES
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("CLIENTES");
            Console.WriteLine();
            Console.WriteLine("{0,-20} {1,-20}", "Nome do Cliente", "NIF do Cliente");

            foreach (var cliente in Clientes.CLIENTE)
            {
                Console.WriteLine("{0,-20} {1,-20}", cliente.Nome, cliente.NIF);
            }

            // Obtém NIF do cliente
            Console.WriteLine();
            Console.Write("Digite o NIF do cliente: ");
            clienteNIF = int.Parse(Console.ReadLine());

            // Títulos para ALOJAMENTOS
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("ALOJAMENTOS");
            Console.WriteLine();
            Console.WriteLine("{0,-20} {1,-20}", "Nome do Alojamento", "ID do Alojamento");

            foreach (var alojamento in Alojamentos.ALOJAMENTO)
            {
                Console.WriteLine("{0,-20} {1,-20}", alojamento.Nome, alojamento.ID);
            }

            Console.WriteLine();
            Console.Write("Digite o ID do alojamento: ");
            var alojamentoA = int.Parse(Console.ReadLine());

            // Títulos para datas e Nº de Pessoas
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("Insira a data de início da reserva (formato dd/MM/yyyy)");
            dataInicio = DateTime.Parse(Console.ReadLine());

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("Insira a data de fim da reserva (formato dd/MM/yyyy)");
            dataFim = DateTime.Parse(Console.ReadLine());

            Console.Clear();
            Console.WriteLine();
            Console.Write("Digite o Nº de Pessoas: ");
            numPessoas = int.Parse(Console.ReadLine());

            // Títulos para QUARTOS
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("QUARTOS");
            Console.WriteLine();
            Console.WriteLine("{0,-20} {1,-20} {2,-20}", "Tipo do Quarto", "ID do Quarto", "Valor Estadia (por dia)");

            foreach (var quarto in Quartos.QUARTO.Where(q => q.Alojamento.ID == alojamentoA && q.Disponibilidade == true))
            {
                Console.WriteLine("{0,-20} {1,-20} {2,-20}", quarto.Tipo, quarto.ID, quarto.Valor);
                QuartoDisp = true;
            }

            if (!QuartoDisp)
            {
                Console.Clear();
                Console.WriteLine("Não há quartos disponíveis para o alojamento selecionado.");
                Console.WriteLine();
                quartoID = 0;
                return false;
            }

            Console.WriteLine();
            Console.Write("Digite o ID do quarto: ");
            quartoID = int.Parse(Console.ReadLine());

            return true;
        }

        public void RemoverReservaC(out int id)
        {
            int clienteNIF = NIFClienteLogin;
            id = 0;

            Console.WriteLine("Insira o ID da reserva que deseja remover");
            Console.WriteLine();
            Console.WriteLine("{0,-20} {1,-20} {2,-20} {3,-20} {4,-20} {5,-20}", "ID da Reserva", "NIF do Cliente", "Data de Início", "Data de Fim",
                "ID do Quarto", "Preço Final");

            foreach (var reserva in Reservas.RESERVA.Where(r => r.Cliente.NIF == clienteNIF))
            {
                Console.WriteLine("{0,-20} {1,-20} {2,-20} {3,-20} {4,-20} {5,-20}", reserva.ID, reserva.Cliente.NIF, reserva.DataInicio.ToShortDateString(),
                    reserva.DataFim.ToShortDateString(), reserva.Quarto.ID, reserva.PrecoTotal);
            }

            Console.WriteLine();
            Console.Write("Digite o ID do reserva: ");
            id = int.Parse(Console.ReadLine());
            Console.WriteLine();
        }

        public void RemoverReservaA(out int id)
        {
            id = 0;

            Console.WriteLine("Insira o ID da reserva que deseja remover");
            Console.WriteLine();
            Console.WriteLine("{0,-20} {1,-20} {2,-20} {3,-20} {4,-20} {5,-20}", "ID da Reserva", "NIF do Cliente", "Data de Início", "Data de Fim",
                "ID do Quarto", "Preço Final");

            foreach (var reserva in Reservas.RESERVA)
            {
                Console.WriteLine("{0,-20} {1,-20} {2,-20} {3,-20} {4,-20} {5,-20}", reserva.ID, reserva.Cliente.NIF, reserva.DataInicio.ToShortDateString(),
                    reserva.DataFim.ToShortDateString(), reserva.Quarto.ID, reserva.PrecoTotal);
            }

            Console.WriteLine();
            Console.Write("Digite o ID do reserva: ");
            id = int.Parse(Console.ReadLine());
            Console.WriteLine();
        }
        
        public bool ListarReservaC()
        {
            Reservas reservas = new Reservas(); // Crie uma instância de Reservas.
            reservas.OrdenarReserva(); // Chama o método de ordenação antes de listar as reservas.

            foreach (var reserva in Reservas.RESERVA.Where(r => r.Cliente.NIF == NIFClienteLogin))
            {
                Console.WriteLine("ID Reserva: {0}\nData Início: {1}\nData Fim: {2}\nNº Pessoas: {3}\nNIF Cliente: {4}\nID Quarto: {5}\nPreço Total: {6}\n",
                                 reserva.ID, reserva.DataInicio.ToShortDateString(), reserva.DataFim.ToShortDateString(), reserva.NumPessoas, reserva.Cliente.NIF,
                                 reserva.Quarto.ID, reserva.PrecoTotal);
            }
            return true;
        }

        public bool ListarReservaA()
        {
            Reservas reservas = new Reservas(); // Crie uma instância de Reservas.
            reservas.OrdenarReserva(); // Chama o método de ordenação antes de listar as reservas.

            foreach (var reserva in Reservas.RESERVA)
            {
                Console.WriteLine("ID Reserva: {0}\nData Início: {1}\nData Fim: {2}\nNº Pessoas: {3}\nNIF Cliente: {4}\nID Quarto: {5}\nPreço Total: {6}\n",
                                 reserva.ID, reserva.DataInicio.ToShortDateString(), reserva.DataFim.ToShortDateString(), reserva.NumPessoas, reserva.Cliente.NIF,
                                 reserva.Quarto.ID, reserva.PrecoTotal);
            }
            return true;
        }

        #endregion

        #region CHECK_INS

        public void InserirCheck_I(out int reservaID, out DateTime dataCheck_I)
        {
            reservaID = 0;
            dataCheck_I = DateTime.MinValue;

            // Títulos para RESERVAS
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("RESERVAS");
            Console.WriteLine();
            Console.WriteLine("{0,-20} {1,-20} {2,-20} {3,-20}", "ID da Reserva", "NIF do Cliente", "Data Início", "Data Fim");

            foreach (var reserva in Reservas.RESERVA)
            {
                // Verifica se a reserva não tem check-ins associados
                if (!Check_Ins.CHECKIN.Any(ci => ci.Reserva.ID == reserva.ID))
                {
                    Console.WriteLine("{0,-20} {1,-20} {2,-20} {3,-20}", reserva.ID, reserva.Cliente.NIF, reserva.DataInicio.ToShortDateString(),
                        reserva.DataFim.ToShortDateString());
                }
            }

            Console.WriteLine();
            Console.WriteLine("Insira o ID da reserva");
            reservaID = int.Parse(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine("Insira a data de Check IN do cliente");
            dataCheck_I = DateTime.Parse(Console.ReadLine());
            Console.WriteLine();
        }

        public void RemoverCheck_I(out int id)
        {
            id = 0;

            Console.WriteLine("Insira o ID do Check IN que deseja remover");
            Console.WriteLine();
            Console.WriteLine("{0,-20} {1,-20} {2,-20}", "ID do Check IN", "ID da Reserva", "Data do Check IN");

            foreach (var check_in in Check_Ins.CHECKIN)
            {
                Console.WriteLine("{0,-20} {1,-20} {2,-20}", check_in.ID, check_in.Reserva.ID, check_in.DataCheckIO.ToShortDateString());
            }

            Console.WriteLine();
            Console.Write("Digite o ID do Check IN: ");
            id = int.Parse(Console.ReadLine());
            Console.WriteLine();
        }

        #endregion

        #region CHECK_OUTS

        public void InserirCheck_O(out int checkIN, out DateTime dataCheck_O)
        {
            checkIN = 0;
            dataCheck_O = DateTime.MinValue;

            // Títulos para CHECK_INS
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("CHECK-INS");
            Console.WriteLine();
            Console.WriteLine("{0,-20} {1,-20} {2,-20}", "ID do Check-IN", "ID da Reserva", "Data do Check-IN");

            foreach (var check_i in Check_Ins.CHECKIN)
            {
                // Verifica se a reserva não tem check-ins associados
                if (!Check_Outs.CHECKOUT.Any(co => co.Check_In.ID == check_i.ID))
                {
                    Console.WriteLine("{0,-20} {1,-20} {2,-20}", check_i.ID, check_i.Reserva.ID, check_i.DataCheckIO.ToShortDateString());
                    }
            }

            Console.WriteLine();
            Console.WriteLine("Insira o ID do check-IN");
            checkIN = int.Parse(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine("Insira a data de Check OUT do cliente");
            dataCheck_O = DateTime.Parse(Console.ReadLine());
            Console.WriteLine();
        }

        public void RemoverCheck_O(out int id)
        {
            id = 0;

            Console.WriteLine("Insira o ID do Check OUT que deseja remover");
            Console.WriteLine();
            Console.WriteLine("{0,-20} {1,-20} {2,-20}", "ID do Check OUT", "ID do Check IN", "Data do Check OUT");

            foreach (var check_out in Check_Outs.CHECKOUT)
            {
                Console.WriteLine("{0,-20} {1,-20} {2,-20}", check_out.ID, check_out.Check_In.ID, check_out.DataCheckIO.ToShortDateString());
            }

            Console.WriteLine();
            Console.Write("Digite o ID do Check OUT: ");
            id = int.Parse(Console.ReadLine());
            Console.WriteLine();
        }

        #endregion
    }
}

