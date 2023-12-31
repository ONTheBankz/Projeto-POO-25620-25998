/// <summary>
/// Interface para listagem de métodos Check-In
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
    /// Interface que define operações para os check-ins.
    /// </summary>
    internal interface ICheck_In
    {
        /// <summary>
        /// Grava os detalhes dos check-ins num ficheiro.
        /// </summary>
        /// <param name="ci">Caminho do arquivo para gravar os detalhes dos check-ins.</param>
        /// <returns>Verdadeiro se a gravação for bem-sucedida, falso caso contrário.</returns>
        bool GravarCheck_I(string ci);

        /// <summary>
        /// Lê os detalhes dos check-ins a partir de um ficheiro e preenche a lista de check-ins com esses detalhes.
        /// </summary>
        /// <param name="ci">Caminho do arquivo contendo os detalhes dos check-ins.</param>
        /// <returns>Verdadeiro se a leitura for bem-sucedida, falso caso contrário.</returns>
        bool LerCheck_I(string ci);

        /// <summary>
        /// Insere um novo check-in na lista de check-ins.
        /// </summary>
        /// <param name="ci">Objeto CheckIn a ser inserido.</param>
        /// <returns>Verdadeiro se a inserção for bem-sucedida.</returns>
        bool InserirCheck_I(CheckIn ci);

        /// <summary>
        /// Remove um check-in da lista de check-ins.
        /// </summary>
        /// <param name="ci">Objeto CheckIn a ser removido.</param>
        /// <returns>Verdadeiro se a remoção for bem-sucedida.</returns>
        bool RemoverCheck_I(CheckIn ci);

        /// <summary>
        /// Lista os detalhes do(s) check-in(s) na consola.
        /// </summary>
        /// <returns>Verdadeiro se a listagem for bem-sucedida.</returns>
        bool ListarCheck_I();

        /// <summary>
        /// Verifica se existe um check-in com o ID fornecido na lista de check-ins.
        /// </summary>
        /// <param name="ID">ID do check-in a ser verificado.</param>
        /// <returns>Verdadeiro se um check-in com o ID fornecido existir, falso caso contrário.</returns>
        bool ExisteCheck_I(int ID);

        /// <summary>
        /// Gera um novo ID para um check-in adicionando mais um ao ID mais alto existente na lista de check-ins.
        /// </summary>
        /// <param name="id">ID a ser gerado para o novo check-in.</param>
        /// <returns>O próximo ID disponível para um novo check-in.</returns>
        int ID(int id);

        /// <summary>
        /// Ordena a lista de check-ins.
        /// </summary>
        void OrdenarCheck_I();
    }
}
