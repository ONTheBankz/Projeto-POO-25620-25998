/// <summary>
/// Classe para criação de funções Alojamento
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
    public class Alojamentos : IAlojamento
    {
        #region ESTADO
        static List<Alojamento> alojamentos;
        #endregion

        #region CONSTRUTORES
        static Alojamentos()
        {
            alojamentos = new List<Alojamento>();
        }
        #endregion

        #region PROPRIEDADES
        public static List<Alojamento> ALOJAMENTO
        {
            get { return alojamentos; }
            set { alojamentos = value; }
        }

        #endregion

        #region OUTROS MÉTODOS

        #endregion

    }
}