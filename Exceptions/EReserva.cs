/// <summary>
/// Classe para definir exceptions relativas à(s) reserva(s).
/// Autores: David Martinho, Rafael Rodrigues
/// Emails: a25620@alunos.ipca.pt, a25998@alunos.ipca.pt
/// Data: 09-11-2023
/// Disciplina: POO-LESI
/// </summary>

using System;

// Namespace que contém a classe de exceção EReserva.
namespace DLL_Exceptions
{
    // Definição da classe EReserva que herda da classe base Exception.
    public class EReserva : Exception
    {
        // Construtor padrão que chama o construtor da classe base com uma mensagem padrão.
        public EReserva() : base("Erro nas reservas")
        {

        }

        // Construtor parametrizado que permite passar uma mensagem personalizada.
        public EReserva(string s) : base(s) { }

        // Construtor parametrizado que permite encapsular uma exceção interna e adicionar informações adicionais.
        public EReserva(string s, Exception e)
        {
            // Lança uma nova exceção EReserva com a mensagem personalizada e a mensagem da exceção interna.
            throw new EReserva(s + "-" + e.Message);
        }
    }
}
