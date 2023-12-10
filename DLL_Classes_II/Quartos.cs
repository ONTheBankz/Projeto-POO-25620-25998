/// <summary>
/// Classe para criação de funções Quarto
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
    public class Quartos : IQuarto
    {
        #region ESTADO
        static List<Quarto> quartos;
        #endregion

        #region CONSTRUTORES
        static Quartos()
        {
            quartos = new List<Quarto>();
        }
        #endregion

        #region PROPRIEDADES
        public static List<Quarto> QUARTO
        {
            get { return quartos; }
            set { quartos = value; }
        }

        #endregion

        #region OUTROS MÉTODOS

        #endregion

    }
}