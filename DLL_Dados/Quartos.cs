/// <summary>
/// Classe para criação de funções Quarto
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
    public class Quartos : IQuarto
    {
        #region ESTADO

        /// <summary>
        /// Lista que contém os quartos.
        /// </summary>

        static List<Quarto> quartos;
        #endregion

        #region CONSTRUTORES

        /// <summary>
        /// Construtor que inicializa a lista dos quartos.
        /// </summary>

        static Quartos()
        {
            quartos = new List<Quarto>();
        }
        #endregion

        #region PROPRIEDADES

        /// <summary>
        /// Propriedade que acede à lista das propriedades.
        /// </summary>

        public static List<Quarto> QUARTO
        {
            get { return quartos; }
            set { quartos = value; }
        }

        #endregion

        #region OUTROS MÉTODOS

        /// <summary>
        /// Grava os detalhes dos quartos num ficheiro.
        /// </summary>
        /// <param name="q">Caminho do arquivo para gravar os detalhes dos quartos.</param>
        /// <returns>Verdadeiro se a gravação for bem-sucedida, falso caso contrário.</returns>
        public bool GravarQuarto(string q)
        {
            try
            {
                using (StreamWriter writer = File.CreateText(q))
                {
                    foreach (var quarto in quartos)
                    {
                        // Escreve uma linha no arquivo com os detalhes do quarto, separados por '#'
                        writer.WriteLine($"{quarto.ID}#{quarto.Tipo}#{quarto.Disponibilidade}#{quarto.Valor}#{quarto.Alojamento.ID}");
                    }
                }
                return true; // Retorna verdadeiro se a gravação for bem-sucedida.
            }
            catch (Exception ex)
            {
                // Em caso de exceção, imprime uma mensagem de erro no console.
                Console.WriteLine($"Erro ao gravar quarto: {ex.Message}");
                return false; // Retorna falso indicando que a gravação falhou.
            }
        }

        /// <summary>
        /// Lê os detalhes dos quartos a partir de um ficheiro e preenche a lista de quartos com esses detalhes.
        /// </summary>
        /// <param name="q">Caminho do arquivo para ler os detalhes dos quartos.</param>
        /// <returns>Verdadeiro se a leitura for bem-sucedida, falso caso contrário.</returns>
        public bool LerQuarto(string q)
        {
            if (!File.Exists(q))
            {
                // Se o ficheiro não existir, cria um novo ficheiro vazio
                using (File.Create(q)) { }
                return false; // Retorna falso porque não há dados para ler
            }
            using (StreamReader sr = File.OpenText(q))
            {
                string linha = sr.ReadLine();
                while (linha != null)
                {
                    // Divide a linha em partes usando '#' como delimitador
                    string[] sdados = linha.Split('#');
                    int id = int.Parse(sdados[0]);
                    string tipo = (sdados[1]);
                    bool disponibilidade = bool.Parse(sdados[2]);
                    decimal valor = decimal.Parse(sdados[3]);
                    int alojamentoID = int.Parse(sdados[4]);

                    // Cria uma instância de Alojamento com o ID fornecido
                    Alojamento alojamento = new Alojamento { ID = alojamentoID };

                    // Cria uma instância de Quarto com os detalhes lidos
                    Quarto quarto = new Quarto(id, tipo, disponibilidade, valor, alojamento);

                    // Adiciona o quarto à lista de quartos
                    quartos.Add(quarto);

                    linha = sr.ReadLine(); // Lê a próxima linha do arquivo
                }
            }
            return true; // Retorna verdadeiro se a leitura for bem-sucedida.
        }

        /// <summary>
        /// Insere um novo quarto na lista de quartos.
        /// </summary>
        /// <param name="q">Quarto a ser inserido na lista.</param>
        /// <returns>Verdadeiro se a inserção for bem-sucedida.</returns>
        public bool InserirQuarto(Quarto q)
        {
            quartos.Add(q); // Adiciona o quarto à lista de quartos
            return true;    // Retorna verdadeiro para indicar que a inserção foi bem-sucedida
        }

        /// <summary>
        /// Remove um quarto da lista de quartos.
        /// </summary>
        /// <param name="q">Quarto a ser removido da lista.</param>
        /// <returns>Verdadeiro se a remoção for bem-sucedida.</returns>
        public bool RemoverQuarto(Quarto q)
        {
            quartos.Remove(q); // Remove o quarto da lista de quartos usando o método Remove da classe List<Quarto>
            return true;       // Retorna verdadeiro para indicar que a remoção foi bem-sucedida
        }

        /// <summary>
        /// Lista os detalhes de todos os quartos na consola.
        /// </summary>
        /// <returns>Verdadeiro se a listagem for bem-sucedida.</returns>
        public bool ListarQuartos()
        {
            foreach (Quarto quarto in QUARTO)
            {
                Console.WriteLine("ID Quarto: {0}\nTipo Quarto: {1}\nDisponibilidade: {2}\nValor por Noite: {3}\nID Alojamento: {4}\n",
                                 quarto.ID, quarto.Tipo, quarto.Disponibilidade, quarto.Valor, quarto.Alojamento.ID);
            }
            return true;
        }

        /// <summary>
        /// Verifica se existe um quarto com o ID fornecido na lista de quartos.
        /// </summary>
        /// <param name="ID">ID do quarto a ser verificado.</param>
        /// <returns>Verdadeiro se um quarto com o ID fornecido existir, falso caso contrário.</returns>
        public bool ExisteQuarto(int ID)
        {
            foreach (Quarto quarto in quartos)
            {
                if (quarto.ID == ID)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Obtém a quantidade de pessoas permitidas num tipo de quarto.
        /// </summary>
        /// <param name="tipoQuarto">Tipo de quarto para obter a quantidade de pessoas permitidas.</param>
        /// <returns>Número de pessoas permitidas no quarto, 0 se o tipo não for reconhecido.</returns>
        public int ObterQuant(string tipoQuarto)
        {
            switch (tipoQuarto.ToLower())
            {
                case "duplo":
                    return 2;
                case "triplo":
                    return 3;
                case "familiar":
                    return 4;
                case "suíte":
                    return 5;
                default:
                    return 0;
            }
        }

        #endregion

    }
}