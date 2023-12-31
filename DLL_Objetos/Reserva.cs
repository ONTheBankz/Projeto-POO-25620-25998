/// <summary>
/// Classe para descrever uma Reserva
/// Autores: David Martinho, Rafael Rodrigues
/// Emails: a25620@alunos.ipca.pt, a25998@alunos.ipca.pt
/// Data: 09-11-2023
/// Disciplina: POO-LESI
/// </summary>

// Importa a biblioteca System para utilizar funcionalidades básicas do sistema.
using System;

// Namespace que contém a classe Reserva.
namespace DLL_Objetos
{
    // Definição da classe Reserva, que implementa a interface IComparable.
    public class Reserva : IComparable<Reserva>
    {
        #region ESTADO
        // Define campos privados para armazenar o estado do objeto Reserva.

        // Identificador único para a reserva.
        private int idReserva;

        // Data de início da reserva.
        private DateTime dataInicio;

        // Data de fim da reserva.
        private DateTime dataFim;

        // Número de pessoas na reserva.
        private int numPessoas;

        // Referência à instância de Cliente associada à reserva.
        private Cliente cliente;

        // Referência à instância de Quarto associada à reserva.
        private Quarto quarto;

        // Preço total da reserva.
        private decimal precoTotal;

        #endregion

        #region COMPORTAMENTO

        #region CONSTRUTORES
        // Construtor padrão inicializa os campos com valores padrão.
        public Reserva()
        {
            idReserva = 0;
            dataInicio = DateTime.MinValue;
            dataFim = DateTime.MinValue;
            numPessoas = 0;
            cliente = null;
            quarto = null;
            precoTotal = 0;
        }
        // Construtor parametrizado inicializa a Reserva com valores específicos.
        public Reserva(int idReserva, DateTime dataInicio, DateTime dataFim, int numPessoas, Cliente cliente, Quarto quarto, decimal precoTotal)
        {
            this.idReserva = idReserva;
            this.dataInicio = dataInicio;
            this.dataFim = dataFim;
            this.numPessoas = numPessoas;
            this.cliente = cliente;
            this.quarto = quarto;
            this.precoTotal = precoTotal;
        }
        #endregion

        #region PROPRIEDADES
        // Propriedades para acessar os campos privados.

        public int ID
        {
            get { return idReserva; }
            set { idReserva = value; }
        }

        public DateTime DataInicio
        {
            get { return dataInicio; }
            set { dataInicio = value; }
        }

        public DateTime DataFim
        {
            get { return dataFim; }
            set { dataFim = value; }
        }

        public int NumPessoas
        {
            get { return numPessoas; }
            set { numPessoas = value; }
        }

        public Cliente Cliente
        {
            get { return cliente; }
            set { cliente = value; }
        }

        public Quarto Quarto
        {
            get { return quarto; }
            set { quarto = value; }
        }

        public decimal PrecoTotal
        {
            get { return precoTotal; }
            set { precoTotal = value; }
        }

        #endregion

        #region OPERADORES
        // Sobrecarga do operador de igualdade para comparar duas reservas com base no ID da reserva.
        public static bool operator ==(Reserva r1, Reserva r2)
        {
            return r1.idReserva == r2.idReserva;
        }
        // Sobrecarga do operador de desigualdade para negar a igualdade entre duas reservas.
        public static bool operator !=(Reserva r1, Reserva r2)
        {
            return !(r1 == r2);
        }

        #endregion

        #region MÉTODOS

        // Método CompareTo para comparar as datas de início da Reserva
        public int CompareTo(Reserva r)
        {
            return dataInicio.CompareTo(r.DataInicio);
        }

        #endregion

        #region OVERRIDES
        // Sobrecarga do método ToString para obter uma representação de string do objeto Reserva.
        public override string ToString()
        {
            return string.Format("ID Reserva: {0}\nData Início: {1}\nData Fim: {2}\nNº Pessoas: {3}\nNIF Cliente: {4}\nID Quarto: {5}\nPreço Total: {6}\n",
                                 idReserva, dataInicio.ToShortDateString(), dataFim.ToShortDateString(), numPessoas, cliente.NIF, quarto.ID, precoTotal);
        }

        // Sobrecarga do método Equals para comparar objetos Reserva.
        public override bool Equals(object obj)
        {
            if (obj is Reserva)
            {
                Reserva r = (Reserva)obj;
                return this == r;
            }
            return false;
        }

        #endregion

        #endregion
    }
}
