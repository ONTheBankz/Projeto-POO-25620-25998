/// <summary>
/// Classe para descrever um Check-Out
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
    public class CheckOut : CheckIO
    {
        #region ESTADO
        // Define campos privados para armazenar o estado do objeto Check-Out.

        // Referência à instância de Check_In associada ao Check-Out.
        private CheckIn checkin;

        #endregion

        #region COMPORTAMENTO

        #region CONSTRUTORES
        // Construtor padrão inicializa os campos com valores padrão.
        public CheckOut() : base() 
        {
            checkin = null;
        }
        // Construtor parametrizado inicializa o CheckOut com valores específicos.
        public CheckOut(int idCheckOut, CheckIn checkin, DateTime dataCheckOut)
        {
            ID = idCheckOut;
            DataCheckIO = dataCheckOut;
            this.checkin = checkin;
        }
        #endregion

        #region PROPRIEDADES
        // Propriedades para acessar os campos privados.
        public CheckIn Check_In
        {
            get { return checkin; }
            set { checkin = value; }
        }

        #endregion

        #region OPERADORES

        // Sobrecarga do operador de igualdade para comparar dois check-outs com base no ID do check-out.
        public static bool operator ==(CheckOut co1, CheckOut co2)
        {
            return co1.ID == co2.ID;
        }

        // Sobrecarga do operador de desigualdade para negar a igualdade entre dois check-outs.
        public static bool operator !=(CheckOut co1, CheckOut co2)
        {
            return !(co1 == co2);
        }

        #endregion

        #region OVERRIDES

        // Sobrecarga do método ToString para obter uma representação de string do objeto CheckOut.
        public override string ToString()
        {
            return string.Format("ID Check-Out: {0}\nID Check_IN: {1}\nData Check-Out: {2}\n",
                                 ID, checkin.ID, DataCheckIO.ToShortDateString());
        }

        // Sobrecarga do método Equals para comparar objetos CheckOut.
        public override bool Equals(object obj)
        {
            if (obj is CheckOut)
            {
                CheckOut co = (CheckOut)obj;
                return this == co;
            }
            return false;
        }

        #endregion

        #endregion
    }
}