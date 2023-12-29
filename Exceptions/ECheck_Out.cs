/// <summary>
/// Classe para defenir exceptions relativas ao(s) check-out(s).
/// David Martinho
/// Rafael Rodrigues
/// a25620@alunos.ipca.pt
/// a25998@alunos.ipca.pt
/// 09-11-2023
/// POO-LESI
/// </summary>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL_Exceptions
{
    public class ECheck_Out : Exception
    {
        public ECheck_Out() : base("Erro no check OUT")
        {

        }

        public ECheck_Out(string s) : base(s) { }

        public ECheck_Out(string s, Exception e)
        {
            throw new ECheck_Out(s + "-" + e.Message);
        }
    }
}