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
using System.Linq;
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
        /// <param name="f">Caminho do ficheiro onde os dados dos funcionários serão gravados.</param>
        /// <returns>Verdadeiro se a gravação for bem-sucedida, falso caso contrário.</returns>
        public bool GravarFunc(string f)
        {
            try
            {
                using (StreamWriter writer = File.CreateText(f))
                {
                    // Escreve os detalhes de cada funcionário no ficheiro
                    foreach (var funcionario in funcionarios)
                    {
                        writer.WriteLine($"{funcionario.ID}#{funcionario.Nome}#{funcionario.Email}#{funcionario.Password}#{funcionario.Contacto}#{funcionario.DataNascimento}#{funcionario.Alojamento.ID}");
                    }
                }
                return true; // Retorna verdadeiro se a gravação for bem-sucedida
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao gravar funcionário: {ex.Message}");
                return false; // Retorna falso se ocorrer um erro durante a gravação
            }
        }

        /// <summary>
        /// Lê os detalhes dos funcionários a partir de um ficheiro e preenche a lista de funcionários com esses detalhes.
        /// </summary>
        /// <param name="f">Objeto Funcionario a ser inserido na lista.</param>
        /// <returns>Verdadeiro se a leitura for bem-sucedida, falso caso contrário.</returns>
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
                    // Divide a linha em substrings usando '#' como delimitador
                    string[] sdados = linha.Split('#');
                    // Converte os dados para os tipos apropriados
                    int idFunc = int.Parse(sdados[0]);
                    string nome = sdados[1];
                    string email = sdados[2];
                    string password = sdados[3];
                    int contacto = int.Parse(sdados[4]);
                    DateTime datanasc = DateTime.Parse(sdados[5]);
                    int alojamentoID = int.Parse(sdados[6]);

                    // Cria instâncias de Alojamento e Funcionário com os dados lidos
                    Alojamento alojamento = new Alojamento { ID = alojamentoID };
                    Funcionario funcionario = new Funcionario(idFunc, nome, email, password, contacto, datanasc, alojamento);

                    // Adiciona o funcionário à lista de funcionários
                    funcionarios.Add(funcionario);

                    // Lê a próxima linha
                    linha = sr.ReadLine();
                }
            }
            return true; // Retorna verdadeiro se a leitura for bem-sucedida
        }

        /// <summary>
        /// Insere um novo funcionário na lista de funcionários.
        /// </summary>
        /// <param name="funcionario">Funcionário a ser inserido.</param>
        /// <returns>Verdadeiro se a inserção for bem-sucedida.</returns>
        public bool InserirFunc(Funcionario funcionario)
        {
            funcionarios.Add(funcionario);
            return true;
        }

        /// <summary>
        /// Remove um funcionário da lista de funcionários.
        /// </summary>
        /// <param name="funcionario">Funcionário a ser removido.</param>
        /// <returns>Verdadeiro se a remoção for bem-sucedida.</returns>
        public bool RemoverFunc(Funcionario funcionario)
        {
            funcionarios.Remove(funcionario);
            return true;
        }

        /// <summary>
        /// Edita as propriedades de um funcionário com base nas opções fornecidas.
        /// </summary>
        /// <param name="op">Operação a ser realizada: 1 - Nome, 2 - Email, 3 - Password, 4 - Contacto, 5 - Data de Nascimento, 6 - Alojamento ID</param>
        /// <param name="nome">Novo valor para o nome do funcionário (usado se op = 1).</param>
        /// <param name="email">Novo valor para o email do funcionário (usado se op = 2).</param>
        /// <param name="password">Novo valor para a password do funcionário (usado se op = 3).</param>
        /// <param name="contacto">Novo valor para o contacto do funcionário (usado se op = 4).</param>
        /// <param name="datanasc">Nova data de nascimento do funcionário (usado se op = 5).</param>
        /// <param name="IDF">ID do funcionário a ser editado.</param>
        /// <param name="alojamentoID">Novo ID do alojamento associado ao funcionário (usado se op = 6).</param>
        /// <returns>Retorna true se a edição for bem-sucedida; caso contrário, retorna false.</returns>
        public bool EditarFunc(int op, string nome, string email, string password, int contacto, DateTime datanasc, int IDF, int alojamentoID)
        {
            // Verifica se o funcionário com o ID existe
            if (ExisteFunc(IDF))
            {
                // Obtém o funcionário com o ID
                Funcionario funcionario = funcionarios.FirstOrDefault(f => f.ID == IDF);

                switch (op)
                {
                    case 1:
                        // Edita o nome do funcionário
                        funcionario.Nome = nome;
                        return true;

                    case 2:
                        // Edita o email do funcionário
                        funcionario.Email = email;
                        return true;

                    case 3:
                        // Edita a password do funcionário
                        funcionario.Password = password;
                        return true;

                    case 4:
                        // Edita o contacto do funcionário
                        funcionario.Contacto = contacto;
                        return true;

                    case 5:
                        // Edita a data de nascimento do funcionário
                        funcionario.DataNascimento = datanasc;
                        return true;

                    case 6:
                        // Verifica se existe um alojamento com o ID desejado
                        if (Alojamentos.ALOJAMENTO.Any(a => a.ID == alojamentoID))
                        {
                            // Edita o ID do alojamento associado ao funcionário
                            funcionario.Alojamento.ID = alojamentoID;
                            return true;
                        }
                        // Alojamento não encontrado
                        Console.WriteLine("Alojamento não encontrado.");
                        return false;

                    default:
                        // Operação não suportada
                        return false;
                }
            }
            // Funcionário não encontrado
            Console.WriteLine("Funcionário não encontrado.");
            return false;
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