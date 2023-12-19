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

namespace DLL_Objetos
{
    public class Cliente : Pessoa
    {
        #region ESTADO 
        // Define campos privados para armazenar o estado do objeto Cliente.
       
        // Morada do cliente.
        private string morada;

        // Número de Identificação Fiscal (NIF) do cliente.
        private int nif;

        #endregion

        #region COMPORTAMENTO 

        #region CONSTRUTORES
        // Construtor padrão inicializa os campos com valores padrão.
        public Cliente()
        {  
            morada = "";        
            nif = 0;
        }
        // Construtor parametrizado inicializa o Cliente com valores específicos.
        public Cliente(string nomeCliente, string morada, string emailCliente, string passCliente, int contactoCliente, DateTime dataNascCliente, int nif)
        {
            Nome = nomeCliente;        
            Email = emailCliente;
            Password = passCliente;
            Contacto = contactoCliente;
            DataNascimento = dataNascCliente;
            this.morada = morada;
            this.nif = nif;
        }

        #endregion

        #region PROPRIEDADES 
        // Propriedades para acessar os campos privados.

        public string Morada
        {
            get { return morada; }
            set { morada = value; }
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
            return string.Format("Nome: {0}\nMorada: {1}\nEmail: {2}\nPassword: {3}\nContacto: {4}\nData Nascimento: {5}\nNIF: {6}",
                                 Nome, morada, Email, Password, Contacto, DataNascimento.ToShortDateString(), nif);
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