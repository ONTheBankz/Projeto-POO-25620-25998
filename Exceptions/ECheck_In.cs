/// <summary>
/// Classe para definir exceptions relativas ao(s) check-in(s).
/// Autores: David Martinho, Rafael Rodrigues
/// Emails: a25620@alunos.ipca.pt, a25998@alunos.ipca.pt
/// Data: 09-11-2023
/// Disciplina: POO-LESI
/// </summary>

// Importa as bibliotecas necessárias.
using DLL_Exceptions;
using System;

// Namespace que contém a classe de exceção ECheck_In.
namespace DLL_Exceptions
{
    // Definição da classe ECheck_In que herda da classe base Exception.
    public class ECheck_In : Exception
    {
        // Construtor padrão que chama o construtor da classe base com uma mensagem padrão.
        public ECheck_In() : base("Erro no check IN")
        {

        }

        // Construtor parametrizado que permite passar uma mensagem personalizada.
        public ECheck_In(string s) : base(s) { }

        // Construtor parametrizado que permite encapsular uma exceção interna e adicionar informações adicionais.
        public ECheck_In(string s, Exception e)
        {
            // Lança uma nova exceção ECheck_In com a mensagem personalizada e a mensagem da exceção interna.
            throw new ECheck_In(s + "-" + e.Message);
        }
    }
}
