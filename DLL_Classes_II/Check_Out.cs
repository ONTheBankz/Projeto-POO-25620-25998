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
using DLL_Classes;

namespace DLL_Classes_II
{
    public class CheckOut   
    {
        #region ESTADO
        // Define campos privados para armazenar o estado do objeto Check-Out.

        // Identificador único para o check-out.
        private int idCheckOut;

        // Referência à instância de Reserva associada ao check-out.
        private Reserva reserva;

        // Referência à instância de Cliente associada ao check-out.
        private Cliente cliente;

        // Data do check-out.
        private DateTime dataCheckOut;

        #endregion

        #region COMPORTAMENTO

        #region CONSTRUTORES
        // Construtor padrão inicializa os campos com valores padrão.
        public CheckOut()
        {
            idCheckOut = 0;
            reserva = null;
            cliente = null;
            dataCheckOut = DateTime.MinValue;
        }
        // Construtor parametrizado inicializa o CheckOut com valores específicos.
        public CheckOut(int idCheckOut, Reserva reserva, Cliente cliente, DateTime dataCheckOut)
        {
            this.idCheckOut = idCheckOut;
            this.reserva = reserva;
            this.cliente = cliente;
            this.dataCheckOut = dataCheckOut;
        }
        #endregion

        #region PROPRIEDADES
        // Propriedades para acessar os campos privados.

        public int ID
        {
            get { return idCheckOut; }
            set { idCheckOut = value; }
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

        public DateTime DataCheckOut
        {
            get { return dataCheckOut; }
            set { dataCheckOut = value; }
        }

        #endregion

        #region OPERADORES

        // Sobrecarga do operador de igualdade para comparar dois check-outs com base no ID do check-out.
        public static bool operator ==(CheckOut co1, CheckOut co2)
        {
            return co1.idCheckOut == co2.idCheckOut;
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
                                 idCheckOut, reserva.ID, reserva.Cliente.Nome, dataCheckOut.ToShortDateString());
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