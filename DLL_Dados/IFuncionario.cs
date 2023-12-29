/// <summary>
/// Interface para listagem de métodos Funcionario
/// David Martinho
/// Rafael Rodrigues
/// a25620@alunos.ipca.pt
/// a25998@alunos.ipca.pt
/// 09-11-2023
/// POO-LESI
/// </summary>

using System;
using System.Collections.Generic;
using DLL_Objetos;

namespace DLL_Dados
{

    /// <summary>
    /// Interface que define operações para os funcionários.
    /// </summary>

    internal interface IFuncionario
    {
        bool GravarFunc(string f);
        bool LerFunc(string f);
        bool InserirFunc(Funcionario f);
        bool RemoverFunc(Funcionario f);
        bool ListarFunc();
        bool ExisteFunc(int ID);
        bool AuthFunc(int ID, string Password);

    }
}