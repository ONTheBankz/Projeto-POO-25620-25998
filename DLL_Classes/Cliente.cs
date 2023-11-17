/// <summary>
/// Classe para descrever um Cliente
/// David Martinho
/// Rafael Rodrigues
/// a25620@alunos.ipca.pt
/// a25998@alunos.ipca.pt
/// 09-11-2023
/// POO-LESI
/// </summary>

using System;

namespace DLL_Classes
{
    public class Cliente 
    {
        #region ESTADO 
        // Define campos privados para armazenar o estado do objeto Cliente.

        // Nome do cliente.
        private string nomeCliente;

        // Morada do cliente.
        private string morada;

        // Endereço de e-mail do cliente.
        private string email;

        // Data de nascimento do cliente.
        private DateTime dataNascimento;

        // Número de contacto do cliente.
        private int contacto;

        // Número de Identificação Fiscal (NIF) do cliente.
        private int nif;

        #endregion

        #region COMPORTAMENTO 

        #region CONSTRUTORES
        // Construtor padrão inicializa os campos com valores padrão.
        public Cliente()
        {
            nomeCliente = "";
            morada = "";
            email = "";
            dataNascimento = DateTime.MinValue;
            contacto = 0;
            nif = 0;
        }
        // Construtor parametrizado inicializa o Cliente com valores específicos.
        public Cliente(string nomeCliente, string morada, string email, DateTime dataNascimento, int contacto, int nif)
        {
            this.nomeCliente = nomeCliente;
            this.morada = morada;
            this.email = email;
            this.dataNascimento = dataNascimento;
            this.contacto = contacto;
            this.nif = nif;
        }

        #endregion

        #region PROPRIEDADES 
        // Propriedades para acessar os campos privados.

        public string Nome
        {
            get { return nomeCliente; }
            set { nomeCliente = value; }
        }

        public string Morada
        {
            get { return morada; }
            set { morada = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public DateTime DataNascimento
        {
            get { return dataNascimento; }
            set { dataNascimento = value; }
        }

        public int Contacto
        {
            get { return contacto; }
            set { contacto = value; }
        }

        public int NIF
        {
            get { return nif; }
            set { nif = value; }
        }

        #endregion

        #region OPERADORES 
        // Operador de igualdade para comparar dois objetos Cliente.
        public static bool operator ==(Cliente c1, Cliente c2)
        {
            return c1.NIF == c2.NIF;
        }
        // Operador de desigualdade para negar a igualdade entre dois clientes.
        public static bool operator !=(Cliente c1, Cliente c2)
        {
            return !(c1 == c2);
        }

        #endregion

        #region OVERRIDES 
        // Método ToString para obter uma representação de string do objeto Cliente.
        public override string ToString()
        {
            return string.Format("Nome: {0}\nMorada: {1}\nEmail: {2}\nData Nascimento: {3}\nContacto: {4}\nNIF: {5}",
                                 nomeCliente, morada, email, dataNascimento.ToShortDateString(), contacto, nif);
        }

        // Método Equals para comparar objetos Cliente.
        public override bool Equals(object obj)
        {
            if (obj is Cliente)
            {
                Cliente c = (Cliente)obj;
                return this == c;
            }
            return false;
        }

        #endregion

        #endregion
    }
}