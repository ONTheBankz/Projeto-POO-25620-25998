/// <summary>
/// Classe para criação de funções Check_IO
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
    public class Check_IOs : ICheck_IO
    {
        #region ESTADO
        static List<CheckIO> checkIOs;
        #endregion

        #region CONSTRUTORES
        static Check_IOs()
        {
            checkIOs = new List<CheckIO>();
        }
        #endregion

        #region PROPRIEDADES
        public static List<CheckIO> CHECKIO
        {
            get { return checkIOs; }
            set { checkIOs = value; }
        }

        #endregion

        #region OUTROS MÉTODOS

        #endregion

    }
}