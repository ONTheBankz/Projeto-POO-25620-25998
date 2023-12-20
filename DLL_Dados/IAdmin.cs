﻿/// <summary>
/// Interface para listagem de métodos Admin
/// David Martinho
/// Rafael Rodrigues
/// a25620@alunos.ipca.pt
/// a25998@alunos.ipca.pt
/// 09-11-2023
/// POO-LESI
/// </summary>

using System;
using DLL_Objetos;

namespace DLL_Dados
{
    internal interface IAdmin
    {
        bool LerAdmin(string a);
        bool ExisteAdmin(int ID);
        bool AuthAdmin(int ID, string Password);
    }
}
