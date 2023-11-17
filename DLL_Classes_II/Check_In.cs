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
using DLL_Classes;

namespace DLL_Classes_II    
{
    public class CheckIn
    {
        #region ESTADO
        // Define campos privados para armazenar o estado do objeto CheckIn.

        // Identificador único para o check-in.
        private int idCheckIn;

        // Referência à instância de Reserva associada ao check-in.
        private Reserva reserva;

        // Referência à instância de Cliente associada ao check-in.
        private Cliente cliente;

        // Data do check-in.
        private DateTime dataCheckIn;

        #endregion

        #region COMPORTAMENTO

        #region CONSTRUTORES
        // Construtor padrão inicializa os campos com valores padrão.
        public CheckIn()
        {
            idCheckIn = 0;
            reserva = null;
            cliente = null;
            dataCheckIn = DateTime.MinValue;
        }
        // Construtor parametrizado inicializa o CheckIn com valores específicos.
        public CheckIn(int idCheckIn, Reserva reserva, Cliente cliente, DateTime dataCheckIn)
        {
            this.idCheckIn = idCheckIn;
            this.reserva = reserva;
            this.cliente = cliente;
            this.dataCheckIn = dataCheckIn;
        }
        #endregion

        #region PROPRIEDADES
        // Propriedades para acessar os campos privados.

        public int ID
        {
            get { return idCheckIn; }
            set { idCheckIn = value; }
        }

        public Reserva Reserva
        {
            get { return reserva; }
            set { reserva = value; }
        }

        public Cliente Cliente
        {
            get { return cliente; }
            set { cliente = value; }
        }

        public DateTime DataCheckIn
        {
            get { return dataCheckIn; }
            set { dataCheckIn = value; }
        }

        #endregion

        #region OPERADORES

        // Sobrecarga do operador de igualdade para comparar dois check-ins com base no ID do check-in.
        public static bool operator ==(CheckIn ci1, CheckIn ci2)
        {
            return ci1.idCheckIn == ci2.idCheckIn;
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
                                 idCheckIn, reserva.ID, reserva.Cliente.Nome, dataCheckIn.ToShortDateString());
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