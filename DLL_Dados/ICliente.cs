/// <summary>
/// Interface para listagem de métodos Cliente
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
    /// Interface que define operações para os clientes.
    /// </summary>

    internal interface ICliente
    {
        bool GravarCliente(string c);
        bool LerCliente(string c);
        bool InserirCliente(Cliente c);
        bool RemoverCliente(Cliente c);
        bool ListarClientes();
        bool ExisteCliente(int NIF);
        bool AuthCliente(int NIF, string Password);
    }
}
