/// <summary>
/// Classe para defenir exceptions relativas à(s) reserva(s).
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
    public class EReserva : Exception
    {
        public EReserva() : base("Erro nas reservas")
        {

        }

        public EReserva(string s) : base(s) { }

        public EReserva(string s, Exception e)
        {
            throw new EReserva(s + "-" + e.Message);
        }
    }
}