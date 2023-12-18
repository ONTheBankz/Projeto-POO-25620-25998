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

        #endregion

        #region COMPORTAMENTO

        #region CONSTRUTORES
        // Construtor padrão inicializa os campos com valores padrão.
        public CheckOut() : base()
        {

        }
        // Construtor parametrizado inicializa o CheckOut com valores específicos.
        public CheckOut(int idCheckOut, Reserva reserva, DateTime dataCheckOut)
        {
            ID = idCheckOut;
            Reserva = reserva;
            DataCheckIO = dataCheckOut;
        }
        #endregion

        #region PROPRIEDADES
        // Propriedades para acessar os campos privados.

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
            return string.Format("ID Check-Out: {0}\nID Reserva: {1}\nNome Cliente: {2}\nData Check-Out: {3}\n",
                                 ID, Reserva.ID, Reserva.Cliente.Nome, DataCheckIO.ToShortDateString());
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