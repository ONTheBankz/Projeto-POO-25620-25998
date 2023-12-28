/// <summary>
/// Interface para listagem de métodos Quarto
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
    internal interface IQuarto  
    {
        bool GravarQuarto(string q);
        bool LerQuarto(string q);
        bool InserirQuarto(Quarto q);
        bool RemoverQuarto(Quarto q);
        bool ListarQuartos();
        bool ExisteQuarto(int ID);
        int ObterQuant(string tipoQuarto);
    }
}
