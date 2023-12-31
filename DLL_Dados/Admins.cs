/// <summary>
/// Classe para criação de funções Admin
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
    public class Admins : IAdmin
    {
        #region ESTADO

        /// <summary>
        /// Lista que contém os administradores.
        /// </summary>

        static List<Admin> admins;
        #endregion

        #region CONSTRUTORES

        /// <summary>
        /// Construtor que inicializa a lista de administradores.
        /// </summary>

        static Admins()
        {
            admins = new List<Admin>();
        }
        #endregion

        #region PROPRIEDADES

        /// <summary>
        /// Propriedade que acede à lista de administradores.
        /// </summary>

        public static List<Admin> ADMIN
        {
            get { return admins; }
            set { admins = value; }
        }

        #endregion

        #region OUTROS MÉTODOS

        /// <summary>
        /// Lê os dados de um ficheiro e preenche a lista de administradores com esses dados.
        /// </summary>
        /// <param name="a">Caminho do ficheiro a ser lido.</param>
        /// <returns>Verdadeiro se a leitura foi bem-sucedida, falso caso contrário.</returns>
        public bool LerAdmin(string a)
        {
            // Verifica se o ficheiro especificado existe.
            if (!File.Exists(a))
            {
                // Se o ficheiro não existir, cria um novo ficheiro vazio.
                using (File.Create(a)) { }
                return false; // Retorna falso porque não há dados para ler.
            }

            // Utiliza um bloco 'using' para garantir que o StreamReader é corretamente fechado ao finalizar.
            using (StreamReader sr = File.OpenText(a))
            {
                // Lê a primeira linha do ficheiro.
                string linha = sr.ReadLine();

                // Continua a ler enquanto houver linhas no ficheiro.
                while (linha != null)
                {
                    // Divide a linha usando '#' como delimitador para obter os diferentes campos.
                    string[] sdados = linha.Split('#');

                    // Converte os dados para os tipos apropriados.
                    int id = int.Parse(sdados[0]);
                    string nome = (sdados[1]);
                    string email = (sdados[2]);
                    string password = (sdados[3]);
                    int contacto = int.Parse((sdados[4]));
                    DateTime datanasc = DateTime.Parse(sdados[5]);

                    // Cria um novo objeto Admin com os dados lidos.
                    Admin admin = new Admin(id, nome, email, password, contacto, datanasc);

                    // Adiciona o administrador à lista.
                    admins.Add(admin);

                    // Lê a próxima linha do ficheiro.
                    linha = sr.ReadLine();
                }
            }

            return true; // Indica que a leitura foi bem-sucedida.
        }

        /// <summary>
        /// Verifica se existe um administrador com o ID fornecido na lista de administradores.
        /// </summary>
        /// <param name="ID">ID do administrador a ser verificado.</param>
        /// <returns>Verdadeiro se um administrador com o ID fornecido existir, falso caso contrário.</returns>
        public bool ExisteAdmin(int ID)
        {
            // Percorre todos os administradores na lista.
            foreach (Admin admin in admins)
            {
                // Verifica se o ID do administrador atual corresponde ao ID fornecido.
                if (admin.ID == ID)
                {
                    return true; // Retorna verdadeiro se encontrar um administrador com o ID fornecido.
                }
            }
            return false; // Retorna falso se nenhum administrador com o ID fornecido for encontrado.
        }

        /// <summary>
        /// Autentica um administrador com base no ID e na password fornecidos.
        /// </summary>
        /// <param name="ID">ID do administrador a ser autenticado.</param>
        /// <param name="Password">Password do administrador a ser verificada.</param>
        /// <returns>Verdadeiro se a autenticação for bem-sucedida, falso caso contrário.</returns>
        public bool AuthAdmin(int ID, string Password)
        {
            // Percorre todos os administradores na lista.
            foreach (Admin admin in admins)
            {
                // Verifica se o ID e a password do administrador atual correspondem aos fornecidos.
                if (admin.ID == ID && admin.Password == Password)
                {
                    return true; // Retorna verdadeiro se a autenticação for bem-sucedida.
                }
            }
            return false; // Retorna falso se a autenticação falhar.
        }

        #endregion

    }
}