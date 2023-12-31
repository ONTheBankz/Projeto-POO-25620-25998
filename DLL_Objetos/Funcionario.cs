/// <summary>
/// Classe para descrever um Funcionario
/// Autores: David Martinho, Rafael Rodrigues
/// Emails: a25620@alunos.ipca.pt, a25998@alunos.ipca.pt
/// Data: 09-11-2023
/// Disciplina: POO-LESI
/// </summary>

// Importa a biblioteca System para utilizar funcionalidades básicas do sistema.
using System;

// Namespace que contém a classe Funcionario.
namespace DLL_Objetos
{
    // Definição da classe Funcionario que herda de Pessoa.
    public class Funcionario : Pessoa
    {
        #region ESTADO 
        // Define campos privados para armazenar o estado do objeto Funcionario.

        // Identificador único para o funcionario.
        private int idFunc;

        // Referência à instância de Alojamento associada ao funcionario.
        private Alojamento alojamento;

        #endregion

        #region COMPORTAMENTO 

        #region CONSTRUTORES
        // Construtor padrão inicializa os campos com valores padrão.
        public Funcionario() : base()
        {
            idFunc = 0;
            alojamento = null;
        }

        // Construtor parametrizado inicializa o Funcionario com valores específicos.
        public Funcionario(int idFunc, string nomeFunc, string emailFunc, string passFunc, int contactoFunc, DateTime dataNascFunc, Alojamento alojamento)
        {
            Nome = nomeFunc;
            Email = emailFunc;
            Password = passFunc;
            Contacto = contactoFunc;
            DataNascimento = dataNascFunc;
            this.idFunc = idFunc;
            this.alojamento = alojamento;
        }

        #endregion

        #region PROPRIEDADES 
        // Propriedades para acessar os campos privados.

        public int ID
        {
            get { return idFunc; }
            set { idFunc = value; }
        }

        public Alojamento Alojamento
        {
            get { return alojamento; }
            set { alojamento = value; }
        }

        #endregion

        #region OPERADORES
        // Sobrecarga do operador de igualdade para comparar dois funcionarios com base no ID de funcionario.
        public static bool operator ==(Funcionario f1, Funcionario f2)
        {
            return f1.idFunc == f2.idFunc;
        }

        // Sobrecarga do operador de desigualdade para negar a igualdade entre dois funcionarios.
        public static bool operator !=(Funcionario f1, Funcionario f2)
        {
            return !(f1 == f2);
        }

        #endregion

        #region OVERRIDES 
        // Método ToString para obter uma representação de string do objeto Funcionario.
        public override string ToString()
        {
            return string.Format("ID: {0}\nNome: {1}\nEmail: {2}\nPassword: {3}\nContacto: {4}\nData Nascimento: {5}\nID Alojamento: {6}\n",
                                 idFunc, Nome, Email, Password, Contacto, DataNascimento.ToShortDateString(), alojamento.ID);
        }

        // Método Equals para comparar objetos Funcionario.
        public override bool Equals(object obj)
        {
            if (obj is Funcionario)
            {
                Funcionario f = (Funcionario)obj;
                return this == f;
            }
            return false;
        }

        #endregion

        #endregion
    }
}
