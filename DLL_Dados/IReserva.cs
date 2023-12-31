/// <summary>
/// Interface para listagem de métodos Reserva
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
    /// Interface que define operações para as reservas.
    /// </summary>
    internal interface IReserva
    {
        /// <summary>
        /// Grava os detalhes das reservas num ficheiro.
        /// </summary>
        /// <param name="r">Caminho do arquivo para gravar os detalhes das reservas.</param>
        /// <returns>Verdadeiro se a gravação for bem-sucedida, falso caso contrário.</returns>
        bool GravarReserva(string r);

        /// <summary>
        /// Lê os detalhes das reservas a partir de um ficheiro e preenche a lista de reservas com esses detalhes.
        /// </summary>
        /// <param name="r">Caminho do arquivo contendo os detalhes das reservas.</param>
        /// <returns>Verdadeiro se a leitura for bem-sucedida, falso caso contrário.</returns>
        bool LerReserva(string r);

        /// <summary>
        /// Insere uma nova reserva na lista de reservas.
        /// </summary>
        /// <param name="r">Objeto Reserva a ser inserido.</param>
        /// <returns>Verdadeiro se a inserção for bem-sucedida.</returns>
        bool InserirReserva(Reserva r);

        /// <summary>
        /// Remove uma reserva da lista de reservas.
        /// </summary>
        /// <param name="r">Objeto Reserva a ser removido.</param>
        /// <returns>Verdadeiro se a remoção for bem-sucedida.</returns>
        bool RemoverReserva(Reserva r);

        /// <summary>
        /// Verifica se existe uma reserva com o ID fornecido na lista de reservas.
        /// </summary>
        /// <param name="ID">ID da reserva a ser verificada.</param>
        /// <returns>Verdadeiro se uma reserva com o ID fornecido existir, falso caso contrário.</returns>
        bool ExisteReserva(int ID);

        /// <summary>
        /// Gera um novo ID para uma reserva adicionando mais um ao ID mais alto existente na lista de reservas.
        /// </summary>
        /// <param name="id">ID a ser gerado para a nova reserva.</param>
        /// <returns>O próximo ID disponível para uma nova reserva.</returns>
        int ID(int id);

        /// <summary>
        /// Ordena a lista de reservas.
        /// </summary>
        void OrdenarReserva();
    }
}
