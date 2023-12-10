/// <summary>
/// Classe para descrever um CheckIO
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
    public class CheckIO
    {
        #region ESTADO
        // Define campos privados para armazenar o estado do objeto CheckIO.

        // Identificador único para o check-io.
        private int idCheckIO;

        // Referência à instância de Reserva associada ao check-io.
        private Reserva reserva;

        // Data do check-io.
        private DateTime dataCheckIO;

        #endregion

        #region COMPORTAMENTO

        #region CONSTRUTORES
        // Construtor padrão inicializa os campos com valores padrão.
        public CheckIO()
        {
            idCheckIO = 0;
            reserva = null;
            dataCheckIO = DateTime.MinValue;
        }
        // Construtor parametrizado inicializa o CheckIO com valores específicos.
        public CheckIO(int idCheckIO, Reserva reserva, DateTime dataCheckIO)
        {
            this.idCheckIO = idCheckIO;
            this.reserva = reserva;
            this.dataCheckIO = dataCheckIO;
        }
        #endregion

        #region PROPRIEDADES
        // Propriedades para acessar os campos privados.

        public int ID
        {
            get { return idCheckIO; }
            set { idCheckIO = value; }
        }

        public Reserva Reserva
        {
            get { return reserva; }
            set { reserva = value; }
        }

        public DateTime DataCheckIO
        {
            get { return dataCheckIO; }
            set { dataCheckIO = value; }
        }

        #endregion

        #region OPERADORES

        // Sobrecarga do operador de igualdade para comparar dois check-io com base no ID do check-io.
        public static bool operator ==(CheckIO ck1, CheckIO ck2)
        {
            return ck1.idCheckIO == ck2.idCheckIO;
        }

        // Sobrecarga do operador de desigualdade para negar a igualdade entre dois check-io.
        public static bool operator !=(CheckIO ck1, CheckIO ck2)
        {
            return !(ck1 == ck2);
        }

        #endregion

        #region OVERRIDES

        // Sobrecarga do método ToString para obter uma representação de string do objeto CheckIO.
        public override string ToString()
        {
            return string.Format("ID Check-IO: {0}\nID Reserva: {1}\nNome Cliente: {2}\nData Check-IO: {3}\n",
                                 idCheckIO, reserva.ID, reserva.Cliente.Nome, dataCheckIO.ToShortDateString());
        }

        // Sobrecarga do método Equals para comparar objetos CheckIO.
        public override bool Equals(object obj)
        {
            if (obj is CheckIO)
            {
                CheckIO ck = (CheckIO)obj;
                return this == ck;
            }
            return false;
        }

        #endregion

        #endregion
    }
}