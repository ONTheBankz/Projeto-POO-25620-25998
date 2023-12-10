/// <summary>
/// Classe para criação de funções Pessoa
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
    public class Pessoas : IPessoa
    {
        #region ESTADO
        static List<Pessoa> pessoas;
        #endregion

        #region CONSTRUTORES
        static Pessoas()
        {
            pessoas = new List<Pessoa>();
        }
        #endregion

        #region PROPRIEDADES
        public static List<Pessoa> PESSOA
        {
            get { return pessoas; }
            set { pessoas = value; }
        }

        #endregion

        #region OUTROS MÉTODOS

        #endregion

    }
}