/// <summary>
/// Classe para criação de funções Reserva
/// David Martinho
/// Rafael Rodrigues
/// a25620@alunos.ipca.pt
/// a25998@alunos.ipca.pt
/// 09-11-2023
/// POO-LESI
/// </summary>

using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices.ComTypes;
using DLL_Objetos;

namespace DLL_Dados
{
    public class Reservas : IReserva
    {
        #region ESTADO
        static List<Reserva> reservas;
        #endregion

        #region CONSTRUTORES
        static Reservas()
        {
            reservas = new List<Reserva>();
        }
        #endregion

        #region PROPRIEDADES
        public static List<Reserva> RESERVA
        {
            get { return reservas; }
            set { reservas = value; }
        }

        #endregion

        #region OUTROS MÉTODOS

        public bool GravarReserva(string r)
        {
            try
            {
                using (StreamWriter writer = File.CreateText(r))
                {
                    foreach (var reserva in reservas)
                    {
                        writer.WriteLine($"{reserva.ID}#{reserva.DataInicio}#{reserva.DataFim}#{reserva.NumPessoas}#{reserva.Cliente.NIF}" +
                            $"#{reserva.Alojamento.ID}#{reserva.Quarto.ID}#{reserva.PrecoTotal}");
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao gravar reserva: {ex.Message}");
                return false;
            }
        }

        public bool LerReserva(string r)
        {
            if (!File.Exists(r))
            {
                // Se o ficheiro não existir, cria um novo ficheiro vazio
                using (File.Create(r)) { }
                return false; // Retorna falso porque não há dados para ler
            }
            using (StreamReader sr = File.OpenText(r))
            {
                string linha = sr.ReadLine();
                while (linha != null)
                {
                    string[] sdados = linha.Split('#');
                    int id = int.Parse(sdados[0]);
                    DateTime datainicio = DateTime.Parse(sdados[1]);
                    DateTime datafim = DateTime.Parse(sdados[2]);
                    int numpessoas = int.Parse(sdados[3]);
                    int clientenif = int.Parse(sdados[4]);
                    int alojamentoID = int.Parse(sdados[5]);
                    int quartoID = int.Parse(sdados[6]);
                    decimal precototal = decimal.Parse(sdados[7]);

                    Cliente cliente = new Cliente { NIF = clientenif };
                    Alojamento alojamento = new Alojamento { ID = alojamentoID };
                    Quarto quarto = new Quarto { ID = quartoID };

                    Reserva reserva = new Reserva(id, datainicio, datafim, numpessoas, cliente, alojamento, quarto, precototal);

                    reservas.Add(reserva);

                    linha = sr.ReadLine();
                }
            }
            return true;
        }

        public bool InserirReserva(Reserva r)
        {
            reservas.Add(r);
            return true;
        }

        public bool ListarReserva()
        {
            foreach (Reserva reserva in RESERVA)
            {
                Console.WriteLine("ID Reserva: {0}\nData Início: {1}\nData Fim: {2}\nNº Pessoas: {3}\nNIF Cliente: {4}\nID Alojamento: {5}\nID Quarto: {6}\nPreço Total: {7}\n",
                                 reserva.ID, reserva.DataInicio.ToShortDateString(), reserva.DataFim.ToShortDateString(), reserva.NumPessoas, reserva.Cliente.NIF, 
                                 reserva.Alojamento.ID, reserva.Quarto.ID, reserva.PrecoTotal);
            }
            return true;
        }

        public bool ExisteReserva(int ID)
        {
            foreach (Reserva reserva in reservas)
            {
                if (reserva.ID == ID)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion
    }
}