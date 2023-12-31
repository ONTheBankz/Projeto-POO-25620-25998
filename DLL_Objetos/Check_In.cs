/// <summary>
/// Classe para descrever um Check-In
/// Autores: David Martinho, Rafael Rodrigues
/// Emails: a25620@alunos.ipca.pt, a25998@alunos.ipca.pt
/// Data: 09-11-2023
/// Disciplina: POO-LESI
/// </summary>

// Importa a biblioteca System para utilizar funcionalidades básicas do sistema.
using System;

// Namespace que contém a classe CheckIn.
namespace DLL_Objetos
{
    // Definição da classe CheckIn que herda de CheckIO e implementa IComparable<CheckIn>.
    public class CheckIn : CheckIO, IComparable<CheckIn>
    {
        #region ESTADO
        // Define campos privados para armazenar o estado do objeto CheckIn.
        // (Neste caso, os campos são herdados da classe base CheckIO e não há campos adicionais nesta classe.)
        #endregion

        #region COMPORTAMENTO

        #region CONSTRUTORES
        // Construtor padrão inicializa os campos com valores padrão.
        public CheckIn() : base()
        {
            // Nenhuma inicialização adicional necessária.
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
        // (Neste caso, as propriedades são herdadas da classe base CheckIO e não há propriedades adicionais nesta classe.)
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

        #region MÉTODOS

        // Método CompareTo para comparar as datas do Check_In
        public int CompareTo(CheckIn ci)
        {
            return DataCheckIO.CompareTo(ci.DataCheckIO);
        }

        #endregion

        #region OVERRIDES

        // Sobrecarga do método ToString para obter uma representação de string do objeto CheckIn.
        public override string ToString()
        {
            return string.Format("ID Check-In: {0}\nID Reserva: {1}\nData Check-In: {2}\n",
                                 ID, Reserva.ID, DataCheckIO.ToShortDateString());
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
