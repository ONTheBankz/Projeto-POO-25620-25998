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
        /// <returns> Verdadeiro se a gravação for bem-sucedida, falso caso contrário. </returns>

        public bool GravarCliente(string c)
        {
            try
            {
                using (StreamWriter writer = File.CreateText(c))
                {
                    foreach (var cliente in clientes)
                    {
                        writer.WriteLine($"{cliente.Nome}#{cliente.Morada}#{cliente.Email}#{cliente.Password}#{cliente.Contacto}#{cliente.DataNascimento}#{cliente.NIF}");
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao gravar clientes: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Lê os detalhes dos clientes a partir de um ficheiro e preenche a lista de clientes com esses detalhes.
        /// </summary>
        /// <returns> Verdadeiro se a leitura for bem-sucedida, falso caso contrário. </returns>

        public bool LerCliente(string c)
        {
            if (!File.Exists(c))
            {
                // Se o ficheiro não existir, cria um novo ficheiro vazio
                using (File.Create(c)) { }
                return false; // Retorna falso porque não há dados para ler
            }
            using (StreamReader sr = File.OpenText(c))
            {
                string linha = sr.ReadLine();
                while (linha != null)
                {
                    string[] sdados = linha.Split('#');
                    string nome = (sdados[0]);
                    string morada = (sdados[1]);
                    string email = (sdados[2]);
                    string password = (sdados[3]);
                    int contacto = int.Parse(sdados[4]);
                    DateTime datanasc = DateTime.Parse(sdados[5]);
                    int nif = int.Parse(sdados[6]);

                    Cliente cliente = new Cliente(nome, morada, email, password, contacto, datanasc, nif);

                    clientes.Add(cliente);

                    linha = sr.ReadLine();
                }
            }
            return true;
        }

        /// <summary>
        /// Insere um novo cliente na lista de clientes.
        /// </summary>
        /// <returns> Verdadeiro se a inserção for bem-sucedida. </returns>

        public bool InserirCliente(Cliente c)
        {
            clientes.Add(c);
            return true;
        }

        /// <summary>
        /// Remove um cliente da lista de clientes.
        /// </summary>
        /// <returns> Verdadeiro se a remoção for bem-sucedida. </returns>

        public bool RemoverCliente(Cliente c)
        {
            clientes.Remove(c);
            return true;
        }

        /// <summary>
        /// Lista os detalhes do(s) cliente(s) na consola.
        /// </summary>
        /// <returns> Verdadeiro se a listagem for bem-sucedida. </returns>

        public bool ListarClientes()
        {
            foreach (Cliente cliente in CLIENTE)
            {
                Console.WriteLine("Nome: {0}\nMorada: {1}\nEmail: {2}\nPassword: {3}\nContacto: {4}\nData Nascimento: {5}\nNIF: {6}\n",
                                 cliente.Nome, cliente.Morada, cliente.Email, cliente.Password, cliente.Contacto,
                                 cliente.DataNascimento.ToShortDateString(), cliente.NIF);
            }
            return true;
        }

        public bool EditarCliente(int op, string nome, string morada, string email, string password, int contacto, DateTime datanasc, int nif, int NIFC)
        {
            // Verifica se o cliente com NIFC existe
            if (ExisteCliente(NIFC))
            {
                Cliente cliente = clientes.FirstOrDefault(c => c.NIF == NIFC);

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
                Console.WriteLine();
                // Cliente com NIF dado pelo user não existe
                Console.WriteLine("Cliente com NIF não encontrado.");
                return false;
            }
        
        /// <summary>
        /// Verifica se existe um cliente com o NIF fornecido na lista de clientes.
        /// </summary>
        /// <param name="NIF"> NIF do cliente a ser verificado. </param>
        /// <returns> Verdadeiro se um cliente com o NIF fornecido existir, falso caso contrário. </returns>

        public bool ExisteCliente(int NIF)
        {
            foreach (Cliente cliente in clientes)
            {
                if (cliente.NIF == NIF)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Autentica um cliente comparando o NIF e a Password fornecidos.
        /// </summary>
        /// <param name="NIF"> NIF do cliente. </param>
        /// <param name="Password"> Password do cliente. </param>
        /// <returns> Verdadeiro se a autenticação for bem-sucedida, falso caso contrário. </returns>

        public bool AuthCliente(int NIF, string Password)
        {
            foreach (Cliente cliente in clientes)
            {
                if (cliente.NIF == NIF && cliente.Password == Password)
                {
                    return true;
                }
            }
            return false; // Alterado de true para false, indicando que a autenticação falhou.
        }

        #endregion
    }
}