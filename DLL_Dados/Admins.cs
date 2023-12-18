/// <summary>
/// Classe para criação de funções Admin
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
    public class Admins : IAdmin
    {
        #region ESTADO
        static List<Admin> admins;
        #endregion

        #region CONSTRUTORES
        static Admins()
        {
            admins = new List<Admin>();
        }
        #endregion

        #region PROPRIEDADES
        public static List<Admin> ADMIN
        {
            get { return admins; }
            set { admins = value; }
        }

        #endregion

        #region OUTROS MÉTODOS

        #endregion

    }
}