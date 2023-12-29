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
        bool GravarCheck_O(string co);
        bool LerCheck_O(string co);
        bool InserirCheck_O(CheckOut co);
        bool RemoverCheck_O(CheckOut co);
        bool ListarCheck_O();
        bool ExisteCheck_O(int ID);
        int ID(int id);
    }
}