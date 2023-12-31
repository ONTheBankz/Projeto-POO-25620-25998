/// <summary>
/// Classe para criação de funções Cliente
/// David Martinho
/// Rafael Rodrigues
/// a25620@alunos.ipca.pt
/// a25998@alunos.ipca.pt
/// 09-11-2023
/// POO-LESI
/// </summary>

using System;
using System.Collections.Generic;
using System.IO;
using DLL_Objetos;
using DLL_Exceptions;
using System.Linq;

namespace DLL_Dados
{
    public class Clientes : ICliente
    {
        #region ESTADO

        /// <summary>
        /// Lista que contém os clientes.
        /// </summary>

        static List<Cliente> clientes;
        #endregion

        #region CONSTRUTORES

        /// <summary>
        /// Construtor que inicializa a lista dos clientes.
        /// </summary>

        static Clientes()
        {
            clientes = new List<Cliente>();
        }
        #endregion

        #region PROPRIEDADES

        /// <summary>
        /// Propriedade que acede à lista dos clientes.
        /// </summary>

        public static List<Cliente> CLIENTE
        {
            get { return clientes; }
            set { clientes = value; }
        }

        #endregion

        #region OUTROS MÉTODOS

        /// <summary>
        /// Grava os detalhes dos clientes num ficheiro.
        /// </summary>
        /// <param name="c">Caminho do ficheiro onde os dados dos clientes serão gravados.</param>
        /// <returns>Verdadeiro se a gravação for bem-sucedida, falso caso contrário.</returns>
        public bool GravarCliente(string c)
        {
            try
            {
                // Cria um StreamWriter para escrever no ficheiro especificado.
                using (StreamWriter writer = File.CreateText(c))
                {
                    // Itera sobre a lista de clientes e escreve os detalhes no ficheiro.
                    foreach (var cliente in clientes)
                    {
                        writer.WriteLine($"{cliente.Nome}#{cliente.Morada}#{cliente.Email}#{cliente.Password}#{cliente.Contacto}#{cliente.DataNascimento}#{cliente.NIF}");
                    }
                }
                return true; // Retorna verdadeiro indicando que a gravação foi bem-sucedida.
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao gravar clientes: {ex.Message}");
                return false; // Retorna falso se ocorrer uma exceção durante a gravação.
            }
        }

        /// <summary>
        /// Lê os detalhes dos clientes a partir de um ficheiro e preenche a lista de clientes com esses detalhes.
        /// </summary>
        /// <param name="c">Caminho do ficheiro de onde os detalhes dos clientes serão lidos.</param>
        /// <returns>Verdadeiro se a leitura for bem-sucedida, falso caso contrário.</returns>
        public bool LerCliente(string c)
        {
            if (!File.Exists(c))
            {
                // Se o ficheiro não existir, cria um novo ficheiro vazio.
                using (File.Create(c)) { }
                return false; // Retorna falso porque não há dados para ler.
            }
            // Utiliza um StreamReader para ler o conteúdo do ficheiro.
            using (StreamReader sr = File.OpenText(c))
            {
                string linha = sr.ReadLine();
                while (linha != null)
                {
                    // Divide a linha em partes usando '#' como delimitador.
                    string[] sdados = linha.Split('#');

                    // Converte os dados para os tipos apropriados.
                    string nome = sdados[0];
                    string morada = sdados[1];
                    string email = sdados[2];
                    string password = sdados[3];
                    int contacto = int.Parse(sdados[4]);
                    DateTime datanasc = DateTime.Parse(sdados[5]);
                    int nif = int.Parse(sdados[6]);

                    // Cria um objeto Cliente com os detalhes lidos e adiciona à lista.
                    Cliente cliente = new Cliente(nome, morada, email, password, contacto, datanasc, nif);
                    clientes.Add(cliente);

                    linha = sr.ReadLine(); // Lê a próxima linha.
                }
            }
            return true; // Retorna verdadeiro indicando que a leitura foi bem-sucedida.
        }

        /// <summary>
        /// Insere um novo cliente na lista de clientes.
        /// </summary>
        /// <param name="c">Objeto Cliente a ser inserido na lista.</param>
        /// <returns>Verdadeiro se a inserção for bem-sucedida.</returns>
        public bool InserirCliente(Cliente c)
        {
            // Adiciona o cliente à lista de clientes.
            clientes.Add(c);
            return true; // Retorna verdadeiro indicando que a inserção foi bem-sucedida.
        }

