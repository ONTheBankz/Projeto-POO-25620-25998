/// <summary>
/// Classe para criação de funções Funcionario
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
    public class Funcionarios : IFuncionario
    {
        #region ESTADO
        static List<Funcionario> funcionarios;
        #endregion

        #region CONSTRUTORES
        static Funcionarios()
        {
            funcionarios = new List<Funcionario>();
        }
        #endregion

        #region PROPRIEDADES
        public static List<Funcionario> FUNCIONARIO
        {
            get { return funcionarios; }
            set { funcionarios = value; }
        }

        #endregion

        #region OUTROS MÉTODOS

        #endregion
    }
}