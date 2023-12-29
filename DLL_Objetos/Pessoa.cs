/// <summary>
/// Classe para descrever uma Pessoa
/// David Martinho
/// Rafael Rodrigues
/// a25620@alunos.ipca.pt
/// a25998@alunos.ipca.pt
/// 09-11-2023
/// POO-LESI
/// </summary>

using System;

namespace DLL_Objetos
{
    public class Pessoa
    {
        #region ESTADO
        // Campos privados comuns a todas as pessoas.
        private string nome;
        private string email;
        private string password;
        private int contacto;
        private DateTime dataNascimento;
        #endregion

        #region COMPORTAMENTO

        #region CONSTRUTORES
        // Construtor padrão inicializa os campos com valores padrão.
        public Pessoa()
        {
            nome = "";
            email = "";
            password = "";
            contacto = 0;
            dataNascimento = DateTime.MinValue;
        }

        // Construtor parametrizado inicializa a Pessoa com valores específicos.
        public Pessoa(string nome, string email, string password, int contacto, DateTime dataNascimento)
        {
            this.nome = nome;
            this.email = email;
            this.password = password;
            this.contacto = contacto;
            this.dataNascimento = dataNascimento;
        }

        #endregion

        #region PROPRIEDADES
        // Propriedades para acessar os campos privados.

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public int Contacto
        {
            get { return contacto; }
            set { contacto = value; }
        }

        public DateTime DataNascimento
        {
            get { return dataNascimento; }
            set { dataNascimento = value; }
        }

        #endregion

        #region OVERRIDES 
        // Sobrescrever o método ToString para obter uma representação de string comum.
        public override string ToString()
        {
            return string.Format("Nome: {0}\nEmail: {1}\nPassword: {2}\nContacto: {3}\nData Nascimento: {4}\n", nome, email, password,
                                contacto, dataNascimento.ToShortDateString());
        }

        // Método Equals para comparar objetos Pessoa.
        public override bool Equals(object obj)
        {
            if (obj is Pessoa)
            {
                Pessoa p = (Pessoa)obj;
                return this == p;
            }
            return false;
        }

        #endregion

        #endregion
    }
}
