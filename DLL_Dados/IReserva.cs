﻿/// <summary>
/// Interface para listagem de métodos Reserva
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
    internal interface IReserva
    {
        bool GravarReserva(string r);
        bool LerReserva(string r);
        bool InserirReserva(Reserva r);
        bool RemoverReserva(Reserva r);
        bool ListarReserva();
        bool ExisteReserva(int ID);
    }
}
