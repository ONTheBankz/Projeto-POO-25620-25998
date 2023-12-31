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

        /// <summary>
        /// Solicita informações do cliente ao utilizador e insere um novo cliente na lista, se o NIF fornecido não existir.
        /// </summary>
        /// <returns>Verdadeiro se a inserção for bem-sucedida, falso se o cliente com o NIF já existir.</returns>
        public bool InserirCliente()
        {
            // Cria uma instância da classe Clientes e IO.
            Clientes clientes = new Clientes();
            IO io = new IO();

            // Declaração de variáveis para armazenar informações do cliente.
            string nome;
            string morada;
            string email;
            string password;
            int contacto;
            DateTime dataNascimento;
            int nif;

            // Chama o método InserirCliente da classe IO para obter informações do cliente.
            io.InserirCliente(out nome, out morada, out email, out password, out contacto, out dataNascimento, out nif);

            // Verifica se o cliente com o NIF fornecido já existe.
            if (clientes.ExisteCliente(nif) == false)
            {
                // Cria um novo objeto Cliente com as informações fornecidas e insere na lista de clientes.
                Cliente cliente = new Cliente(nome, morada, email, password, contacto, dataNascimento, nif);
                clientes.InserirCliente(cliente);
                return true; // Retorna verdadeiro indicando que a inserção foi bem-sucedida.
            }
            Console.WriteLine("Cliente com NIF já existente no sistema");
            Console.WriteLine();
            return false; // Retorna falso indicando que o cliente com o NIF fornecido já existe.
        }

        /// <summary>
        /// Solicita o NIF do cliente ao utilizador e remove o cliente da lista, se encontrado.
        /// </summary>
        /// <returns>Verdadeiro se a remoção for bem-sucedida, falso se o cliente com o NIF não for encontrado.</returns>
        public bool RemoverCliente()
        {
            // Cria uma instância da classe Clientes e IO.
            Clientes clientes = new Clientes();
            IO io = new IO();

            // Declaração de variável para armazenar o NIF do cliente a ser removido.
            int nif;

            // Chama o método RemoverCliente da classe IO para obter o NIF do cliente a ser removido.
            io.RemoverCliente(out nif);

            // Verifica se o cliente com o NIF fornecido existe.
            if (clientes.ExisteCliente(nif))
            {
                // Cria um novo objeto Cliente com o NIF fornecido e remove da lista de clientes.
                Cliente cliente = new Cliente();
                cliente.NIF = nif;
                clientes.RemoverCliente(cliente);

                return true; // Retorna verdadeiro indicando que a remoção foi bem-sucedida.
            }

            // Se o cliente com o NIF fornecido não for encontrado, mostra uma mensagem e retorna falso.
            Console.Clear();
            Console.WriteLine("Cliente não encontrado ou removido. NIF não existe.");
            Console.WriteLine();
            return false; // Retorna falso indicando que o cliente não foi encontrado.
        }

        /// <summary>
        /// Solicita e realiza a edição de dados de um cliente com base nas opções fornecidas pelo admin.
        /// </summary>
        /// <returns>Verdadeiro se a edição for bem-sucedida, falso caso contrário.</returns>
        public bool EditarClienteA()
        {
            // Cria instâncias da classe IO e Clientes.
            IO io = new IO();
            Clientes clientes = new Clientes();

            // Declaração de variáveis para armazenar informações do cliente.
            int op = 0;
            int nif = 0;
            int NIFC = 0;
            int contacto = 0;
            string nome = string.Empty;
            string morada = string.Empty;
            string email = string.Empty;
            string password = string.Empty;
            DateTime datanasc = DateTime.MinValue;

            // Chama o método EditarClienteA da classe IO para obter informações do cliente a ser editado.
            io.EditarClienteA(out op, out nome, out morada, out email, out password, out contacto, out datanasc, out nif, out NIFC);

            // Chama o método EditarCliente da classe Clientes para realizar a edição com base nas informações fornecidas.
            clientes.EditarCliente(op, nome, morada, email, password, contacto, datanasc, nif, NIFC);

            return true; // Retorna verdadeiro indicando que a edição foi bem-sucedida.
        }

        /// <summary>
        /// Solicita e realiza a edição de dados de um cliente com base nas opções fornecidas pelo cliente.
        /// </summary>
        /// <returns>Verdadeiro se a edição for bem-sucedida, falso caso contrário.</returns>
        public bool EditarClienteC()
        {
            // Cria instâncias da classe IO e Clientes.
            IO io = new IO();
            Clientes clientes = new Clientes();

            // Declaração de variáveis para armazenar informações do cliente.
            int op = 0;
            int nif = 0;
            int NIFC = 0;
            int contacto = 0;
            string nome = string.Empty;
            string morada = string.Empty;
            string email = string.Empty;
            string password = string.Empty;
            DateTime datanasc = DateTime.MinValue;

            // Chama o método EditarClienteC da classe IO para obter informações do cliente a ser editado.
            io.EditarClienteC(out op, out nome, out morada, out email, out password, out contacto, out datanasc, out nif, out NIFC);

            // Chama o método EditarCliente da classe Clientes para realizar a edição com base nas informações fornecidas.
            clientes.EditarCliente(op, nome, morada, email, password, contacto, datanasc, nif, NIFC);

            return true; // Retorna verdadeiro indicando que a edição foi bem-sucedida.
        }

        /// <summary>
        /// Solicita as credenciais de um cliente (NIF e passe) e autentica o cliente com base nessas informações.
        /// </summary>
        /// <returns>Verdadeiro se a autenticação for bem-sucedida, falso caso contrário.</returns>
        public bool LoginCliente()
        {
            // Cria instâncias das classes Clientes e IO.
            Clientes clientes = new Clientes();
            IO io = new IO();

            // Declaração de variáveis para armazenar as credenciais do cliente.
            string password;
            int nif;

            // Chama o método LoginCliente da classe IO para obter as credenciais do cliente.
            io.LoginCliente(out password, out nif);

            // Chama o método AuthCliente da classe Clientes para autenticar o cliente com base nas informações fornecidas.
            if (clientes.AuthCliente(nif, password))
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

        /// <summary>
        /// Lista os detalhes de todos os clientes na consola.
        /// </summary>
        /// <returns>Verdadeiro se a listagem for bem-sucedida.</returns>
        public bool ListarClientes()
        {
            // Cria uma instância da classe Clientes.
            Clientes clientes = new Clientes();

            // Chama o método ListarClientes da classe Clientes para exibir os detalhes dos clientes na consola.
            clientes.ListarClientes();

            // Retorna verdadeiro, indicando que a listagem foi bem-sucedida.
            return true;
        }

        /// <summary>
        /// Grava os detalhes dos clientes num arquivo.
        /// </summary>
        /// <param name="c">Caminho do arquivo para gravar os detalhes dos clientes.</param>
        /// <returns>Verdadeiro se a gravação for bem-sucedida, falso caso contrário.</returns>
        public bool GravarCliente(string c)
        {
            // Cria uma instância da classe Clientes.
            Clientes clientes = new Clientes();

            // Chama o método GravarCliente da classe Clientes para gravar os detalhes dos clientes num arquivo.
            clientes.GravarCliente(c);

            // Retorna verdadeiro, indicando que a gravação foi bem-sucedida.
            return true;
        }

        /// <summary>
        /// Lê os valores dos clientes de um arquivo e preenche a lista de clientes.
        /// </summary>
        /// <param name="c">Caminho do arquivo para ler os detalhes dos clientes.</param>
        /// <returns>Verdadeiro se a leitura for bem-sucedida, falso caso contrário.</returns>
        public bool LerCliente(string c)
        {
            // Cria uma instância da classe Clientes.
            Clientes clientes = new Clientes();

            // Chama o método LerCliente da classe Clientes para ler os detalhes dos clientes de um arquivo.
            clientes.LerCliente(c);

            // Retorna verdadeiro, indicando que a leitura foi bem-sucedida.
            return true;
        }

        #endregion

        #region ALOJAMENTOS
        /// <summary>
        /// Insere um novo alojamento na lista de alojamentos.
        /// </summary>
        /// <returns>Verdadeiro se a inserção for bem-sucedida; caso contrário, falso.</returns>
        public bool InserirAlojamento()
        {
            // Cria uma instância da classe Alojamentos.
            Alojamentos alojamentos = new Alojamentos();

            // Cria uma instância da classe IO.
            IO io = new IO();

            // Declaração de variáveis para armazenar os detalhes do novo alojamento.
            int idAlojamento;
            string nomeAlojamento;
            string tipoAlojamento;
            string localizacao;

            // Chama o método InserirAlojamento da classe IO para obter os detalhes do novo alojamento.
            io.InserirAlojamento(out idAlojamento, out nomeAlojamento, out tipoAlojamento, out localizacao);

            // Verifica se o alojamento com o ID fornecido já existe.
            if (alojamentos.ExisteAlojamento(idAlojamento) == false)
            {
                // Cria uma instância do alojamento com os detalhes fornecidos.
                Alojamento alojamento = new Alojamento(idAlojamento, nomeAlojamento, tipoAlojamento, localizacao);

                // Chama o método InserirAlojamento da classe Alojamentos para adicionar o novo alojamento à lista.
                alojamentos.InserirAlojamento(alojamento);

                // Retorna verdadeiro, indicando que a inserção foi bem-sucedida.
                return true;
            }
            Console.WriteLine("Alojamento com ID já existente no sistema");
            Console.WriteLine();
            // Retorna falso, indicando que a inserção falhou porque um alojamento com o mesmo ID já existe.
            return false;
        }

        /// <summary>
        /// Remove um alojamento da lista de alojamentos.
        /// </summary>
        /// <returns>Verdadeiro se a remoção for bem-sucedida; 
        /// Falso se o alojamento não existir ou se tiver quartos ou funcionários associados.</returns>
        public bool RemoverAlojamento()
        {
            // Cria uma instância da classe Alojamentos.
            Alojamentos alojamentos = new Alojamentos();

            // Cria uma instância da classe IO.
            IO io = new IO();

            // Declaração de variável para armazenar o ID do alojamento a ser removido.
            int id;

            // Chama o método RemoverAlojamento da classe IO para obter o ID do alojamento a ser removido do utilizador.
            io.RemoverAlojamento(out id);

            // Verifica se o alojamento com o ID fornecido existe.
            if (alojamentos.ExisteAlojamento(id))
            {
                // Cria uma instância do alojamento com o ID fornecido.
                Alojamento alojamento = new Alojamento { ID = id };

                // Verifica se o alojamento não tem quartos ou funcionários associados.
                if (Quartos.QUARTO.Any(q => q.Alojamento.ID == id || Funcionarios.FUNCIONARIO.Any(f => f.Alojamento.ID == id)))
                {
                    // Imprime uma mensagem indicando que não é possível remover o alojamento devido à associação de quartos ou funcionários.
                    Console.WriteLine("Não é possível remover o alojamento, pois já possui quartos ou funcionários associados.");
                    return false;
                }

                // Chama o método RemoverAlojamento da classe Alojamentos para remover o alojamento da lista.
                alojamentos.RemoverAlojamento(alojamento);

                // Retorna verdadeiro, indicando que a remoção foi bem-sucedida.
                return true;
            }

            // Imprime uma mensagem indicando que o alojamento não foi encontrado ou removido porque o ID não existe.
            Console.Clear();
            Console.WriteLine("Alojamento não encontrado ou removido. O ID não existe.");
            Console.WriteLine();

            // Retorna falso, indicando que a remoção falhou.
            return false;
        }

        /// <summary>
        /// Lista os detalhes de todos os alojamentos na consola.
        /// </summary>
        /// <returns>Verdadeiro se a listagem for bem-sucedida.</returns>
        public bool ListarAlojamentos()
        {
            // Cria uma instância da classe Alojamentos.
            Alojamentos alojamentos = new Alojamentos();

            // Chama o método ListarAlojamentos da classe Alojamentos para exibir os detalhes dos alojamentos.
            alojamentos.ListarAlojamentos();

            // Retorna verdadeiro, indicando que a listagem foi bem-sucedida.
            return true;
        }

        /// <summary>
        /// Grava os valores dos alojamentos num arquivo.
        /// </summary>
        /// <param name="a">Caminho do arquivo onde os valores dos alojamentos serão gravados.</param>
        /// <returns>Verdadeiro se a gravação for bem-sucedida, falso caso contrário.</returns>
        public bool GravarAlojamento(string a)
        {
            // Cria uma instância da classe Alojamentos.
            Alojamentos alojamentos = new Alojamentos();

            // Chama o método GravarAlojamento da classe Alojamentos para gravar os valores dos alojamentos num arquivo.
            alojamentos.GravarAlojamento(a);

            // Retorna verdadeiro, indicando que a gravação foi bem-sucedida.
            return true;
        }

        /// <summary>
        /// Lê os valores dos alojamentos de um arquivo e preenche a lista de alojamentos.
        /// </summary>
        /// <param name="a">Caminho do arquivo de onde os valores dos alojamentos serão lidos.</param>
        /// <returns>Verdadeiro se a leitura for bem-sucedida, falso caso contrário.</returns>
        public bool LerAlojamento(string a)
        {
            // Cria uma instância da classe Alojamentos.
            Alojamentos alojamentos = new Alojamentos();

            // Chama o método LerAlojamento da classe Alojamentos para ler os valores dos alojamentos de um arquivo.
            alojamentos.LerAlojamento(a);

            // Retorna verdadeiro, indicando que a leitura foi bem-sucedida.
            return true;
        }

        #endregion

        #region FUNCIONARIOS

        /// <summary>
        /// Insere um novo funcionário na lista de funcionários.
        /// </summary>
        /// <returns>Verdadeiro se a inserção for bem-sucedida, falso se o funcionário já existir.</returns>
        public bool InserirFunc()
        {
            // Cria uma instância da classe Funcionarios.
            Funcionarios funcionarios = new Funcionarios();

            // Cria uma instância da classe IO.
            IO io = new IO();

            // Declaração de variáveis para armazenar os dados do funcionário.
            int idFunc;
            string nome;
            string email;
            string password;
            int contacto;
            DateTime dataNascimento;
            int alojamentoID;

            // Chama o método InserirFunc da classe IO para obter os dados do funcionário.
            io.InserirFunc(out idFunc, out nome, out email, out password, out contacto, out dataNascimento, out alojamentoID);

            // Verifica se o funcionário já existe na lista.
            if (funcionarios.ExisteFunc(idFunc) == false)
            {
                // Cria uma instância da classe Alojamento com o ID fornecido.
                Alojamento alojamento = new Alojamento { ID = alojamentoID };

                // Cria uma instância da classe Funcionario com os dados fornecidos.
                Funcionario funcionario = new Funcionario(idFunc, nome, email, password, contacto, dataNascimento, alojamento);

                // Chama o método InserirFunc da classe Funcionarios para adicionar o funcionário à lista.
                funcionarios.InserirFunc(funcionario);

                // Retorna verdadeiro, indicando que a inserção foi bem-sucedida.
                return true;
            }
            Console.WriteLine("Funcionário com ID já existente no sistema");
            Console.WriteLine();
            // Retorna falso, indicando que o funcionário já existe.
            return false;
        }

        /// <summary>
        /// Remove um funcionário da lista de funcionários com base no ID.
        /// </summary>
        /// <returns>Verdadeiro se a remoção for bem-sucedida, falso se o funcionário não for encontrado.</returns>
        public bool RemoverFunc()
        {
            // Cria uma instância da classe Funcionarios.
            Funcionarios funcionarios = new Funcionarios();

            // Cria uma instância da classe IO.
            IO io = new IO();

            // Declaração da variável para armazenar o ID do funcionário a ser removido.
            int id;

            // Chama o método RemoverFunc da classe IO para obter o ID do funcionário a ser removido.
            io.RemoverFunc(out id);

            // Verifica se o funcionário com o ID fornecido existe na lista.
            if (funcionarios.ExisteFunc(id))
            {
                // Cria uma instância da classe Funcionario com o ID fornecido.
                Funcionario funcionario = new Funcionario { ID = id };

                // Chama o método RemoverFunc da classe Funcionarios para remover o funcionário da lista.
                funcionarios.RemoverFunc(funcionario);

                // Retorna verdadeiro, indicando que a remoção foi bem-sucedida.
                return true;
            }

            // Se o funcionário não for encontrado, imprime uma mensagem indicando que não existe.
            Console.Clear();
            Console.WriteLine("Funcionário não encontrado ou removido. ID não existe.");
            Console.WriteLine();

            // Retorna falso, indicando que a remoção não foi bem-sucedida.
            return false;
        }

        /// <summary>
        /// Realiza a edição de um funcionário na lista, com base nas opções fornecidas pelo admin.
        /// </summary>
        /// <returns>Verdadeiro se a edição for bem-sucedida, falso se o funcionário não for encontrado.</returns>
        public bool EditarFuncA()
        {
            // Cria uma instância da classe IO.
            IO io = new IO();

            // Cria uma instância da classe Funcionarios.
            Funcionarios funcionarios = new Funcionarios();

            // Declaração de variáveis para armazenar os dados do funcionário a ser editado.
            int op = 0;
            int contacto = 0;
            int IDF = 0;
            int alojamentoID = 0;
            string nome = string.Empty;
            string email = string.Empty;
            string password = string.Empty;
            DateTime datanasc = DateTime.MinValue;

            // Obtém os dados do funcionário que será editado através dos valores fornecidos pelo admin.
            io.EditarFuncA(out op, out nome, out email, out password, out contacto, out datanasc, out IDF, out alojamentoID);

            // Realiza a edição do funcionário com os dados fornecidos.
            funcionarios.EditarFunc(op, nome, email, password, contacto, datanasc, IDF, alojamentoID);

            // Retorna verdadeiro, indicando que a edição foi bem-sucedida.
            return true;
        }

        /// <summary>
        /// Solicita e realiza a edição de um funcionário na lista, com base nas opções fornecidas pelo funcionário.
        /// </summary>
        /// <returns>Verdadeiro se a edição for bem-sucedida, falso se o funcionário não for encontrado.</returns>
        public bool EditarFuncF()
        {
            // Cria uma instância da classe IO.
            IO io = new IO();

            // Cria uma instância da classe Funcionarios.
            Funcionarios funcionarios = new Funcionarios();

            // Declaração de variáveis para armazenar os dados do funcionário a ser editado.
            int op = 0;
            int contacto = 0;
            int IDF = 0;
            int alojamentoID = 0;
            string nome = string.Empty;
            string email = string.Empty;
            string password = string.Empty;
            DateTime datanasc = DateTime.MinValue;

            // Obtém os dados do funcionário que será editado através dos valores fornecidos pelo funcionário.
            io.EditarFuncF(out op, out nome, out email, out password, out contacto, out datanasc, out IDF, out alojamentoID);

            // Realiza a edição do funcionário com os dados fornecidos.
            funcionarios.EditarFunc(op, nome, email, password, contacto, datanasc, IDF, alojamentoID);

            // Retorna verdadeiro, indicando que a edição foi bem-sucedida.
            return true;
        }

        /// <summary>
        /// Lista os detalhes de todos os funcionários na consola.
        /// </summary>
        /// <returns>Verdadeiro se a listagem for bem-sucedida.</returns>
        public bool ListarFunc()
        {
            // Cria uma instância da classe Funcionarios.
            Funcionarios funcionarios = new Funcionarios();

            // Chama o método ListarFunc da classe Funcionarios para exibir os detalhes dos funcionários na consola.
            funcionarios.ListarFunc();

            // Retorna verdadeiro, indicando que a listagem foi bem-sucedida.
            return true;
        }

        /// <summary>
        /// Grava os detalhes dos funcionários num arquivo.
        /// </summary>
        /// <param name="f">Caminho do arquivo para gravação.</param>
        /// <returns>Verdadeiro se a gravação for bem-sucedida, falso caso contrário.</returns>
        public bool GravarFunc(string f)
        {
            // Cria uma instância da classe Funcionarios.
            Funcionarios funcionarios = new Funcionarios();

            try
            {
                // Chama o método GravarFunc da classe Funcionarios para escrever os detalhes dos funcionários no arquivo.
                funcionarios.GravarFunc(f);

                // Retorna verdadeiro, indicando que a gravação foi bem-sucedida.
                return true;
            }
            catch (Exception ex)
            {
                // Em caso de exceção, exibe uma mensagem de erro na console.
                Console.WriteLine($"Erro ao gravar funcionários: {ex.Message}");

                // Retorna falso, indicando que a gravação falhou.
                return false;
            }
        }

        /// <summary>
        /// Lê os detalhes dos funcionários de um arquivo.
        /// </summary>
        /// <param name="f">Caminho do arquivo para leitura.</param>
        /// <returns>Verdadeiro se a leitura for bem-sucedida, falso caso contrário.</returns>
        public bool LerFunc(string f)
        {
            // Cria uma instância da classe Funcionarios.
            Funcionarios funcionarios = new Funcionarios();

            try
            {
                // Chama o método LerFunc da classe Funcionarios para preencher os valores dos funcionários a partir do arquivo.
                funcionarios.LerFunc(f);

                // Retorna verdadeiro, indicando que a leitura foi bem-sucedida.
                return true;
            }
            catch (Exception ex)
            {
                // Em caso de exceção, exibe uma mensagem de erro na console.
                Console.WriteLine($"Erro ao ler funcionários: {ex.Message}");

                // Retorna falso, indicando que a leitura falhou.
                return false;
            }
        }

        /// <summary>
        /// Realiza a autenticação de um funcionário.
        /// </summary>
        /// <returns>Verdadeiro se a autenticação for bem-sucedida, falso caso contrário.</returns>
        public bool LoginFunc()
        {
            // Cria uma instância da classe Funcionarios.
            Funcionarios funcionarios = new Funcionarios();

            // Cria uma instância da classe IO.
            IO io = new IO();

            // Declaração de variáveis para armazenar os dados de entrada.
            string password;
            int id;

            // Chama o método LoginFunc da classe IO para obter a passe e o ID do funcionário.
            io.LoginFunc(out password, out id);

            // Verifica se a autenticação utilizando o método AuthFunc da classe Funcionarios é bem-sucedida.
            if (funcionarios.AuthFunc(id, password))
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

        /// <summary>
        /// Insere um novo quarto.
        /// </summary>
        /// <returns>Verdadeiro se a inserção for bem-sucedida, falso caso contrário.</returns>
        public bool InserirQuarto()
        {
            // Cria uma instância da classe Quartos.
            Quartos quartos = new Quartos();

            // Cria uma instância da classe IO.
            IO io = new IO();

            // Declaração de variáveis para armazenar os dados de entrada.
            int idQuarto;
            string tipo;
            bool disponibilidade;
            decimal valor;
            int alojamentoID;

            // Chama o método InserirQuarto da classe IO para obter os dados do novo quarto.
            io.InserirQuarto(out idQuarto, out tipo, out disponibilidade, out valor, out alojamentoID);

            // Verifica se o quarto já existe na lista.
            if (quartos.ExisteQuarto(idQuarto))
            {
                Console.WriteLine("Quarto com ID já existente no sistema");
                Console.WriteLine();
                // Retorna falso se o quarto já existe.
                return false;
            }

            // Verifica se o valor do quarto ultrapassa o limite.
            if (valor > 500)
            {
                Console.WriteLine();
                Console.WriteLine("Valor limite do quarto ultrapassado");
                return false;
            }

            // Cria uma instância da classe Alojamento associada ao quarto.
            Alojamento alojamento = new Alojamento { ID = alojamentoID };

            // Cria uma instância da classe Quarto com os dados fornecidos.
            Quarto quarto = new Quarto(idQuarto, tipo, disponibilidade, valor, alojamento);

            // Chama o método InserirQuarto da classe Quartos para adicionar o quarto à lista.
            quartos.InserirQuarto(quarto);

            // Retorna verdadeiro indicando que a inserção foi bem-sucedida.
            return true;
        }

        /// <summary>
        /// Remove um quarto.
        /// </summary>
        /// <returns>Verdadeiro se a remoção for bem-sucedida, falso caso contrário.</returns>
        public bool RemoverQuarto()
        {
            // Cria uma instância da classe Quartos.
            Quartos quartos = new Quartos();

            // Cria uma instância da classe IO.
            IO io = new IO();

            // Declaração de variável para armazenar o ID do quarto a ser removido.
            int id;

            // Chama o método RemoverQuarto da classe IO para obter o ID do quarto a ser removido.
            io.RemoverQuarto(out id);

            // Verifica se o quarto com o ID fornecido existe na lista.
            if (quartos.ExisteQuarto(id))
            {
                // Cria uma instância da classe Quarto com o ID fornecido.
                Quarto quarto = new Quarto { ID = id };

                // Chama o método RemoverQuarto da classe Quartos para remover o quarto da lista.
                quartos.RemoverQuarto(quarto);

                // Retorna verdadeiro indicando que a remoção foi bem-sucedida.
                return true;
            }

            // Se o quarto não for encontrado, exibe uma mensagem e retorna falso.
            Console.Clear();
            Console.WriteLine("Quarto não encontrado ou removido. ID não existe.");
            Console.WriteLine();
            return false;
        }

        /// <summary>
        /// Lista os detalhes de todos os quartos.
        /// </summary>
        /// <returns>Verdadeiro se a listagem for bem-sucedida.</returns>
        public bool ListarQuartos()
        {
            // Cria uma instância da classe Quartos.
            Quartos quartos = new Quartos();

            // Chama o método ListarQuartos da classe Quartos para exibir os detalhes de todos os quartos na consola.
            quartos.ListarQuartos();

            // Retorna verdadeiro indicando que a listagem foi bem-sucedida.
            return true;
        }

        /// <summary>
        /// Lista os quartos associados ao alojamento do funcionário.
        /// </summary>
        /// <returns>Verdadeiro se a listagem for bem-sucedida.</returns>
        public bool ListarQuartosF()
        {
            // Cria uma instância da classe IO.
            IO io = new IO();
            // Chama o método ListarQuartoF da classe IO para exibir os detalhes de todos os quartos do alojamento do funcionário na consola.
            io.ListarQuartoF();
            // Retorna verdadeiro indicando que a listagem foi bem-sucedida.
            return true;
        }

        /// <summary>
        /// Grava os valores dos quartos num arquivo.
        /// </summary>
        /// <param name="q">Caminho do arquivo para a gravação dos valores dos quartos.</param>
        /// <returns>Verdadeiro se a gravação for bem-sucedida, falso caso contrário.</returns>
        public bool GravarQuarto(string q)
        {
            // Cria uma instância da classe Quartos.
            Quartos quartos = new Quartos();
            // Chama o método GravarQuarto da classe Quartos para escrever os valores dos quartos no arquivo.
            quartos.GravarQuarto(q);
            // Retorna verdadeiro, indicando que a gravação foi bem-sucedida.
            return true;
        }

        /// <summary>
        /// Lê os valores dos quartos a partir de um arquivo e preenche a lista de quartos.
        /// </summary>
        /// <param name="q">Caminho do arquivo que contém os valores dos quartos a serem lidos.</param>
        /// <returns>Verdadeiro se a leitura for bem-sucedida, falso caso contrário.</returns>
        public bool LerQuarto(string q)
        {
            // Cria uma instância da classe Quartos.
            Quartos quartos = new Quartos();
            // Chama o método LerQuarto da classe Quartos para preencher os valores dos quartos a partir do arquivo.
            quartos.LerQuarto(q);
            // Retorna verdadeiro, indicando que a leitura foi bem-sucedida.
            return true;
        }

        #endregion

        #region ADMINS

        /// <summary>
        /// Lê os valores dos admins a partir de um arquivo e preenche a lista de admins com esses valores.
        /// </summary>
        /// <param name="a">Caminho do arquivo que contém os valores dos admins a serem lidos.</param>
        /// <returns>Verdadeiro se a leitura for bem-sucedida, falso caso contrário.</returns>
        public bool LerAdmin(string a)
        {
            // Cria uma instância da classe Admins.
            Admins admins = new Admins();
            // Chama o método LerAdmin da classe Admins para preencher os valores dos admins a partir do arquivo.
            admins.LerAdmin(a);
            // Retorna verdadeiro, indicando que a leitura foi bem-sucedida.
            return true;
        }

        /// <summary>
        /// Realiza o login de um admin, solicitando as credenciais e verificando a autenticação.
        /// </summary>
        /// <returns>Verdadeiro se a autenticação for bem-sucedida, falso caso contrário.</returns>
        public bool LoginAdmin()
        {
            // Instância de objeto Admins
            Admins admins = new Admins();
            // Instância de objeto IO
            IO io = new IO();
            string password;
            int id;

            // Obtém informações necessárias para o login através do IO
            io.LoginAdmin(out password, out id);

            // Verifica se a autenticação é bem-sucedida
            if (admins.AuthAdmin(id, password))
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

        /// <summary>
        /// Função responsável por inserir uma nova reserva no sistema (cliente).
        /// </summary>
        /// <returns>True se a reserva for inserida com sucesso, False se houver falhas durante o processo.</returns>
        public bool InserirReservaC()
        {
            // Instâncias das classes necessárias
            Reservas reservas = new Reservas();
            Quartos quartos = new Quartos();
            IO io = new IO();

            // Variáveis para armazenar informações da reserva
            int id = 0;
            int numPessoas;
            int clienteNIF;
            int quartoID;
            int quantPessoas;
            DateTime dataInicio;
            DateTime dataFim;
            decimal precoTotal;
            decimal valorQuarto;

            // Obtém um novo ID para a reserva
            id = reservas.ID(id);

            // Verifica se io.InserirReservaC foi bem-sucedida antes de prosseguir
            if (!io.InserirReservaC(out dataInicio, out dataFim, out numPessoas, out clienteNIF, out quartoID, out precoTotal))
            {
                return false;
            }

            try
            {
                // Cria instâncias de Cliente e Quarto com base nas informações fornecidas
                Cliente cliente = new Cliente { NIF = clienteNIF };
                Quarto quarto = new Quarto { ID = quartoID };

                // Obtém o quarto escolhido da lista de quartos
                var quartoEscolhido = Quartos.QUARTO.FirstOrDefault(q => q.ID == quartoID);

                // Obtém a capacidade do quarto
                quantPessoas = quartos.ObterQuant(quartoEscolhido.Tipo);

                // Validação de datas
                if (dataInicio == dataFim || dataInicio > dataFim)
                {
                    Console.Clear();
                    Console.WriteLine("Datas de reserva inválidas.");
                    Console.WriteLine();
                    return false;
                }

                // Validação do número de pessoas em relação à capacidade do quarto
                if (numPessoas > quantPessoas)
                {
                    Console.Clear();
                    Console.WriteLine("Número de pessoas excede a capacidade do quarto.");
                    Console.WriteLine();
                    return false;
                }

                // Obtém o valor do quarto escolhido
                valorQuarto = quartoEscolhido.Valor;

                // Lógica para calcular o preço total da reserva
                int numDias = (int)(dataFim - dataInicio).TotalDays;
                decimal preco = valorQuarto * numDias;
                Console.WriteLine();
                Console.WriteLine($"Preço total da reserva: {preco}");
                Console.WriteLine();
                precoTotal = preco;

                // Cria uma instância de Reserva e a insere na lista de reservas
                Reserva reserva = new Reserva(id, dataInicio, dataFim, numPessoas, cliente, quarto, precoTotal);
                reservas.InserirReserva(reserva);

                return true; // Reserva inserida com sucesso
            }
            catch (EReserva r)
            {
                throw new EReserva("Erro ao criar reserva" + "-" + r.Message);
            }
        }

        /// <summary>
        /// Função responsável por inserir uma nova reserva no sistema (admin).
        /// </summary>
        /// <returns>
        /// Retorna verdadeiro se a reserva foi inserida com sucesso, falso caso contrário.
        /// </returns>
        public bool InserirReservaA()
        {
            // Instância de objetos necessários
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

            // Obtém um ID para a reserva
            id = reservas.ID(id);

            // Verifica se a inserção de reserva através do IO foi bem-sucedida
            if (!io.InserirReservaA(out dataInicio, out dataFim, out numPessoas, out clienteNIF, out quartoID, out precoTotal))
            {
                return false;
            }

            try
            {
                // Verifica se o cliente com o NIF fornecido existe
                if (clientes.ExisteCliente(clienteNIF))
                {
                    // Cria instâncias de Cliente e Quarto
                    Cliente cliente = new Cliente { NIF = clienteNIF };
                    Quarto quarto = new Quarto { ID = quartoID };

                    // Obtém o quarto escolhido a partir da lista de quartos
                    var quartoEscolhido = Quartos.QUARTO.FirstOrDefault(q => q.ID == quartoID);

                    // Obtém a capacidade do quarto escolhido
                    quantPessoas = quartos.ObterQuant(quartoEscolhido.Tipo);

                    // Validação das datas de reserva
                    if (dataInicio == dataFim || dataInicio > dataFim)
                    {
                        Console.Clear();
                        Console.WriteLine("Datas de reserva inválidas.");
                        Console.WriteLine();
                        return false;
                    }

                    // Validação do número de pessoas em relação à capacidade do quarto
                    if (numPessoas > quantPessoas)
                    {
                        Console.Clear();
                        Console.WriteLine("Número de pessoas excede a capacidade do quarto.");
                        Console.WriteLine();
                        return false;
                    }

                    // Obtém o valor do quarto escolhido
                    valorQuarto = quartoEscolhido.Valor;

                    // Lógica para calcular o preço total da reserva
                    int numDias = (int)(dataFim - dataInicio).TotalDays;
                    decimal preco = valorQuarto * numDias;
                    Console.WriteLine();
                    Console.WriteLine($"Preço total da reserva: {preco}");
                    Console.WriteLine();
                    precoTotal = preco;

                    // Cria uma instância de Reserva e a insere
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
                // Envia exceção personalizada relacionada às reservas
                throw new EReserva("Erro ao criar reserva" + "-" + r.Message);
            }
        }

        /// <summary>
        /// Remove uma reserva, verificando se a mesma existe e se não possui check-ins associados (cliente).
        /// </summary>
        /// <returns>
        /// Retorna verdadeiro se a reserva foi removida com sucesso, falso caso contrário.
        /// </returns>
        public bool RemoverReservaC()
        {
            // Instância de objetos necessários
            Reservas reservas = new Reservas();
            IO io = new IO();
            int id;

            // Obtém o ID da reserva a ser removida
            io.RemoverReservaC(out id);

            // Verifica se a reserva com o ID fornecido existe
            if (reservas.ExisteReserva(id))
            {
                // Cria uma instância de Reserva com o ID fornecido
                Reserva reserva = new Reserva();
                reserva.ID = id;

                // Verifica se a reserva possui check-ins associados
                if (Check_Ins.CHECKIN.Any(ci => ci.Reserva.ID == id))
                {
                    Console.WriteLine("Não é possível remover a reserva, pois já possui check-in efetuado.");
                    return false;
                }

                // Remove a reserva
                reservas.RemoverReserva(reserva);
                return true;
            }

            // Caso a reserva não seja encontrada
            Console.Clear();
            Console.WriteLine("Reserva não encontrada ou removida. ID não existe.");
            Console.WriteLine();
            return false;
        }

        /// <summary>
        /// Remove uma reserva, verificando se a mesma existe e se não possui check-ins associados (admin).
        /// </summary>
        /// <returns>
        /// Retorna verdadeiro se a reserva foi removida com sucesso, falso caso contrário.
        /// </returns>
        public bool RemoverReservaA()
        {
            // Instância de objetos necessários
            Reservas reservas = new Reservas();
            IO io = new IO();
            int id;

            // Obtém o ID da reserva a ser removida
            io.RemoverReservaA(out id);

            // Verifica se a reserva com o ID fornecido existe
            if (reservas.ExisteReserva(id))
            {
                // Cria uma instância de Reserva com o ID fornecido
                Reserva reserva = new Reserva();
                reserva.ID = id;

                // Verifica se a reserva possui check-ins associados
                if (Check_Ins.CHECKIN.Any(ci => ci.Reserva.ID == id))
                {
                    Console.WriteLine("Não é possível remover a reserva, pois já possui check-in efetuado.");
                    return false;
                }

                // Remove a reserva
                reservas.RemoverReserva(reserva);
                return true;
            }

            // Caso a reserva não seja encontrada
            Console.Clear();
            Console.WriteLine("Reserva não encontrada ou removida. ID não existe.");
            Console.WriteLine();
            return false;
        }

        /// <summary>
        /// Lista as reservas existentes, apresentando as informações ao cliente.
        /// </summary>
        /// <returns>
        /// Retorna verdadeiro, indicando que a operação de listagem foi concluída.
        /// </returns>
        public bool ListarReservaC()
        {
            // Instância de objeto IO
            IO io = new IO();

            // Chama o método de listagem de reservas no IO
            io.ListarReservaC();

            // Retorna verdadeiro, indicando que a operação foi concluída
            return true;
        }

        /// <summary>
        /// Lista as reservas existentes, apresentando as informações ao admin.
        /// </summary>
        /// <returns>
        /// Retorna verdadeiro, indicando que a operação de listagem foi concluída.
        /// </returns>
        public bool ListarReservaA()
        {
            // Instância de objeto IO
            IO io = new IO();

            // Chama o método de listagem de reservas no IO
            io.ListarReservaA();

            // Retorna verdadeiro, indicando que a operação foi concluída
            return true;
        }

        /// <summary>
        /// Grava uma reserva no sistema.
        /// </summary>
        /// <param name="r">String que representa a reserva a ser gravada.</param>
        /// <returns>
        /// Retorna verdadeiro, indicando que a operação de gravação foi concluída.
        /// </returns>
        public bool GravarReserva(string r)
        {
            // Instância de objeto Reservas 
            Reservas reservas = new Reservas();

            // Chama o método de gravação de reserva no objeto Reservas
            reservas.GravarReserva(r);

            // Retorna verdadeiro, indicando que a operação foi concluída
            return true;
        }

        /// <summary>
        /// Lê uma reserva do sistema.
        /// </summary>
        /// <param name="r">String que representa a reserva a ser lida.</param>
        /// <returns>
        /// Retorna verdadeiro, indicando que a operação de leitura foi concluída.
        /// </returns>
        public bool LerReserva(string r)
        {
            // Instância de objeto Reservas 
            Reservas reservas = new Reservas();

            // Chama o método de leitura de reserva no objeto Reservas
            reservas.LerReserva(r);

            // Retorna verdadeiro, indicando que a operação foi concluída
            return true;
        }

        #endregion

        #region CHECK_INS

        /// <summary>
        /// Insere um novo check-in, verificando se a reserva associada existe e se ainda não há check-in para ela.
        /// </summary>
        /// <returns>
        /// Retorna verdadeiro se o check-in foi inserido com sucesso, falso caso contrário.
        /// </returns>
        public bool InserirCheck_I()
        {
            // Instância de objetos necessários
            Reservas reservas = new Reservas();
            Check_Ins check_ins = new Check_Ins();
            IO io = new IO();
            DateTime dataCheck_I;
            DateTime dataInicio;
            DateTime dataFim;
            int reservaID;
            int id = 0;

            // Obtém um ID para o check-in
            id = check_ins.ID(id);

            // Obtém informações necessárias para o check-in através do IO
            io.InserirCheck_I(out reservaID, out dataCheck_I);

            try
            {
                // Verifica se a reserva com o ID fornecido existe
                if (reservas.ExisteReserva(reservaID))
                {
                    // Cria uma instância de Reserva associada ao check-in
                    Reserva reserva = new Reserva { ID = reservaID };

                    // Verifica se já existe um check-in para a reserva
                    foreach (var check_in in Check_Ins.CHECKIN)
                    {
                        if (check_in.Reserva.ID == reservaID)
                        {
                            Console.Clear();
                            Console.WriteLine("Já existe um check-in para a reserva desejada");
                            Console.WriteLine();
                            return false;
                        }
                    }

                    // Obtém informações da reserva escolhida
                    var reservaEscolhida = Reservas.RESERVA.FirstOrDefault(r => r.ID == reservaID);

                    // Define datas de início e fim da reserva
                    dataInicio = reservaEscolhida.DataInicio;
                    dataFim = reservaEscolhida.DataFim;

                    // Verifica se a data de check-in é válida em relação à reserva
                    if (dataCheck_I < dataInicio || dataCheck_I >= dataFim)
                    {
                        Console.Clear();
                        Console.WriteLine("Não é possível efetuar check-in para a data desejada");
                        Console.WriteLine();
                        return false;
                    }

                    // Cria uma instância de CheckIn
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
                // Envia exceção personalizada relacionada a check-ins
                throw new ECheck_In("Erro ao criar check-in" + "-" + ci.Message);
            }
        }

        /// <summary>
        /// Remove um check-in, verificando se o mesmo existe e se não possui check-outs associados.
        /// </summary>
        /// <returns>
        /// Retorna verdadeiro se o check-in foi removido com sucesso, falso caso contrário.
        /// </returns>
        public bool RemoverCheck_I()
        {
            // Instância de objetos necessários
            Check_Ins check_ins = new Check_Ins();
            IO io = new IO();
            int id;

            // Obtém o ID do check-in a ser removido
            io.RemoverCheck_I(out id);

            // Verifica se o check-in com o ID fornecido existe
            if (check_ins.ExisteCheck_I(id))
            {
                // Cria uma instância de CheckIn com o ID fornecido
                CheckIn checkin = new CheckIn();
                checkin.ID = id;

                // Verifica se o check-in possui check-outs associados
                if (Check_Outs.CHECKOUT.Any(co => co.Check_In.ID == id))
                {
                    Console.WriteLine("Não é possível remover o check-in, pois já possui check-out efetuado.");
                    return false;
                }

                // Remove o check-in
                check_ins.RemoverCheck_I(checkin);
                return true;
            }

            // Caso o check-in não seja encontrado
            Console.Clear();
            Console.WriteLine("Check-in não encontrado ou removido. ID não existe.");
            Console.WriteLine();
            return false;
        }

        /// <summary>
        /// Lista os check-ins existentes, apresentando as informações ao utilizador.
        /// </summary>
        /// <returns>
        /// Retorna verdadeiro, indicando que a operação de listagem foi concluída.
        /// </returns>
        public bool ListarCheck_I()
        {
            // Instância de objeto Check_Ins
            Check_Ins check_ins = new Check_Ins();

            // Chama o método de listagem de check-ins no objeto Check_Ins
            check_ins.ListarCheck_I();

            // Retorna verdadeiro, indicando que a operação foi concluída
            return true;
        }

        /// <summary>
        /// Grava um check-in no sistema.
        /// </summary>
        /// <param name="ci">String que representa o check-in a ser gravado.</param>
        /// <returns>
        /// Retorna verdadeiro, indicando que a operação de gravação foi concluída.
        /// </returns>
        public bool GravarCheck_I(string ci)
        {
            // Instância de objeto Check_Ins
            Check_Ins check_ins = new Check_Ins();

            // Chama o método de gravação de check-in no objeto Check_Ins
            check_ins.GravarCheck_I(ci);

            // Retorna verdadeiro, indicando que a operação foi concluída
            return true;
        }

        /// <summary>
        /// Lê um check-in do sistema.
        /// </summary>
        /// <param name="ci">String que representa o check-in a ser lido.</param>
        /// <returns>
        /// Retorna verdadeiro, indicando que a operação de leitura foi concluída.
        /// </returns>
        public bool LerCheck_I(string ci)
        {
            // Instância de objeto Check_Ins 
            Check_Ins check_ins = new Check_Ins();

            // Chama o método de leitura de check-in no objeto Check_Ins
            check_ins.LerCheck_I(ci);

            // Retorna verdadeiro, indicando que a operação foi concluída
            return true;
        }

        #endregion

        #region CHECK_OUTS

        /// <summary>
        /// Insere um novo check-out, verificando se o check-in associado existe e se ainda não há check-out para ele.
        /// </summary>
        /// <returns>
        /// Retorna verdadeiro se o check-out foi inserido com sucesso, falso caso contrário.
        /// </returns>
        public bool InserirCheck_O()
        {
            // Instância de objetos necessários
            Check_Ins check_ins = new Check_Ins();
            Check_Outs check_outs = new Check_Outs();
            IO io = new IO();
            DateTime dataCheck_O;
            DateTime dataCI;
            DateTime reservaData;
            int checkIN;
            int reservaTemp;
            int id = 0;

            // Obtém um ID para o check-out
            id = check_outs.ID(id);

            // Obtém informações necessárias para o check-out através do IO
            io.InserirCheck_O(out checkIN, out dataCheck_O);

            try
            {
                // Verifica se o check-in com o ID fornecido existe
                if (check_ins.ExisteCheck_I(checkIN))
                {
                    // Cria uma instância de CheckIn associado ao check-out
                    CheckIn checkin = new CheckIn { ID = checkIN };

                    // Verifica se já existe um check-out para o check-in
                    foreach (var check_out in Check_Outs.CHECKOUT)
                    {
                        if (check_out.Check_In.ID == checkIN)
                        {
                            Console.Clear();
                            Console.WriteLine("Já existe um check-out para o check-in desejado");
                            Console.WriteLine();
                            return false;
                        }
                    }

                    // Obtém informações do check-in escolhido
                    var checkinEscolhido = Check_Ins.CHECKIN.FirstOrDefault(ci => ci.ID == checkIN);

                    // Define datas de check-in e data final da reserva associada ao check-in
                    dataCI = checkinEscolhido.DataCheckIO;
                    reservaTemp = checkinEscolhido.Reserva.ID;

                    var reservaCI = Reservas.RESERVA.FirstOrDefault(r => r.ID == reservaTemp);

                    reservaData = reservaCI.DataFim;

                    // Valida se a data de check-out é válida em relação ao check-in e à reserva
                    if (dataCheck_O <= dataCI || dataCheck_O > reservaData)
                    {
                        Console.Clear();
                        Console.WriteLine("Não é possível efetuar check-out para a data desejada");
                        Console.WriteLine();
                        return false;
                    }

                    // Cria uma instância de CheckOut 
                    CheckOut checkout = new CheckOut(id, checkin, dataCheck_O);
                    check_outs.InserirCheck_O(checkout);
                    return true;
                }

                Console.Clear();
                Console.WriteLine("Não existe nenhum check-in com o ID indicado");
                Console.WriteLine();
                return false;
            }
            catch (ECheck_Out co)
            {
                // Envia exceção personalizada relacionada a check-outs
                throw new ECheck_Out("Erro ao criar check-out" + "-" + co.Message);
            }
        }

        /// <summary>
        /// Remove um check-out, verificando se o mesmo existe.
        /// </summary>
        /// <returns>
        /// Retorna verdadeiro se o check-out foi removido com sucesso, falso caso contrário.
        /// </returns>
        public bool RemoverCheck_O()
        {
            // Instância de objetos necessários
            Check_Outs check_outs = new Check_Outs();
            IO io = new IO();
            int id;

            // Obtém o ID do check-out a ser removido
            io.RemoverCheck_O(out id);

            // Verifica se o check-out com o ID fornecido existe
            if (check_outs.ExisteCheck_O(id))
            {
                // Cria uma instância de CheckOut com o ID fornecido
                CheckOut checkout = new CheckOut { ID = id };
                check_outs.RemoverCheck_O(checkout);

                return true;
            }

            // Caso o check-out não seja encontrado
            Console.Clear();
            Console.WriteLine("Check-out não encontrado ou removido. ID não existe.");
            Console.WriteLine();
            return false;
        }

        /// <summary>
        /// Lista os check-outs existentes, apresentando as informações ao utilizador.
        /// </summary>
        /// <returns>
        /// Retorna verdadeiro, indicando que a operação de listagem foi concluída.
        /// </returns>
        public bool ListarCheck_O()
        {
            // Instância de objeto Check_Outs
            Check_Outs check_outs = new Check_Outs();

            // Chama o método de listagem de check-outs no objeto Check_Outs
            check_outs.ListarCheck_O();

            // Retorna verdadeiro, indicando que a operação foi concluída
            return true;
        }

        /// <summary>
        /// Grava um check-out no sistema.
        /// </summary>
        /// <param name="co">String que representa o check-out a ser gravado.</param>
        /// <returns>
        /// Retorna verdadeiro, indicando que a operação de gravação foi concluída.
        /// </returns>
        public bool GravarCheck_O(string co)
        {
            // Instância de objeto Check_Outs 
            Check_Outs check_outs = new Check_Outs();

            // Chama o método de gravação de check-out no objeto Check_Outs
            check_outs.GravarCheck_O(co);

            // Retorna verdadeiro, indicando que a operação foi concluída
            return true;
        }

        /// <summary>
        /// Lê um check-out do sistema.
        /// </summary>
        /// <param name="co">String que representa o check-out a ser lido.</param>
        /// <returns>
        /// Retorna verdadeiro, indicando que a operação de leitura foi concluída.
        /// </returns>
        public bool LerCheck_O(string co)
        {
            // Instância de objeto Check_Outs
            Check_Outs check_outs = new Check_Outs();

            // Chama o método de leitura de check-out no objeto Check_Outs
            check_outs.LerCheck_O(co);

            // Retorna verdadeiro, indicando que a operação foi concluída
            return true;
        }

        #endregion
    }
}
