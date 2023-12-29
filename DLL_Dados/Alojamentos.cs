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
        /// <returns> Verdadeiro se a gravação for bem-sucedida, falso caso contrário. </returns>

        public bool GravarAlojamento(string al)
        {
            try
            {
                using (StreamWriter writer = File.CreateText(al))
                {
                    foreach (var alojamento in alojamentos)
                    {
                        writer.WriteLine($"{alojamento.ID}#{alojamento.Nome}#{alojamento.Tipo}#{alojamento.Localizacao}");
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao gravar alojamentos: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Lê os detalhes dos alojamentos a partir de um ficheiro e preenche a lista de alojamentos com esses detalhes.
        /// </summary>
        /// <returns> Verdadeiro se a leitura for bem-sucedida, falso caso contrário. </returns>

        public bool LerAlojamento(string al)
        {
            if (!File.Exists(al))
            {
                // Se o ficheiro não existir, cria um novo ficheiro vazio
                using (File.Create(al)) { }
                return false; // Retorna falso porque não há dados para ler
            }
            using (StreamReader sr = File.OpenText(al))
            {
                string linha = sr.ReadLine();
                while (linha != null)
                {
                    string[] sdados = linha.Split('#');
                    int id = int.Parse(sdados[0]);
                    string nome = (sdados[1]);
                    string tipo = (sdados[2]);
                    string localizacao = (sdados[3]);

                    Alojamento alojamento = new Alojamento(id, nome, tipo, localizacao);

                    alojamentos.Add(alojamento);

                    linha = sr.ReadLine();
                }
            }
            return true;
        }

        /// <summary>
        /// Insere um alojamento na lista de alojamentos.
        /// </summary>
        /// <returns> Verdadeiro se a inserção for bem-sucedida. </returns>

        public bool InserirAlojamento(Alojamento al)
        {
            alojamentos.Add(al);
            return true;
        }

        /// <summary>
        /// Remove um alojamento da lista de alojamentos.
        /// </summary>
        /// <returns> Verdadeiro se a remoção for bem-sucedida. </returns>

        public bool RemoverAlojamento(Alojamento al)
        {
            alojamentos.Remove(al);
            return true;
        }

        /// <summary>
        /// Lista os detalhes de do(s) alojamento(s) na consola.
        /// </summary>
        /// <returns> Verdadeiro se a listagem for bem-sucedida. </returns>

        public bool ListarAlojamentos()
        {
            foreach (Alojamento alojamento in ALOJAMENTO)
            {
                Console.WriteLine("ID: {0}\nNome: {1}\nTipo: {2}\nLocalização: {3}\n", alojamento.ID, alojamento.Nome, alojamento.Tipo, alojamento.Localizacao);
            }
            return true;
        }

        /// <summary>
        /// Verifica se existe, na lista de alojamentos, um alojamento com o ID fornecido.
        /// </summary>
        /// <param name="ID"> ID do alojamento a ser verificado. </param>
        /// <returns> Verdadeiro se um alojamento com o ID fornecido existir, falso caso contrário. </returns>

        public bool ExisteAlojamento(int ID)
        {
            foreach (Alojamento alojamento in alojamentos)
            {
                if (alojamento.ID == ID)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion
    }
}