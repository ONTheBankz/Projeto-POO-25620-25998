/// <summary>
/// Interface para listagem de métodos Check-Out
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
    /// Interface que define operações para os check-outs.
    /// </summary>
    internal interface ICheck_Out
    {
        /// <summary>
        /// Grava os detalhes dos check-outs num ficheiro.
        /// </summary>
        /// <param name="co">Caminho do arquivo para gravar os detalhes dos check-outs.</param>
        /// <returns>Verdadeiro se a gravação for bem-sucedida, falso caso contrário.</returns>
        bool GravarCheck_O(string co);

        /// <summary>
        /// Lê os detalhes dos check-outs a partir de um ficheiro e preenche a lista de check-outs com esses detalhes.
        /// </summary>
        /// <param name="co">Caminho do arquivo contendo os detalhes dos check-outs.</param>
        /// <returns>Verdadeiro se a leitura for bem-sucedida, falso caso contrário.</returns>
        bool LerCheck_O(string co);

        /// <summary>
        /// Insere um novo check-out na lista de check-outs.
        /// </summary>
        /// <param name="co">Objeto CheckOut a ser inserido.</param>
        /// <returns>Verdadeiro se a inserção for bem-sucedida.</returns>
        bool InserirCheck_O(CheckOut co);

        /// <summary>
        /// Remove um check-out da lista de check-outs.
        /// </summary>
        /// <param name="co">Objeto CheckOut a ser removido.</param>
        /// <returns>Verdadeiro se a remoção for bem-sucedida.</returns>
        bool RemoverCheck_O(CheckOut co);

        /// <summary>
        /// Lista os detalhes do(s) check-out(s) na consola.
        /// </summary>
        /// <returns>Verdadeiro se a listagem for bem-sucedida.</returns>
        bool ListarCheck_O();

        /// <summary>
        /// Verifica se existe um check-out com o ID fornecido na lista de check-outs.
        /// </summary>
        /// <param name="ID">ID do check-out a ser verificado.</param>
        /// <returns>Verdadeiro se um check-out com o ID fornecido existir, falso caso contrário.</returns>
        bool ExisteCheck_O(int ID);

        /// <summary>
        /// Gera um novo ID para um check-out adicionando mais um ao ID mais alto existente na lista de check-outs.
        /// </summary>
        /// <param name="id">ID a ser gerado para o novo check-out.</param>
        /// <returns>O próximo ID disponível para um novo check-out.</returns>
        int ID(int id);

        /// <summary>
        /// Ordena a lista de check-outs.
        /// </summary>
        void OrdenarCheck_O();
    }
}
