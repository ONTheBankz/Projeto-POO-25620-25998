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
        // Variável static que guarda o nif do cliente que fez login no sistema
        private static int NIFClienteLogin;
        // Variável static que guarda o ID do funcionário que fez login no sistema
        private static int IDFunc;

        #region CLIENTES

        /// <summary>
        /// Insere informações de um cliente.
        /// </summary>
        /// <param name="nome"> Nome do cliente. </param>
        /// <param name="morada"> Morada do cliente. </param>
        /// <param name="email"> Email do cliente. </param>
        /// <param name="password"> Password do cliente. </param>
        /// <param name="contacto"> Contacto do cliente. </param>
        /// <param name="dataNascimento"> Data de nascimento do cliente. </param>
        /// <param name="nif"> Número de identificação fiscal do cliente. </param>
        public void InserirCliente(out string nome, out string morada, out string email, out string password, out int contacto, out DateTime dataNascimento, out int nif)
        {
            // Inicialização das variáveis
            nome = string.Empty;
            morada = string.Empty;
            email = string.Empty;
            password = string.Empty;
            contacto = 0;
            dataNascimento = DateTime.MinValue;
            nif = 0;

            // Solicitação e atribuição de valores para as variáveis 
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

        /// <summary>
        /// Remove um cliente com base no NIF fornecido.
        /// </summary>
        /// <param name="nif"> Número de identificação fiscal do cliente a ser removido. </param>
        public void RemoverCliente(out int nif)
        {
            // Inicializa o parâmetro NIF.
            nif = 0;

            // Mostra mensagens de instrução para o cliente.
            Console.WriteLine("Insira o NIF do cliente que deseja remover");
            Console.WriteLine();
            Console.WriteLine("{0,-20} {1,-20}", "Nome do Cliente", "NIF do Cliente");

            // Percorre a lista de clientes.
            foreach (var cliente in Clientes.CLIENTE)
            {
                // Mostra informações sobre cada cliente formatadas em colunas.
                Console.WriteLine("{0,-20} {1,-20}", cliente.Nome, cliente.NIF);
            }

            Console.WriteLine();

            // Solicita ao cliente que digite o NIF a ser removido.
            Console.Write("Digite o NIF do cliente: ");

            // Lê a entrada do cliente e armazena o valor lido na variável NIF.
            nif = int.Parse(Console.ReadLine());

            Console.WriteLine();
        }

        /// <summary>
        /// Permite ao administrador editar informações de um cliente com base no NIF fornecido.
        /// </summary>
        /// <param name="op"> Opção escolhida para edição. </param>
        /// <param name="nome"> Novo nome do cliente. </param>
        /// <param name="morada"> Nova morada do cliente. </param>
        /// <param name="email"> Novo email do cliente. </param>
        /// <param name="password"> Nova password do cliente. </param>
        /// <param name="contacto"> Novo contacto do cliente. </param>
        /// <param name="datanasc"> Nova data de nascimento do cliente. </param>
        /// <param name="nif"> Novo número de identificação fiscal do cliente. </param>
        /// <param name="NIFC"> NIF do cliente a ser editado. </param>
        /// <returns> Retorna verdadeiro se a edição for bem-sucedida, falso caso contrário. </returns>
        public bool EditarClienteA(out int op, out string nome, out string morada, out string email, out string password, out int contacto, out DateTime datanasc, out int nif, out int NIFC)
        {
            // Inicialização das variáveis.
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

            // Exibe títulos para a lista de clientes.
            Console.WriteLine();
            Console.WriteLine("CLIENTES");
            Console.WriteLine();
            Console.WriteLine("{0,-20} {1,-20}", "Nome do Cliente", "NIF do Cliente");

            // Exibe a lista de clientes com os seus nomes e NIFs.
            foreach (var cliente in Clientes.CLIENTE)
            {
                Console.WriteLine("{0,-20} {1,-20}", cliente.Nome, cliente.NIF);
            }

            Console.WriteLine();
            Console.WriteLine("Insira o NIF do Cliente: ");

            // Lê o NIF do cliente a ser editado.
            NIFC = int.Parse(Console.ReadLine());
            Console.WriteLine();

            Console.WriteLine("O que pretende alterar: (1 - nome, 2 - morada, 3 - email, 4 - password, 5 - contacto, 6 - data de nascimento, 7 - NIF ");
            opção = int.Parse(Console.ReadLine());
            Console.WriteLine();

            op = opção; // Define a opção escolhida

            // Realiza a edição com base na opção escolhida.
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

        /// <summary>
        /// Permite ao cliente editar os seus próprios dados.
        /// </summary>
        /// <param name="op"> Opção escolhida para edição. </param>
        /// <param name="nome"> Novo nome do cliente. </param>
        /// <param name="morada"> Nova morada do cliente. </param>
        /// <param name="email"> Novo email do cliente. </param>
        /// <param name="password"> Nova password do cliente. </param>
        /// <param name="contacto"> Novo contacto do cliente. </param>
        /// <param name="datanasc"> Nova data de nascimento do cliente. </param>
        /// <param name="nif"> Novo número de identificação fiscal do cliente. </param>
        /// <param name="NIFC"> NIF do cliente a ser editado, retirado automaticamente, através do login. </param>
        /// <returns> Retorna verdadeiro se a edição for bem-sucedida, falso caso contrário. </returns>
        public bool EditarClienteC(out int op, out string nome, out string morada, out string email, out string password, out int contacto, out DateTime datanasc, out int nif, out int NIFC)
        {
            // Inicialização das variáveis.
            op = 0;
            int opção;
            nome = string.Empty;
            morada = string.Empty;
            email = string.Empty;
            password = string.Empty;
            contacto = 0;
            datanasc = DateTime.MinValue;
            nif = 0;
            NIFC = NIFClienteLogin; // Variável que contém o NIF do cliente.

            // Exibe as opções de edição disponíveis para o cliente.
            Console.WriteLine("O que pretende alterar: (1 - nome, 2 - morada, 3 - email, 4 - password, 5 - contacto, 6 - data de nascimento, 7 - NIF ");
            opção = int.Parse(Console.ReadLine());
            Console.WriteLine();

            op = opção; // Define a opção escolhida

            // Realiza a edição com base na opção escolhida.
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
       
        /// <summary>
        /// Realiza o login do cliente.
        /// </summary>
        /// <param name="password"> Password do cliente. </param>
        /// <param name="nif"> Número de identificação fiscal do cliente.</param>
        public void LoginCliente(out string password, out int nif)
        {
            password = string.Empty;
            nif = 0;

            Console.WriteLine("Insira o nif do cliente");
            nif = int.Parse(Console.ReadLine());

            Console.WriteLine("Insira a password do cliente");
            password = Console.ReadLine();

            NIFClienteLogin = nif; // Define o NIF do cliente para o login
        }

        #endregion

        #region ADMINS

        /// <summary>
        /// Realiza o login do administrador.
        /// </summary>
        /// <param name="password"> Password do administrador. </param>
        /// <param name="id"> ID do administrador. </param>
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

        /// <summary>
        /// Insere informações de um funcionário.
        /// </summary>
        /// <param name="idFunc"> ID do funcionário. </param>
        /// <param name="nome"> Nome do funcionário. </param>
        /// <param name="email"> Email do funcionário. </param>
        /// <param name="password"> Password do funcionário. </param>
        /// <param name="contacto"> Contacto do funcionário. </param>
        /// <param name="dataNascimento"> Data de nascimento do funcionário. </param>
        /// <param name="alojamentoID"> ID do alojamento onde o funcionário trabalha. </param>
        public void InserirFunc(out int idFunc, out string nome, out string email, out string password, out int contacto, out DateTime dataNascimento, out int alojamentoID)
        {
            // Inicialização das variáveis.
            idFunc = 0;
            nome = string.Empty;
            email = string.Empty;
            password = string.Empty;
            contacto = 0;
            dataNascimento = DateTime.MinValue;
            alojamentoID = 0;

            // Solicitação e atribuição de valores para as variáveis
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

            // Apresenta opções de alojamento disponíveis para o funcionário.
            Console.WriteLine("Escolha um alojamento:");

            foreach (var alojamento in Alojamentos.ALOJAMENTO)
            {
                Console.WriteLine($"{alojamento.ID}: {alojamento.Nome}");
            }

            // Solicita ao utilizador que escolha um alojamento para o funcionário.
            alojamentoID = int.Parse(Console.ReadLine());
        }

        /// <summary>
        /// Remove um funcionário com base no ID fornecido.
        /// </summary>
        /// <param name="id"> ID do funcionário a ser removido. </param>
        public void RemoverFunc(out int id)
        {
            // Inicialização da variável id
            id = 0;

            Console.WriteLine("Insira o ID do funcionário que deseja remover");
            Console.WriteLine();
            Console.WriteLine("{0,-20} {1,-20}", "Nome do Funcionário", "ID do Funcionário");

            // Lista de funcionários no sistema
            foreach (var funcionario in Funcionarios.FUNCIONARIO)
            {
                Console.WriteLine("{0,-20} {1,-20}", funcionario.Nome, funcionario.ID);
            }

            Console.WriteLine();
            Console.Write("Digite o ID do funcionário: ");
            id = int.Parse(Console.ReadLine());
            Console.WriteLine();
        }

        /// <summary>
        /// Permite ao administrador editar informações de um funcionário com base no ID fornecido.
        /// </summary>
        /// <param name="op"> Opção escolhida para edição. </param>
        /// <param name="nome"> Novo nome do funcionário. </param>
        /// <param name="email"> Novo email do funcionário. </param>
        /// <param name="password"> Nova password do funcionário. </param>
        /// <param name="contacto"> Novo contacto do funcionário. </param>
        /// <param name="datanasc"> Nova data de nascimento do funcionário. </param>
        /// <param name="IDF"> ID do funcionário a ser editado. </param>
        /// <param name="alojamentoID"> Novo ID do alojamento onde o funcionário trabalha. </param>
        public void EditarFuncA(out int op, out string nome, out string email, out string password, out int contacto, out DateTime datanasc, out int IDF, out int alojamentoID)
        {
            // Inicialização das variáveis.
            op = 0;
            IDF = 0;
            int opcao;
            nome = string.Empty;
            email = string.Empty;
            password = string.Empty;
            contacto = 0;
            datanasc = DateTime.MinValue;
            alojamentoID = 0;

            // Exibe títulos para a lista de funcionários.
            Console.WriteLine("FUNCIONARIOS");
            Console.WriteLine();
            Console.WriteLine("{0,-20} {1,-20}", "Nome do Funcionario", "ID do Funcionario");

            // Exibe a lista de funcionários com os seus nomes e IDs.
            foreach (var funcionario in Funcionarios.FUNCIONARIO)
            {
                Console.WriteLine("{0,-20} {1,-20}", funcionario.Nome, funcionario.ID);
            }

            Console.WriteLine();
            Console.WriteLine("Insira o ID do Funcionário que deseja editar: ");
            IDF = int.Parse(Console.ReadLine());
            Console.WriteLine();

            Console.WriteLine("O que pretende alterar: (1 - nome, 2 - email, 3 - password, 4 - contacto, 5 - data de nascimento, 6 - ID alojamento)");
            opcao = int.Parse(Console.ReadLine());
            Console.WriteLine();

            op = opcao; // Define a opção escolhida

            // Realiza a edição com base na opção escolhida.
            switch (opcao)
            {
                case 1:
                    Console.WriteLine("Insira o novo nome: ");
                    nome = Console.ReadLine();
                    break;
                case 2:
                    Console.WriteLine("Insira o novo email: ");
                    email = Console.ReadLine();
                    break;
                case 3:
                    Console.WriteLine("Insira a nova password: ");
                    password = Console.ReadLine();
                    break;
                case 4:
                    Console.WriteLine("Insira o novo contacto: ");
                    contacto = int.Parse(Console.ReadLine());
                    break;
                case 5:
                    Console.WriteLine("Insira a nova data de nascimento (formato: dd/mm/yyyy): ");
                    datanasc = DateTime.Parse(Console.ReadLine());
                    break;
                case 6:
                    Console.WriteLine();
                    Console.WriteLine("Escolha o novo alojamento:");

                    foreach (var alojamento in Alojamentos.ALOJAMENTO)
                    {
                        Console.WriteLine($"{alojamento.ID}: {alojamento.Nome}");
                    }
                    alojamentoID = int.Parse(Console.ReadLine());
                    break;
                default:
                    // Operação não suportada
                    Console.WriteLine("Operação não suportada.");
                    break;
            }
        }

        /// <summary>
        /// Permite ao funcionário editar os seus próprios dados.
        /// </summary>
        /// <param name="op"> Opção escolhida para edição. </param>
        /// <param name="nome"> Novo nome do funcionário. </param>
        /// <param name="email"> Novo email do funcionário. </param>
        /// <param name="password"> Nova password do funcionário. </param>
        /// <param name="contacto"> Novo contacto do funcionário. </param>
        /// <param name="datanasc"> Nova data de nascimento do funcionário. </param>
        /// <param name="IDF"> ID do funcionário a ser editado, retirado automaticamente, através do login. </param>
        /// <param name="alojamentoID"> Novo ID do alojamento onde o funcionário trabalha. </param>
        public void EditarFuncF(out int op, out string nome, out string email, out string password, out int contacto, out DateTime datanasc, out int IDF, out int alojamentoID)
        {
            // Inicialização das variáveis.
            op = 0;
            int opcao;
            nome = string.Empty;
            email = string.Empty;
            password = string.Empty;
            contacto = 0;
            datanasc = DateTime.MinValue;
            alojamentoID = 0;
            IDF = IDFunc; // variável que contém o ID do funcionário.

            Console.WriteLine("O que pretende alterar: (1 - nome, 2 - email, 3 - password, 4 - contacto, 5 - data de nascimento, 6 - ID alojamento)");
            opcao = int.Parse(Console.ReadLine());
            Console.WriteLine();

            op = opcao; // Define a opção escolhida

            // Realiza a edição com base na opção escolhida.
            switch (opcao)
            {
                case 1:
                    Console.WriteLine("Insira o novo nome: ");
                    nome = Console.ReadLine();
                    break;
                case 2:
                    Console.WriteLine("Insira o novo email: ");
                    email = Console.ReadLine();
                    break;
                case 3:
                    Console.WriteLine("Insira a nova password: ");
                    password = Console.ReadLine();
                    break;
                case 4:
                    Console.WriteLine("Insira o novo contacto: ");
                    contacto = int.Parse(Console.ReadLine());
                    break;
                case 5:
                    Console.WriteLine("Insira a nova data de nascimento (formato: dd/mm/yyyy): ");
                    datanasc = DateTime.Parse(Console.ReadLine());
                    break;
                case 6:
                    Console.WriteLine();
                    Console.WriteLine("Escolha o novo alojamento:");

                    foreach (var alojamento in Alojamentos.ALOJAMENTO)
                    {
                        Console.WriteLine($"{alojamento.ID}: {alojamento.Nome}");
                    }
                    alojamentoID = int.Parse(Console.ReadLine());
                    break;
                default:
                    // Operação não suportada
                    Console.WriteLine("Operação não suportada.");
                    break;
            }
        }

        /// <summary>
        /// Realiza o login do funcionário.
        /// </summary>
        /// <param name="password"> Password do funcionário. </param>
        /// <param name="id"> ID do funcionário. </param>
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

        /// <summary>
        /// Insere informações de um alojamento.
        /// </summary>
        /// <param name="idAlojamento"> ID do alojamento. </param>
        /// <param name="nomeAlojamento"> Nome do alojamento. </param>
        /// <param name="tipoAlojamento"> Tipo do alojamento. </param>
        /// <param name="localizacao"> Localização do alojamento. </param>
        public void InserirAlojamento(out int idAlojamento, out string nomeAlojamento, out string tipoAlojamento, out string localizacao)
        {
            // Inicialização das variáveis.
            idAlojamento = 0;
            nomeAlojamento = string.Empty;
            tipoAlojamento = string.Empty;
            localizacao = string.Empty;

            // Solicitação e atribuição de valores para as variáveis
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

        /// <summary>
        /// Remove um alojamento com base no ID fornecido.
        /// </summary>
        /// <param name="id"> ID do alojamento a ser removido. </param>
        public void RemoverAlojamento(out int id)
        {
            // Inicializa o parâmetro de saída ID com 0.
            id = 0;

            // Exibe mensagens de instrução para o utilizador.
            Console.WriteLine("Insira o ID do alojamento que deseja remover");
            Console.WriteLine();
            Console.WriteLine("{0,-20} {1,-20}", "Nome do Alojamento", "ID do Alojamento");

            // Percorre a lista de alojamentos.
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

        /// <summary>
        /// Insere informações de um quarto.
        /// </summary>
        /// <param name="id"> ID do quarto. </param>
        /// <param name="tipo"> Tipo de quarto (Duplo, Triplo, Familiar, Suíte). </param>
        /// <param name="disponibilidade"> Disponibilidade do quarto (true - disponível, false - não disponível). </param>
        /// <param name="valor"> Valor do quarto. </param>
        /// <param name="alojamentoID"> ID do alojamento associado ao quarto. </param>
        public void InserirQuarto(out int id, out string tipo, out bool disponibilidade, out decimal valor, out int alojamentoID)
        {
            // Inicialização das variáveis
            id = 0;
            tipo = string.Empty;
            disponibilidade = false;
            valor = 0;
            alojamentoID = 0;

            // Entrada de dados pelo utilizador
            Console.WriteLine("Insira o ID do quarto");
            id = int.Parse(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine("Escolha o tipo do quarto (1 - Duplo, 2 - Triplo, 3 - Familiar, 4 - Suíte):");
            int tipoEscolhido = int.Parse(Console.ReadLine());

            // Definição do tipo de quarto com base na escolha do utilizador
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

            // Entrada de disponibilidade do quarto
            Console.WriteLine();
            Console.WriteLine("Insira a disponibilidade (S/N)");
            string disponibilidadeInput = Console.ReadLine();

            // Definição da disponibilidade com base na entrada do utilizador
            disponibilidade = (disponibilidadeInput.Trim().ToUpper() == "S");

            // Verificação da disponibilidade para garantir S ou N como valores válidos
            if (!disponibilidade && disponibilidadeInput.Trim().ToUpper() != "N")
            {
                Console.WriteLine("Valor inválido. Insira S ou N.");
            }

            // Entrada do valor por noite do quarto
            Console.WriteLine();
            Console.WriteLine("Insira o valor por noite do quarto");
            valor = decimal.Parse(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine("Escolha um alojamento:");

            // Escolha de um alojamento associado ao quarto
            foreach (var alojamento in Alojamentos.ALOJAMENTO)
            {
                Console.WriteLine($"{alojamento.ID}: {alojamento.Nome}");
            }

            alojamentoID = int.Parse(Console.ReadLine());
        }

        /// <summary>
        /// Lista os quartos pertencentes ao alojamento do funcionário.
        /// </summary>
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

        /// <summary>
        /// Remove um quarto com base no ID fornecido.
        /// </summary>
        /// <param name="id"> ID do quarto a ser removido. </param>
        public void RemoverQuarto(out int id)
        {
            // Inicialização da variável id
            id = 0;

            Console.WriteLine("Insira o ID do quarto que deseja remover");
            Console.WriteLine();
            Console.WriteLine("{0,-20} {1,-20} {2,-20}", "Tipo de Quarto", "ID do Quarto", "ID do Alojamento");

            // Mostra a lista de quartos com seus tipos, IDs e IDs de alojamento associados
            foreach (var quarto in Quartos.QUARTO)
            {
                Console.WriteLine("{0,-20} {1,-20} {2,-20}", quarto.Tipo, quarto.ID, quarto.Alojamento.ID);
            }

            // Entrada de dados pelo utilizador
            Console.WriteLine();
            Console.Write("Digite o ID do quarto: ");
            id = int.Parse(Console.ReadLine());
            Console.WriteLine();
        }

        #endregion

        #region RESERVAS

        /// <summary>
        /// Insere uma nova reserva feita por um cliente.
        /// </summary>
        /// <param name="dataInicio"> Data de início da reserva. </param>
        /// <param name="dataFim"> Data de fim da reserva. </param>
        /// <param name="numPessoas"> Número de pessoas para a reserva. </param>
        /// <param name="clienteNIF"> NIF do cliente que faz a reserva. </param>
        /// <param name="quartoID"> ID do quarto reservado. </param>
        /// <param name="PrecoTotal"> Preço total da reserva. </param>
        /// <returns> Retorna true se a reserva for inserida com sucesso. </returns>
        public bool InserirReservaC(out DateTime dataInicio, out DateTime dataFim, out int numPessoas, out int clienteNIF, out int quartoID, out decimal PrecoTotal)
        {
            // Inicialização das variáveis
            string tipoQ;
            decimal valorQ;
            int idQ;
            int alojQ;
            PrecoTotal = 0;
            clienteNIF = NIFClienteLogin; // NIF do cliente recebido pelo login

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

                // Mostrar informações do quarto com o alojamento associado
                foreach (var alojamento in Alojamentos.ALOJAMENTO.Where(a => a.ID == alojQ))
                {
                    Console.WriteLine("{0,-20} {1,-20} {2,-20} {3,-20} {4,-20}", idQ, tipoQ, valorQ, alojamento.Nome, alojamento.Tipo);
                }
            }

            Console.WriteLine();
            Console.Write("Digite o ID do quarto: ");
            quartoID = int.Parse(Console.ReadLine());

            return true; // Retorna true se a reserva for inserida com sucesso
        }

        /// <summary>
        /// Insere uma nova reserva feita por um admin.
        /// </summary>
        /// <param name="dataInicio"> Data de início da reserva. </param>
        /// <param name="dataFim"> Data de fim da reserva. </param>
        /// <param name="numPessoas"> Número de pessoas para a reserva. </param>
        /// <param name="clienteNIF"> NIF do cliente que faz a reserva. </param>
        /// <param name="quartoID"> ID do quarto reservado. </param>
        /// <param name="PrecoTotal"> Preço total da reserva. </param>
        /// <returns> Retorna true se a reserva for inserida com sucesso. </returns>
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

            // verifica os quartos onde o alojamento associado é o mesmo que o inserido pelo admin, e que esteja disponível
            foreach (var quarto in Quartos.QUARTO.Where(q => q.Alojamento.ID == alojamentoA && q.Disponibilidade == true))
            {
                Console.WriteLine("{0,-20} {1,-20} {2,-20}", quarto.Tipo, quarto.ID, quarto.Valor);
                QuartoDisp = true;
            }

            // se não existirem quartos disponíveis, ou o alojamento não existir, retorna mensagem de erro
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

        /// <summary>
        /// Remove uma reserva feita por um dado cliente com base no ID fornecido.
        /// </summary>
        /// <param name="id"> ID da reserva a ser removida. </param>
        public void RemoverReservaC(out int id)
        {
            int clienteNIF = NIFClienteLogin; // Obtém o NIF do cliente 
            id = 0;

            Console.WriteLine("Insira o ID da reserva que deseja remover");
            Console.WriteLine();
            Console.WriteLine("{0,-20} {1,-20} {2,-20} {3,-20} {4,-20} {5,-20}", "ID da Reserva", "NIF do Cliente", "Data de Início", "Data de Fim",
                "ID do Quarto", "Preço Final");

            // Mostra as reservas associadas ao cliente atual
            foreach (var reserva in Reservas.RESERVA.Where(r => r.Cliente.NIF == clienteNIF))
            {
                Console.WriteLine("{0,-20} {1,-20} {2,-20} {3,-20} {4,-20} {5,-20}", reserva.ID, reserva.Cliente.NIF, reserva.DataInicio.ToShortDateString(),
                    reserva.DataFim.ToShortDateString(), reserva.Quarto.ID, reserva.PrecoTotal);
            }

            // Entrada de dados pelo utilizador
            Console.WriteLine();
            Console.Write("Digite o ID do reserva: ");
            id = int.Parse(Console.ReadLine());
            Console.WriteLine();
        }

        /// <summary>
        /// Remove reservas de clientes com base no ID fornecido.
        /// </summary>
        /// <param name="id"> ID da reserva a ser removida. </param>
        public void RemoverReservaA(out int id)
        {
            id = 0;

            Console.WriteLine("Insira o ID da reserva que deseja remover");
            Console.WriteLine();
            Console.WriteLine("{0,-20} {1,-20} {2,-20} {3,-20} {4,-20} {5,-20}", "ID da Reserva", "NIF do Cliente", "Data de Início", "Data de Fim",
                "ID do Quarto", "Preço Final");

            // Mostra todas as reservas criadas no sistema
            foreach (var reserva in Reservas.RESERVA)
            {
                Console.WriteLine("{0,-20} {1,-20} {2,-20} {3,-20} {4,-20} {5,-20}", reserva.ID, reserva.Cliente.NIF, reserva.DataInicio.ToShortDateString(),
                    reserva.DataFim.ToShortDateString(), reserva.Quarto.ID, reserva.PrecoTotal);
            }

            // Entrada de dados pelo utilizador
            Console.WriteLine();
            Console.Write("Digite o ID do reserva: ");
            id = int.Parse(Console.ReadLine());
            Console.WriteLine();
        }

        /// <summary>
        /// Lista as reservas associadas ao cliente.
        /// </summary>
        /// <returns> Retorna true se as reservas forem listadas com sucesso. </returns>
        public bool ListarReservaC()
        {
            Reservas reservas = new Reservas(); // Cria uma instância de Reservas.
            reservas.OrdenarReserva(); // Chama o método de ordenação antes de listar as reservas.

            // Lista as reservas associadas ao cliente. 
            foreach (var reserva in Reservas.RESERVA.Where(r => r.Cliente.NIF == NIFClienteLogin))
            {
                Console.WriteLine("ID Reserva: {0}\nData Início: {1}\nData Fim: {2}\nNº Pessoas: {3}\nNIF Cliente: {4}\nID Quarto: {5}\nPreço Total: {6}\n",
                                 reserva.ID, reserva.DataInicio.ToShortDateString(), reserva.DataFim.ToShortDateString(), reserva.NumPessoas, reserva.Cliente.NIF,
                                 reserva.Quarto.ID, reserva.PrecoTotal);
            }
            return true; // Retorna true se as reservas foram listadas com sucesso
        }

        /// <summary>
        /// Lista todas as reservas dos clientes.
        /// </summary>
        /// <returns> Retorna true se as reservas forem listadas com sucesso. </returns>
        public bool ListarReservaA()
        {
            Reservas reservas = new Reservas(); // Cria uma instância de Reservas.
            reservas.OrdenarReserva(); // Chama o método de ordenação antes de listar as reservas.

            // Lista todas as reservas do sistema
            foreach (var reserva in Reservas.RESERVA)
            {
                Console.WriteLine("ID Reserva: {0}\nData Início: {1}\nData Fim: {2}\nNº Pessoas: {3}\nNIF Cliente: {4}\nID Quarto: {5}\nPreço Total: {6}\n",
                                 reserva.ID, reserva.DataInicio.ToShortDateString(), reserva.DataFim.ToShortDateString(), reserva.NumPessoas, reserva.Cliente.NIF,
                                 reserva.Quarto.ID, reserva.PrecoTotal);
            }
            return true; // Retorna true se as reservas foram listadas com sucesso
        }

        #endregion

        #region CHECK_INS

        /// <summary>
        /// Insere um check-in para uma reserva, solicitando o ID da reserva e a data de check-in.
        /// </summary>
        /// <param name="reservaID"> ID da reserva associada ao check-in. </param>
        /// <param name="dataCheck_I"> Data de check-in a ser inserida. </param>
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
            // Entrada de dados pelo utilizador
            Console.WriteLine();
            Console.WriteLine("Insira o ID da reserva");
            reservaID = int.Parse(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine("Insira a data de Check IN do cliente");
            dataCheck_I = DateTime.Parse(Console.ReadLine());
            Console.WriteLine();
        }

        /// <summary>
        /// Remove um check-in com base no ID fornecido.
        /// </summary>
        /// <param name="id"> ID do check-in a ser removido. </param>
        public void RemoverCheck_I(out int id)
        {
            id = 0;

            Console.WriteLine("Insira o ID do Check IN que deseja remover");
            Console.WriteLine();
            Console.WriteLine("{0,-20} {1,-20} {2,-20}", "ID do Check IN", "ID da Reserva", "Data do Check IN");

            // Lista os check-ins do sistema
            foreach (var check_in in Check_Ins.CHECKIN)
            {
                Console.WriteLine("{0,-20} {1,-20} {2,-20}", check_in.ID, check_in.Reserva.ID, check_in.DataCheckIO.ToShortDateString());
            }
            // Entrada de dados pelo utilizador
            Console.WriteLine();
            Console.Write("Digite o ID do Check IN: ");
            id = int.Parse(Console.ReadLine());
            Console.WriteLine();
        }

        #endregion

        #region CHECK_OUTS

        /// <summary>
        /// Insere um check-out para um check-in, solicitando o ID do check-in e a data de check-out.
        /// </summary>
        /// <param name="checkIN"> ID do check-in associado ao check-out. </param>
        /// <param name="dataCheck_O"> Data de check-out a ser inserida. </param>
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
                // Verifica se o check_in não tem check-outs associados
                if (!Check_Outs.CHECKOUT.Any(co => co.Check_In.ID == check_i.ID))
                {
                    Console.WriteLine("{0,-20} {1,-20} {2,-20}", check_i.ID, check_i.Reserva.ID, check_i.DataCheckIO.ToShortDateString());
                }
            }
            // Entrada de dados pelo utilizador
            Console.WriteLine();
            Console.WriteLine("Insira o ID do check-IN");
            checkIN = int.Parse(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine("Insira a data de Check OUT do cliente");
            dataCheck_O = DateTime.Parse(Console.ReadLine());
            Console.WriteLine();
        }

        /// <summary>
        /// Remove um check-out com base no ID fornecido.
        /// </summary>
        /// <param name="id"> ID do check-out a ser removido. </param>
        public void RemoverCheck_O(out int id)
        {
            id = 0;

            Console.WriteLine("Insira o ID do Check OUT que deseja remover");
            Console.WriteLine();
            Console.WriteLine("{0,-20} {1,-20} {2,-20}", "ID do Check OUT", "ID do Check IN", "Data do Check OUT");

            // Lista os check-outs do sistema
            foreach (var check_out in Check_Outs.CHECKOUT)
            {
                Console.WriteLine("{0,-20} {1,-20} {2,-20}", check_out.ID, check_out.Check_In.ID, check_out.DataCheckIO.ToShortDateString());
            }
            // Entrada de dados pelo utilizador
            Console.WriteLine();
            Console.Write("Digite o ID do Check OUT: ");
            id = int.Parse(Console.ReadLine());
            Console.WriteLine();
        }

        #endregion
    }
}

