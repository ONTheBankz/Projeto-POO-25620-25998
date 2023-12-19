/// <summary>
/// Interface para listagem de métodos Alojamento
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
    internal interface IAlojamento
    {
        bool GravarAlojamento(string a);
        bool LerAlojamento(string a);
        bool InserirAlojamento(Alojamento a);
        bool ListarAlojamentos();
        bool ExisteAlojamento(int ID);
    }
}
