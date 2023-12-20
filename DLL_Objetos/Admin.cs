/// <summary>
/// Classe para descrever um Admin
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
    public class Admin : Pessoa
    {
        #region ESTADO 
        // Define campos privados para armazenar o estado do objeto Admin.

        // Identificador único para o admin.
        private int idAdmin;

        #endregion

        #region COMPORTAMENTO 

        #region CONSTRUTORES
        // Construtor padrão inicializa os campos com valores padrão.
        public Admin() : base()
        {
            idAdmin = 0;
        }
        // Construtor parametrizado inicializa o Admin com valores específicos.
        public Admin(int idAdmin, string nomeAdmin, string emailAdmin, string passAdmin, int contactoAdmin, DateTime dataNascAdmin)
        
        {
            Nome = nomeAdmin;
            Email = emailAdmin;
            Password = passAdmin;
            Contacto = contactoAdmin;
            DataNascimento = dataNascAdmin;
            this.idAdmin = idAdmin;
        }

        #endregion

        #region PROPRIEDADES 
        // Propriedades para acessar os campos privados.

        public int ID
        {
            get { return idAdmin; }
            set { idAdmin = value; }
        }

        #endregion

        #region OPERADORES
        // Operador de igualdade para comparar dois objetos Admin.
        public static bool operator ==(Admin a1, Admin a2)
        {
            return a1.ID == a2.ID;
        }
        // Operador de desigualdade para negar a igualdade entre dois admins.
        public static bool operator !=(Admin a1, Admin a2)
        {
            return !(a1 == a2);
        }

        #endregion

        #region OVERRIDES 
        // Método ToString para obter uma representação de string do objeto Admin.
        public override string ToString()
        {
            return string.Format("ID: {0}\nNome: {1}\nEmail: {2}\nPassword: {3}\nContacto: {4}\nData Nascimento: {5}",
                                 idAdmin, Nome, Email, Password, Contacto, DataNascimento.ToShortDateString());
        }

        // Método Equals para comparar objetos Admin.
        public override bool Equals(object obj)
        {
            if (obj is Admin)
            {
                Admin a = (Admin)obj;
                return this == a;
            }
            return false;
        }

        #endregion

        #endregion
    }
}