        /// <summary>
        /// Remove um cliente da lista de clientes.
        /// </summary>
        /// <param name="c">Objeto Cliente a ser removido da lista.</param>
        /// <returns>Verdadeiro se a remoção for bem-sucedida.</returns>
        public bool RemoverCliente(Cliente c)
        {
            // Remove o cliente da lista de clientes.
            clientes.Remove(c);
            return true; // Retorna verdadeiro indicando que a remoção foi bem-sucedida.
        }

        /// <summary>
        /// Lista os detalhes do(s) cliente(s) na consola.
        /// </summary>
        /// <returns>Verdadeiro se a listagem for bem-sucedida.</returns>
        public bool ListarClientes()
        {
            // Percorre a lista de clientes e imprime os detalhes na consola.
            foreach (Cliente cliente in CLIENTE)
            {
                Console.WriteLine("Nome: {0}\nMorada: {1}\nEmail: {2}\nPassword: {3}\nContacto: {4}\nData Nascimento: {5}\nNIF: {6}\n",
                                 cliente.Nome, cliente.Morada, cliente.Email, cliente.Password, cliente.Contacto,
                                 cliente.DataNascimento.ToShortDateString(), cliente.NIF);
            }
            return true; // Retorna verdadeiro indicando que a listagem foi bem-sucedida.
        }

        /// <summary>
        /// Edita as propriedades de um cliente com base nas opções fornecidas.
        /// </summary>
        /// <param name="op">Opção que indica qual propriedade do cliente será editada.</param>
        /// <param name="nome">Novo valor para o nome.</param>
        /// <param name="morada">Novo valor para a morada.</param>
        /// <param name="email">Novo valor para o email.</param>
        /// <param name="password">Nova password.</param>
        /// <param name="contacto">Novo valor para o contacto.</param>
        /// <param name="datanasc">Nova data de nascimento.</param>
        /// <param name="nif">Novo valor para o NIF.</param>
        /// <param name="NIFC">NIF do cliente a ser editado.</param>
        /// <returns>Retorna true se a edição for bem-sucedida; caso contrário, retorna false.</returns>
        public bool EditarCliente(int op, string nome, string morada, string email, string password, int contacto, DateTime datanasc, int nif, int NIFC)
        {
            // Verifica se o cliente com o NIF dado pelo user existe
            if (ExisteCliente(NIFC))
            {
                // Obtém o cliente com base no NIF fornecido
                Cliente cliente = clientes.FirstOrDefault(c => c.NIF == NIFC);

                // Executa a operação de edição com base na opção fornecida
                switch (op)
                {
                    case 1:
                        cliente.Nome = nome;
                        return true;
                    case 2:
                        cliente.Morada = morada;
                        return true;
                    case 3:
                        cliente.Email = email;
                        return true;
                    case 4:
                        cliente.Password = password;
                        return true;
                    case 5:
                        cliente.Contacto = contacto;
                        return true;
                    case 6:
                        cliente.DataNascimento = datanasc;
                        return true;
                    case 7:
                        cliente.NIF = nif;
                        return true;
                    default:
                        // Operação não suportada
                        return false;
                }
            }

            // Cliente com NIF dado pelo utilizador não existe
            Console.WriteLine("Cliente com NIF não encontrado.");
            return false;
        }

        /// <summary>
        /// Verifica se existe um cliente com o NIF fornecido na lista de clientes.
        /// </summary>
        /// <param name="NIF">NIF do cliente a ser verificado.</param>
        /// <returns>Verdadeiro se um cliente com o NIF fornecido existir, falso caso contrário.</returns>
        public bool ExisteCliente(int NIF)
        {
            // Percorre a lista de clientes para verificar se existe um cliente com o NIF fornecido
            foreach (Cliente cliente in clientes)
            {
                if (cliente.NIF == NIF)
                {
                    return true; // Retorna verdadeiro se encontrar um cliente com o NIF fornecido
                }
            }
            return false; // Retorna falso se nenhum cliente com o NIF fornecido for encontrado
        }

        /// <summary>
        /// Autentica um cliente comparando o NIF e a Password fornecidos.
        /// </summary>
        /// <param name="NIF">NIF do cliente a ser autenticado.</param>
        /// <param name="Password">Password do cliente a ser verificada.</param>
        /// <returns>Verdadeiro se a autenticação for bem-sucedida, falso caso contrário.</returns>
        public bool AuthCliente(int NIF, string Password)
        {
            // Percorre a lista de clientes para verificar a autenticação com base no NIF e na Password
            foreach (Cliente cliente in clientes)
            {
                if (cliente.NIF == NIF && cliente.Password == Password)
                {
                    return true; // Retorna verdadeiro se a autenticação for bem-sucedida
                }
            }
            return false; // Retorna falso indicando que a autenticação falhou
        }

        #endregion
    }
}