/// <summary>
/// Classe para criação de funções Check-In
/// David Martinho
/// Rafael Rodrigues
/// a25620@alunos.ipca.pt
/// a25998@alunos.ipca.pt
/// 09-11-2023
/// POO-LESI
/// </summary>

using System;
using System.Collections.Generic;
using DLL_Classes;

namespace DLL_Classes_II
{
    public class Check_Ins : ICheck_In
    {
        #region ESTADO
        static List<CheckIn> checkIns;
        #endregion

        #region CONSTRUTORES
        static Check_Ins()
        {
            checkIns = new List<CheckIn>();
        }
        #endregion

        #region PROPRIEDADES
        public static List<CheckIn> CHECKIN
        {
            get { return checkIns; }
            set { checkIns = value; }
        }

        #endregion

        #region OUTROS MÉTODOS

        #endregion

    }
}