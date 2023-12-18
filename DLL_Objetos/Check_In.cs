/// <summary>
/// Classe para descrever um Check-In
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
    public class CheckIn : CheckIO
    {
        #region ESTADO
        // Define campos privados para armazenar o estado do objeto CheckIn.

        #endregion

        #region COMPORTAMENTO

        #region CONSTRUTORES
        // Construtor padrão inicializa os campos com valores padrão.
        public CheckIn() : base()
        {
            
        }
        // Construtor parametrizado inicializa o CheckIn com valores específicos.
        public CheckIn(int idCheckIn, Reserva reserva, DateTime dataCheckIn)
        {
            ID = idCheckIn;
            Reserva = reserva;
            DataCheckIO = dataCheckIn;
        }
        #endregion

        #region PROPRIEDADES
        // Propriedades para acessar os campos privados.

        #endregion

        #region OPERADORES

        // Sobrecarga do operador de igualdade para comparar dois check-ins com base no ID do check-in.
        public static bool operator ==(CheckIn ci1, CheckIn ci2)
        {
            return ci1.ID == ci2.ID;
        }

        // Sobrecarga do operador de desigualdade para negar a igualdade entre dois check-ins.
        public static bool operator !=(CheckIn ci1, CheckIn ci2)
        {
            return !(ci1 == ci2);
        }

        #endregion

        #region OVERRIDES

        // Sobrecarga do método ToString para obter uma representação de string do objeto CheckIn.
        public override string ToString()
        {
            return string.Format("ID Check-In: {0}\nID Reserva: {1}\nNome Cliente: {2}\nData Check-In: {3}\n",
                                 ID, Reserva.ID, Reserva.Cliente.Nome, DataCheckIO.ToShortDateString());
        }

        // Sobrecarga do método Equals para comparar objetos CheckIn.
        public override bool Equals(object obj)
        {
            if (obj is CheckIn)
            {
                CheckIn ci = (CheckIn)obj;
                return this == ci;
            }
            return false;
        }

        #endregion

        #endregion
    }
}