/// <summary>
/// Classe para criação de funções Alojamento
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
    public class Alojamentos : IAlojamento
    {
        #region ESTADO

        /// <summary>
        /// Lista que contém os alojamentos.
        /// </summary>

        static List<Alojamento> alojamentos;
        #endregion

        #region CONSTRUTORES

        /// <summary>
        /// Construtor que inicializa a lista de alojamentos.
        /// </summary>

        static Alojamentos()
        {
            alojamentos = new List<Alojamento>();
        }
        #endregion

        #region PROPRIEDADES

        /// <summary>
        /// Propriedade que acede à lista de alojamentos.
        /// </summary>

        public static List<Alojamento> ALOJAMENTO
        {
            get { return alojamentos; }
            set { alojamentos = value; }
        }

        #endregion

        #region OUTROS MÉTODOS

        /// <summary>
        /// Grava os detalhes dos alojamentos num ficheiro.
        /// </summary>
        /// <param name="al">Caminho do ficheiro onde os detalhes dos alojamentos serão gravados.</param>
        /// <returns>Verdadeiro se a gravação for bem-sucedida, falso caso contrário.</returns>
        public bool GravarAlojamento(string al)
        {
            try
            {
                // Utiliza um StreamWriter para criar um novo ficheiro ou substituir o conteúdo existente.
                using (StreamWriter writer = File.CreateText(al))
                {
                    // Itera sobre cada alojamento na lista de alojamentos.
                    foreach (var alojamento in alojamentos)
                    {
                        // Grava os detalhes do alojamento no ficheiro, separados por '#' e seguidos por uma quebra de linha.
                        writer.WriteLine($"{alojamento.ID}#{alojamento.Nome}#{alojamento.Tipo}#{alojamento.Localizacao}");
                    }
                }
                return true; // Retorna verdadeiro se a gravação for bem-sucedida.
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao gravar alojamentos: {ex.Message}");
                return false; // Retorna falso se ocorrer um erro durante a gravação.
            }
        }

        /// <summary>
        /// Lê os detalhes dos alojamentos a partir de um ficheiro e preenche a lista de alojamentos com esses detalhes.
        /// </summary>
        /// <param name="al">Caminho do ficheiro onde os detalhes dos alojamentos estão armazenados.</param>
        /// <returns>Verdadeiro se a leitura for bem-sucedida, falso caso contrário.</returns>
        public bool LerAlojamento(string al)
        {
            if (!File.Exists(al))
            {
                // Se o ficheiro não existir, cria um novo ficheiro vazio.
                using (File.Create(al)) { }
                return false; // Retorna falso porque não há dados para ler.
            }
            using (StreamReader sr = File.OpenText(al))
            {
                string linha = sr.ReadLine();
                while (linha != null)
                {
                    // Divide a linha em partes usando '#' como delimitador.
                    string[] sdados = linha.Split('#');

                    // Converte os dados obtidos para os tipos apropriados.
                    int id = int.Parse(sdados[0]);
                    string nome = (sdados[1]);
                    string tipo = (sdados[2]);
                    string localizacao = (sdados[3]);

                    // Cria uma instância de Alojamento com os dados lidos.
                    Alojamento alojamento = new Alojamento(id, nome, tipo, localizacao);

                    // Adiciona o alojamento à lista de alojamentos.
                    alojamentos.Add(alojamento);

                    linha = sr.ReadLine(); // Lê a próxima linha do ficheiro.
                }
            }
            return true; // Retorna verdadeiro se a leitura for bem-sucedida.
        }

        /// <summary>
        /// Insere um alojamento na lista de alojamentos.
        /// </summary>
        /// <param name="al">Instância de Alojamento a ser inserida na lista.</param>
        /// <returns>Verdadeiro se a inserção for bem-sucedida.</returns>
        public bool InserirAlojamento(Alojamento al)
        {
            alojamentos.Add(al); // Adiciona o alojamento à lista de alojamentos.
            return true; // Retorna verdadeiro indicando que a inserção foi bem-sucedida.
        }

        /// <summary>
        /// Remove um alojamento da lista de alojamentos.
        /// </summary>
        /// <param name="al">Instância de Alojamento a ser removida da lista.</param>
        /// <returns>Verdadeiro se a remoção for bem-sucedida.</returns>
        public bool RemoverAlojamento(Alojamento al)
        {
            alojamentos.Remove(al); // Remove o alojamento da lista de alojamentos.
            return true; // Retorna verdadeiro indicando que a remoção foi bem-sucedida.
        }

        /// <summary>
        /// Lista os detalhes do(s) alojamento(s) na consola.
        /// </summary>
        /// <returns>Verdadeiro se a listagem for bem-sucedida.</returns>
        public bool ListarAlojamentos()
        {
            foreach (Alojamento alojamento in ALOJAMENTO)
            {
                Console.WriteLine("ID: {0}\nNome: {1}\nTipo: {2}\nLocalização: {3}\n", alojamento.ID, alojamento.Nome, alojamento.Tipo, alojamento.Localizacao);
            }
            return true; // Retorna verdadeiro indicando que a listagem foi bem-sucedida.
        }

        /// <summary>
        /// Verifica se existe, na lista de alojamentos, um alojamento com o ID fornecido.
        /// </summary>
        /// <param name="ID">ID do alojamento a ser verificado.</param>
        /// <returns>Verdadeiro se um alojamento com o ID fornecido existir, falso caso contrário.</returns>
        public bool ExisteAlojamento(int ID)
        {
            // Percorre todos os alojamentos na lista.
            foreach (Alojamento alojamento in alojamentos)
            {
                // Verifica se o ID do alojamento atual corresponde ao ID fornecido.
                if (alojamento.ID == ID)
                {
                    return true; // Retorna verdadeiro se encontrar um alojamento com o ID fornecido.
                }
            }
            return false; // Retorna falso se nenhum alojamento com o ID fornecido for encontrado.
        }

        #endregion
    }
}