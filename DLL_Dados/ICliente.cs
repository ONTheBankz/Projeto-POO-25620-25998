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
        /// <summary>
        /// Grava os detalhes dos clientes num ficheiro.
        /// </summary>
        /// <param name="c">Caminho do arquivo para gravar os detalhes dos clientes.</param>
        /// <returns>Verdadeiro se a gravação for bem-sucedida, falso caso contrário.</returns>
        bool GravarCliente(string c);

        /// <summary>
        /// Lê os detalhes dos clientes a partir de um ficheiro e preenche a lista de clientes com esses detalhes.
        /// </summary>
        /// <param name="c">Caminho do arquivo contendo os detalhes dos clientes.</param>
        /// <returns>Verdadeiro se a leitura for bem-sucedida, falso caso contrário.</returns>
        bool LerCliente(string c);

        /// <summary>
        /// Insere um novo cliente na lista de clientes.
        /// </summary>
        /// <param name="c">Objeto Cliente a ser inserido.</param>
        /// <returns>Verdadeiro se a inserção for bem-sucedida.</returns>
        bool InserirCliente(Cliente c);

        /// <summary>
        /// Remove um cliente da lista de clientes.
        /// </summary>
        /// <param name="c">Objeto Cliente a ser removido.</param>
        /// <returns>Verdadeiro se a remoção for bem-sucedida.</returns>
        bool RemoverCliente(Cliente c);

        /// <summary>
        /// Lista os detalhes do(s) cliente(s) na consola.
        /// </summary>
        /// <returns>Verdadeiro se a listagem for bem-sucedida.</returns>
        bool ListarClientes();

        /// <summary>
        /// Edita as propriedades de um cliente com base nas opções fornecidas.
        /// </summary>
        /// <param name="op">Opção de edição.</param>
        /// <param name="nome">Novo nome do cliente.</param>
        /// <param name="morada">Nova morada do cliente.</param>
        /// <param name="email">Novo email do cliente.</param>
        /// <param name="password">Nova password do cliente.</param>
        /// <param name="contacto">Novo contacto do cliente.</param>
        /// <param name="datanasc">Nova data de nascimento do cliente.</param>
        /// <param name="nif">Novo NIF do cliente.</param>
        /// <param name="NIFC">NIF do cliente a ser editado.</param>
        /// <returns>Retorna true se a edição for bem-sucedida; caso contrário, retorna false.</returns>
        bool EditarCliente(int op, string nome, string morada, string email, string password, int contacto, DateTime datanasc, int nif, int NIFC);

        /// <summary>
        /// Verifica se existe um cliente com o NIF fornecido na lista de clientes.
        /// </summary>
        /// <param name="NIF">NIF do cliente a ser verificado.</param>
        /// <returns>Verdadeiro se um cliente com o NIF fornecido existir, falso caso contrário.</returns>
        bool ExisteCliente(int NIF);

        /// <summary>
        /// Autentica um cliente comparando o NIF e a Password fornecidos.
        /// </summary>
        /// <param name="NIF">NIF do cliente.</param>
        /// <param name="Password">Password do cliente.</param>
        /// <returns>Verdadeiro se a autenticação for bem-sucedida, falso caso contrário.</returns>
        bool AuthCliente(int NIF, string Password);
    }
}
