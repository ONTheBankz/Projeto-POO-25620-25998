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

namespace DLL_Dados
{
    public class Clientes : ICliente
    {
        #region ESTADO
        static List<Cliente> clientes;
        #endregion

        #region CONSTRUTORES
        static Clientes()
        {
            clientes = new List<Cliente>();
        }
        #endregion

        #region PROPRIEDADES
        public static List<Cliente> CLIENTE
        {
            get { return clientes; }
            set { clientes = value; }
        }

        #endregion

        #region OUTROS MÉTODOS

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

        public bool InserirCliente(Cliente c)
        {
            clientes.Add(c);
            return true;
        }

        public bool RemoverCliente(Cliente c)
        {
            clientes.Remove(c);
            return true;
        }

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