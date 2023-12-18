/// <summary>
/// Classe para criação de funções Reserva
/// David Martinho
/// Rafael Rodrigues
/// a25620@alunos.ipca.pt
/// a25998@alunos.ipca.pt
/// 09-11-2023
/// POO-LESI
/// </summary>

using System;
using System.Collections.Generic;
using DLL_Objetos;

namespace DLL_Dados
{
    public class Reservas : IReserva
    {
        #region ESTADO
        static List<Reserva> reservas;
        #endregion

        #region CONSTRUTORES
        static Reservas()
        {
            reservas = new List<Reserva>();
        }
        #endregion

        #region PROPRIEDADES
        public static List<Reserva> RESERVA
        {
            get { return reservas; }
            set { reservas = value; }
        }

        #endregion

        #region OUTROS MÉTODOS
 
        #endregion

    }
}