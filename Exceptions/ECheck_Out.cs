/// <summary>
/// Classe para definir exceptions relativas ao(s) check-out(s).
/// Autores: David Martinho, Rafael Rodrigues
/// Emails: a25620@alunos.ipca.pt, a25998@alunos.ipca.pt
/// Data: 09-11-2023
/// Disciplina: POO-LESI
/// </summary>

using System;

// Namespace que contém a classe de exceção ECheck_Out.
namespace DLL_Exceptions
{
    // Definição da classe ECheck_Out que herda da classe base Exception.
    public class ECheck_Out : Exception
    {
        // Construtor padrão que chama o construtor da classe base com uma mensagem padrão.
        public ECheck_Out() : base("Erro no check OUT")
        {

        }

        // Construtor parametrizado que permite passar uma mensagem personalizada.
        public ECheck_Out(string s) : base(s) { }

        // Construtor parametrizado que permite encapsular uma exceção interna e adicionar informações adicionais.
        public ECheck_Out(string s, Exception e)
        {
            // Lança uma nova exceção ECheck_Out com a mensagem personalizada e a mensagem da exceção interna.
            throw new ECheck_Out(s + "-" + e.Message);
        }
    }
}
