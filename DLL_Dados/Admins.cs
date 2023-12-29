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
        /// <returns> Verdadeiro se a leitura foi bem-sucedida, falso caso contrário. </returns>

        public bool LerAdmin(string a)
        {
            if (!File.Exists(a))
            {
                // Se o ficheiro não existir, cria um novo ficheiro vazio
                using (File.Create(a)) { }
                return false; // Retorna falso porque não há dados para ler
            }
            using (StreamReader sr = File.OpenText(a))
            {
                string linha = sr.ReadLine();
                while (linha != null)
                {
                    string[] sdados = linha.Split('#');
                    int id = int.Parse(sdados[0]);
                    string nome = (sdados[1]);
                    string email = (sdados[2]);
                    string password = (sdados[3]);
                    int contacto = int.Parse((sdados[4]));
                    DateTime datanasc = DateTime.Parse(sdados[5]);

                    Admin admin = new Admin(id, nome, email, password, contacto, datanasc);

                    admins.Add(admin);

                    linha = sr.ReadLine();
                }
            }
            return true;
        }

        /// <summary>
        /// Verifica se existe um administrador com o ID fornecido na lista de administradores.
        /// </summary>
        /// <param name="ID"> ID do administrador a ser verificado. </param>
        /// <returns> Verdadeiro se um administrador com o ID fornecido existir, falso caso contrário. </returns>

        public bool ExisteAdmin(int ID)
        {
            foreach (Admin admin in admins)
            {
                if (admin.ID == ID)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Autentica um administrador com base no ID e na password fornecidos.
        /// </summary>
        /// <param name="ID"> ID do administrador a ser autenticado. </param>
        /// <param name="Password"> Password do administrador a ser verificada. </param>
        /// <returns> Verdadeiro se a autenticação for bem-sucedida, falso caso contrário. </returns>

        public bool AuthAdmin(int ID, string Password)
        {
            foreach (Admin admin in admins)
            {
                if (admin.ID == ID && admin.Password == Password)
                {
                    return true;
                }
            }
            return false; // Alterado de true para false, indicando que a autenticação falhou.
        }

        #endregion

    }
}