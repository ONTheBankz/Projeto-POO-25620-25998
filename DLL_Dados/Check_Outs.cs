/// <summary>
/// Classe para criação de funções Check-Out
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
    public class Check_Outs : ICheck_Out
    {
        #region ESTADO
        static List<CheckOut> checkOuts;
        #endregion

        #region CONSTRUTORES
        static Check_Outs()
        {
            checkOuts = new List<CheckOut>();
        }
        #endregion

        #region PROPRIEDADES
        public static List<CheckOut> CHECKOUT
        {
            get { return checkOuts; }
            set { checkOuts = value; }
        }

        #endregion

        #region OUTROS MÉTODOS

        #endregion

    }
}