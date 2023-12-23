using DLL_Regras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_POO_25620_25998
{
    internal class Program
    {
        static void Main(string[] args)
        {        
            Regras regras = new Regras();
            regras.LerAdmin("admins");
            regras.LerCliente("clientes");
            regras.LerFunc("funcionarios");
            regras.LerAlojamento("alojamentos");
            regras.LerQuarto("quartos");

            MenuPrincipal m = new MenuPrincipal();
            m.MostrarMenuP();
         
            regras.GravarCliente(@"clientes");
            regras.GravarFunc(@"funcionarios");
            regras.GravarAlojamento(@"alojamentos");
            regras.GravarQuarto(@"quartos");
      
        }
    }
}
