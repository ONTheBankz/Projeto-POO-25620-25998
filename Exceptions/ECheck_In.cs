/// <summary>
/// Classe para defenir exceptions relativas ao(s) check-in(s).
/// David Martinho
/// Rafael Rodrigues
/// a25620@alunos.ipca.pt
/// a25998@alunos.ipca.pt
/// 09-11-2023
/// POO-LESI
/// </summary>

using DLL_Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL_Exceptions
{
    public class ECheck_In : Exception
    {
        public ECheck_In() : base("Erro no check IN")
        {

        }

        public ECheck_In(string s) : base(s) { }

        public ECheck_In(string s, Exception e)
        {
            throw new ECheck_In(s + "-" + e.Message);
        }
    }
}