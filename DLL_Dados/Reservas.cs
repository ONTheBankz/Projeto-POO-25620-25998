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
using DLL_Objetos;
using DLL_Exceptions;

namespace DLL_Dados
{
    public class Reservas : IReserva
    {
        #region ESTADO

        /// <summary>
        /// Lista que contém as reservas.
        /// </summary>

        static List<Reserva> reservas;
        #endregion

        #region CONSTRUTORES

        /// <summary>
        /// Construtor que inicializa a lista das reservas.
        /// </summary>

        static Reservas()
        {
            reservas = new List<Reserva>();
        }
        #endregion

        #region PROPRIEDADES

        /// <summary>
        /// Propriedade que acede à lista das reservas.
        /// </summary>

        public static List<Reserva> RESERVA
        {
            get { return reservas; }
            set { reservas = value; }
        }

        #endregion

        #region OUTROS MÉTODOS

        /// <summary>
        /// Grava os detalhes das reservas em um arquivo.
        /// </summary>
        /// <returns> Verdadeiro se a gravação for bem-sucedida, falso caso contrário. </returns>

        public bool GravarReserva(string r)
        {
            try
            {
                using (StreamWriter writer = File.CreateText(r))
                {
                    foreach (var reserva in reservas)
                    {
                        writer.WriteLine($"{reserva.ID}#{reserva.DataInicio}#{reserva.DataFim}#{reserva.NumPessoas}#{reserva.Cliente.NIF}" +
                            $"#{reserva.Quarto.ID}#{reserva.PrecoTotal}");
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

        /// <summary>
        /// Lê os detalhes das reservas de um arquivo e preenche a lista de reservas com esses detalhes.
        /// </summary>
        /// <returns> Verdadeiro se a leitura for bem-sucedida, falso caso contrário. </returns>

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
                    int quartoID = int.Parse(sdados[5]);
                    decimal precototal = decimal.Parse(sdados[6]);

                    Cliente cliente = new Cliente { NIF = clientenif };
                    Quarto quarto = new Quarto { ID = quartoID };

                    Reserva reserva = new Reserva(id, datainicio, datafim, numpessoas, cliente, quarto, precototal);

                    reservas.Add(reserva);

                    linha = sr.ReadLine();
                }
            }
            return true;
        }

        /// <summary>
        /// Insere uma nova reserva na lista de reservas.
        /// </summary>
        /// <returns> Verdadeiro se a inserção for bem-sucedida. </returns>

        public bool InserirReserva(Reserva r)
        {
            if (ExisteReserva(r.ID))
            {
                throw new EReserva();
            }
            reservas.Add(r);
            return true;
        }

        /// <summary>
        /// Remove uma reserva da lista de reservas.
        /// </summary>
        /// <returns> Verdadeiro se a remoção for bem-sucedida. </returns>

        public bool RemoverReserva(Reserva r)
        {
            reservas.Remove(r);
            return true;
        }

        /// <summary>
        /// Verifica se existe uma reserva com o ID fornecido na lista de reservas.
        /// </summary>
        /// <param name="ID"> ID da reserva a ser verificada. </param>
        /// <returns> Verdadeiro se uma reserva com o ID fornecido existir, falso caso contrário. </returns>

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

        /// <summary>
        /// Retorna um novo ID para uma reserva com base na contagem atual de reservas.
        /// </summary>
        /// <param name="id"> ID atual da reserva. </param>
        /// <returns> Novo ID baseado na contagem atual de reservas. </returns>

        public int ID(int id)
        {
            for (int i = 0; i < reservas.Count; i++)
            {
                id = reservas[i].ID;
            }
            id++;
            return id;
        }

        /// <summary>
        /// Ordena a lista de reservas.
        /// </summary>

        public void OrdenarReserva()
        {
            reservas.Sort();
        }

        #endregion
    }
}