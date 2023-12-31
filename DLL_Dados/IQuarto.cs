/// <summary>
/// Interface para listagem de métodos Quarto
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
    /// Interface que define operações para os quartos.
    /// </summary>
    internal interface IQuarto
    {
        /// <summary>
        /// Grava os detalhes dos quartos num ficheiro.
        /// </summary>
        /// <param name="q">Caminho do arquivo para gravar os detalhes dos quartos.</param>
        /// <returns>Verdadeiro se a gravação for bem-sucedida, falso caso contrário.</returns>
        bool GravarQuarto(string q);

        /// <summary>
        /// Lê os detalhes dos quartos a partir de um ficheiro e preenche a lista de quartos com esses detalhes.
        /// </summary>
        /// <param name="q">Caminho do arquivo contendo os detalhes dos quartos.</param>
        /// <returns>Verdadeiro se a leitura for bem-sucedida, falso caso contrário.</returns>
        bool LerQuarto(string q);

        /// <summary>
        /// Insere um novo quarto na lista de quartos.
        /// </summary>
        /// <param name="q">Objeto Quarto a ser inserido.</param>
        /// <returns>Verdadeiro se a inserção for bem-sucedida.</returns>
        bool InserirQuarto(Quarto q);

        /// <summary>
        /// Remove um quarto da lista de quartos.
        /// </summary>
        /// <param name="q">Objeto Quarto a ser removido.</param>
        /// <returns>Verdadeiro se a remoção for bem-sucedida.</returns>
        bool RemoverQuarto(Quarto q);

        /// <summary>
        /// Lista os detalhes do(s) quarto(s) na consola.
        /// </summary>
        /// <returns>Verdadeiro se a listagem for bem-sucedida.</returns>
        bool ListarQuartos();

        /// <summary>
        /// Verifica se existe um quarto com o ID fornecido na lista de quartos.
        /// </summary>
        /// <param name="ID">ID do quarto a ser verificado.</param>
        /// <returns>Verdadeiro se um quarto com o ID fornecido existir, falso caso contrário.</returns>
        bool ExisteQuarto(int ID);

        /// <summary>
        /// Obtém a quantidade de quartos de um determinado tipo.
        /// </summary>
        /// <param name="tipoQuarto">Tipo do quarto para o qual a quantidade será obtida.</param>
        /// <returns>Quantidade de quartos do tipo especificado.</returns>
        int ObterQuant(string tipoQuarto);
    }
}
