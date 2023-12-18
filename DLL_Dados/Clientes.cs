/// <summary>
/// Classe para criação de funções Cliente
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
    public class Clientes : ICliente
    {
        #region ESTADO
        static List<Cliente> clientes;
        #endregion

        #region CONSTRUTORES
        static Clientes()
        {
            clientes = new List<Cliente>();
        }
        #endregion

        #region PROPRIEDADES
        public static List<Cliente> CLIENTE
        {
            get { return clientes; }
            set { clientes = value; }
        }

        #endregion

        #region OUTROS MÉTODOS

        public bool InserirCliente(Cliente c)
        {
            clientes.Add(c);
            return true;
        }

        public bool ExisteCliente(int NIF)
        {
            foreach (Cliente cliente in clientes)
            {
                if (cliente.NIF == NIF)
                {
                    return true;
                }
            }
            return false;
        }
        #endregion
    }
}