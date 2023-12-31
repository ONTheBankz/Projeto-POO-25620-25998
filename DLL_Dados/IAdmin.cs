/// <summary>
/// Interface para listagem de métodos Admin
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
    /// Interface que define operações para administradores.
    /// </summary>
    internal interface IAdmin
    {
        /// <summary>
        /// Lê os detalhes dos administradores a partir de um ficheiro e preenche a lista de administradores com esses detalhes.
        /// </summary>
        /// <param name="a">Caminho do arquivo contendo os detalhes dos administradores.</param>
        /// <returns>Verdadeiro se a leitura for bem-sucedida, falso caso contrário.</returns>
        bool LerAdmin(string a);

        /// <summary>
        /// Verifica se existe um administrador com o ID fornecido na lista de administradores.
        /// </summary>
        /// <param name="ID">ID do administrador a ser verificado.</param>
        /// <returns>Verdadeiro se um administrador com o ID fornecido existir, falso caso contrário.</returns>
        bool ExisteAdmin(int ID);

        /// <summary>
        /// Autentica um administrador com base no ID e na password fornecidos.
        /// </summary>
        /// <param name="ID">ID do administrador a ser autenticado.</param>
        /// <param name="Password">Password do administrador a ser verificada.</param>
        /// <returns>Verdadeiro se a autenticação for bem-sucedida, falso caso contrário.</returns>
        bool AuthAdmin(int ID, string Password);
    }
}
