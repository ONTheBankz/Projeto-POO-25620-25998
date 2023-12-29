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
        bool GravarCheck_I(string ci);
        bool LerCheck_I(string ci);
        bool InserirCheck_I(CheckIn ci);
        bool RemoverCheck_I(CheckIn ci);
        bool ExisteCheck_I(int ID);
        int ID(int id);

    }
}