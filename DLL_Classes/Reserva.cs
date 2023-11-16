/// <summary>
/// Classe para descrever uma Reserva
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
    public class Reserva
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

        // Referência à instância de Alojamento associada à reserva.
        private Alojamento alojamento;

        // Referência à instância de Quarto associada à reserva.
        private Quarto quarto;

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
            alojamento = null;
            quarto = null;
        }
        // Construtor parametrizado inicializa a Reserva com valores específicos.
        public Reserva(int idReserva, DateTime dataInicio, DateTime dataFim, int numPessoas, Cliente cliente, Alojamento alojamento, Quarto quarto)
        {
            this.idReserva = idReserva;
            this.dataInicio = dataInicio;
            this.dataFim = dataFim;
            this.numPessoas = numPessoas;
            this.cliente = cliente;
            this.alojamento = alojamento;
            this.quarto = quarto;
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

        public Alojamento Alojamento
        {
            get { return alojamento; }
            set { alojamento = value; }
        }

        public Quarto Quarto
        {
            get { return quarto; }
            set { quarto = value; }
        }

        #endregion

        #region MÉTODOS

        // Outros métodos relacionados à reserva.

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

        #region OVERRIDES
        // Sobrecarga do método ToString para obter uma representação de string do objeto Reserva.
        public override string ToString()
        {
            return string.Format("ID Reserva: {0}\nNome Alojamento: {2}\nNome Cliente: {4}\nNº Pessoas: {5}\nData Início: {6}\nData Fim: {7}\n",
                                 idReserva, alojamento.Nome, cliente.Nome, numPessoas, dataInicio.ToShortDateString(), dataFim.ToShortDateString());
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