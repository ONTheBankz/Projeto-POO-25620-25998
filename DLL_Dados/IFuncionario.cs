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
        /// <summary>
        /// Grava os detalhes dos funcionários num ficheiro.
        /// </summary>
        /// <param name="f">Caminho do arquivo para gravar os detalhes dos funcionários.</param>
        /// <returns>Verdadeiro se a gravação for bem-sucedida, falso caso contrário.</returns>
        bool GravarFunc(string f);

        /// <summary>
        /// Lê os detalhes dos funcionários a partir de um ficheiro e preenche a lista de funcionários com esses detalhes.
        /// </summary>
        /// <param name="f">Caminho do arquivo contendo os detalhes dos funcionários.</param>
        /// <returns>Verdadeiro se a leitura for bem-sucedida, falso caso contrário.</returns>
        bool LerFunc(string f);

        /// <summary>
        /// Insere um novo funcionário na lista de funcionários.
        /// </summary>
        /// <param name="f">Objeto Funcionario a ser inserido.</param>
        /// <returns>Verdadeiro se a inserção for bem-sucedida.</returns>
        bool InserirFunc(Funcionario f);

        /// <summary>
        /// Remove um funcionário da lista de funcionários.
        /// </summary>
        /// <param name="f">Objeto Funcionario a ser removido.</param>
        /// <returns>Verdadeiro se a remoção for bem-sucedida.</returns>
        bool RemoverFunc(Funcionario f);

        /// <summary>
        /// Edita as propriedades de um funcionário com base nas opções fornecidas.
        /// </summary>
        /// <param name="op">Opção de edição.</param>
        /// <param name="nome">Novo nome do funcionário.</param>
        /// <param name="email">Novo email do funcionário.</param>
        /// <param name="password">Nova password do funcionário.</param>
        /// <param name="contacto">Novo contacto do funcionário.</param>
        /// <param name="datanasc">Nova data de nascimento do funcionário.</param>
        /// <param name="IDF">ID do funcionário a ser editado.</param>
        /// <param name="alojamentoID">ID do alojamento associado ao funcionário.</param>
        /// <returns>Retorna true se a edição for bem-sucedida; caso contrário, retorna false.</returns>
        bool EditarFunc(int op, string nome, string email, string password, int contacto, DateTime datanasc, int IDF, int alojamentoID);

        /// <summary>
        /// Lista os detalhes do(s) funcionário(s) na consola.
        /// </summary>
        /// <returns>Verdadeiro se a listagem for bem-sucedida.</returns>
        bool ListarFunc();

        /// <summary>
        /// Verifica se existe um funcionário com o ID fornecido na lista de funcionários.
        /// </summary>
        /// <param name="ID">ID do funcionário a ser verificado.</param>
        /// <returns>Verdadeiro se um funcionário com o ID fornecido existir, falso caso contrário.</returns>
        bool ExisteFunc(int ID);

        /// <summary>
        /// Autentica um funcionário comparando o ID e a Password fornecidos.
        /// </summary>
        /// <param name="ID">ID do funcionário.</param>
        /// <param name="Password">Password do funcionário.</param>
        /// <returns>Verdadeiro se a autenticação for bem-sucedida, falso caso contrário.</returns>
        bool AuthFunc(int ID, string Password);
    }
}
