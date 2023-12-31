/// <summary>
/// Interface para listagem de métodos Alojamento
/// David Martinho
/// Rafael Rodrigues
/// a25620@alunos.ipca.pt
/// a25998@alunos.ipca.pt
/// 09-11-2023
/// POO-LESI
/// </summary>

using System;
using DLL_Objetos;

namespace DLL_Dados
{
    /// <summary>
    /// Interface que define operações para os Alojamentos.
    /// </summary>
    internal interface IAlojamento
    {
        /// <summary>
        /// Grava os detalhes dos alojamentos num ficheiro.
        /// </summary>
        /// <param name="al">Caminho do arquivo para gravar os detalhes dos alojamentos.</param>
        /// <returns>Verdadeiro se a gravação for bem-sucedida, falso caso contrário.</returns>
        bool GravarAlojamento(string al);

        /// <summary>
        /// Lê os detalhes dos alojamentos a partir de um ficheiro e preenche a lista de alojamentos com esses detalhes.
        /// </summary>
        /// <param name="al">Caminho do arquivo contendo os detalhes dos alojamentos.</param>
        /// <returns>Verdadeiro se a leitura for bem-sucedida, falso caso contrário.</returns>
        bool LerAlojamento(string al);

        /// <summary>
        /// Insere um alojamento na lista de alojamentos.
        /// </summary>
        /// <param name="al">Objeto Alojamento a ser inserido.</param>
        /// <returns>Verdadeiro se a inserção for bem-sucedida.</returns>
        bool InserirAlojamento(Alojamento al);

        /// <summary>
        /// Remove um alojamento da lista de alojamentos.
        /// </summary>
        /// <param name="al">Objeto Alojamento a ser removido.</param>
        /// <returns>Verdadeiro se a remoção for bem-sucedida.</returns>
        bool RemoverAlojamento(Alojamento al);

        /// <summary>
        /// Lista os detalhes de do(s) alojamento(s) na consola.
        /// </summary>
        /// <returns>Verdadeiro se a listagem for bem-sucedida.</returns>
        bool ListarAlojamentos();

        /// <summary>
        /// Verifica se existe, na lista de alojamentos, um alojamento com o ID fornecido.
        /// </summary>
        /// <param name="ID">ID do alojamento a ser verificado.</param>
        /// <returns>Verdadeiro se um alojamento com o ID fornecido existir, falso caso contrário.</returns>
        bool ExisteAlojamento(int ID);
    }
}
