/// <summary>
/// Classe para criação de funções Funcionario
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
    public class Funcionarios : IFuncionario
    {
        #region ESTADO

        /// <summary>
        /// Lista que contém os funcionários.
        /// </summary>

        static List<Funcionario> funcionarios;
        #endregion

        #region CONSTRUTORES

        /// <summary>
        /// Construtor que inicializa a lista dos funcionários.
        /// </summary>

        static Funcionarios()
        {
            funcionarios = new List<Funcionario>();
        }
        #endregion

        #region PROPRIEDADES

        /// <summary>
        /// Propriedade que acede à lista dos funcionários.
        /// </summary>

        public static List<Funcionario> FUNCIONARIO
        {
            get { return funcionarios; }
            set { funcionarios = value; }
        }

        #endregion

        #region OUTROS MÉTODOS

        /// <summary>
        /// Grava os detalhes dos funcionários num ficheiro.
        /// </summary>
        /// <returns> Verdadeiro se a gravação for bem-sucedida, falso caso contrário. </returns>

        public bool GravarFunc(string f)
        {
            try
            {
                using (StreamWriter writer = File.CreateText(f))
                {
                    foreach (var funcionario in funcionarios)
                    {
                        writer.WriteLine($"{funcionario.ID}#{funcionario.Nome}#{funcionario.Email}#{funcionario.Password}#{funcionario.Contacto}#{funcionario.DataNascimento}#{funcionario.Alojamento.ID}");
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao gravar funcionario: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Lê os detalhes dos funcionários a partir de um ficheiro e preenche a lista de funcionários com esses detalhes.
        /// </summary>
        /// <returns> Verdadeiro se a leitura for bem-sucedida, falso caso contrário. </returns>

        public bool LerFunc(string f)
        {
            if (!File.Exists(f))
            {
                // Se o ficheiro não existir, cria um novo ficheiro vazio
                using (File.Create(f)) { }
                return false; // Retorna falso porque não há dados para ler
            }

            using (StreamReader sr = File.OpenText(f))
            {
                string linha = sr.ReadLine();
                while (linha != null)
                {
                    string[] sdados = linha.Split('#');
                    int idFunc = int.Parse(sdados[0]);
                    string nome = sdados[1];
                    string email = sdados[2];
                    string password = sdados[3];
                    int contacto = int.Parse(sdados[4]);
                    DateTime datanasc = DateTime.Parse(sdados[5]);
                    int alojamentoID = int.Parse(sdados[6]);

                    Alojamento alojamento = new Alojamento { ID = alojamentoID };

                    Funcionario funcionario = new Funcionario(idFunc, nome, email, password, contacto, datanasc, alojamento);

                    funcionarios.Add(funcionario);

                    linha = sr.ReadLine();
                }
            }
            return true;
        }

        /// <summary>
        /// Insere um novo funcionário na lista de funcionários.
        /// </summary>
        /// <returns> Verdadeiro se a inserção for bem-sucedida. </returns>

        public bool InserirFunc(Funcionario f)
        {
            funcionarios.Add(f);
            return true;
        }

        /// <summary>
        /// Remove um funcionário da lista de funcionários.
        /// </summary>
        /// <returns> Verdadeiro se a remoção for bem-sucedida. </returns>

        public bool RemoverFunc(Funcionario f)
        {
            funcionarios.Remove(f);
            return true;
        }

        /// <summary>
        /// Lista os detalhes do(s) funcionário(s) na consola.
        /// </summary>
        /// <returns>Verdadeiro se a listagem for bem-sucedida.</returns>

        public bool ListarFunc()
        {
            foreach (Funcionario funcionario in FUNCIONARIO)
            {
                Console.WriteLine("ID: {0}\nNome: {1}\nEmail: {2}\nPassword: {3}\nContacto: {4}\nData Nascimento: {5}\nID Alojamento: {6}\n",
                                 funcionario.ID, funcionario.Nome, funcionario.Email, funcionario.Password, funcionario.Contacto,
                                 funcionario.DataNascimento.ToShortDateString(), funcionario.Alojamento.ID);
            }
            return true;
        }

        /// <summary>
        /// Verifica se existe um funcionário com o ID fornecido na lista de funcionários.
        /// </summary>
        /// <param name="ID"> ID do funcionário a ser verificado. </param>
        /// <returns> Verdadeiro se um funcionário com o ID fornecido existir, falso caso contrário. </returns>

        public bool ExisteFunc(int ID)
        {
            foreach (Funcionario funcionario in funcionarios)
            {
                if (funcionario.ID == ID)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Autentica um funcionário comparando o ID e a Password fornecidos.
        /// </summary>
        /// <param name="ID"> ID do funcionário. </param>
        /// <param name="Password"> Password do funcionário. </param>
        /// <returns> Verdadeiro se a autenticação for bem-sucedida, falso caso contrário. </returns>

        public bool AuthFunc(int ID, string Password)
        {
            foreach (Funcionario funcionario in funcionarios)
            {
                if (funcionario.ID == ID && funcionario.Password == Password)
                {
                    return true;
                }
            }
            return false; // Alterado de true para false, indicando que a autenticação falhou.
        }

        #endregion
    }
}