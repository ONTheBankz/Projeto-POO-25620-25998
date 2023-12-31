using DLL_Regras;
using System;

namespace TP_POO_25620_25998
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Instância da classe Regras 
            Regras regras = new Regras();

            // Leitura dos dados de admin, cliente, funcionário, alojamento, quarto, reserva, check-in e check-out
            regras.LerAdmin("admins");
            regras.LerCliente("clientes");
            regras.LerFunc("funcionarios");
            regras.LerAlojamento("alojamentos");
            regras.LerQuarto("quartos");
            regras.LerReserva("reservas");
            regras.LerCheck_I("check_ins");
            regras.LerCheck_O("check_outs");

            // Instância da classe MenuPrincipal 
            MenuPrincipal m = new MenuPrincipal();
            m.MostrarMenuP();

            // Gravação dos dados de cliente, funcionário, alojamento, quarto, reserva, check-in e check-out
            regras.GravarCliente(@"clientes");
            regras.GravarFunc(@"funcionarios");
            regras.GravarAlojamento(@"alojamentos");
            regras.GravarQuarto(@"quartos");
            regras.GravarReserva(@"reservas");
            regras.GravarCheck_I(@"check_ins");
            regras.GravarCheck_O(@"check_outs");
        }
    }
}
