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
        /// <param name="r">Caminho do arquivo onde as reservas serão gravadas.</param>
        /// <returns>Verdadeiro se a gravação for bem-sucedida, falso caso contrário.</returns>
        public bool GravarReserva(string r)
        {
            try
            {
                // Utiliza um StreamWriter para escrever no arquivo especificado.
                using (StreamWriter writer = File.CreateText(r))
                {
                    // Itera sobre cada objeto Reserva na lista de reservas.
                    foreach (var reserva in reservas)
                    {
                        // Escreve uma linha formatada com detalhes da reserva no arquivo.
                        writer.WriteLine($"{reserva.ID}#{reserva.DataInicio}#{reserva.DataFim}#{reserva.NumPessoas}#{reserva.Cliente.NIF}" +
                            $"#{reserva.Quarto.ID}#{reserva.PrecoTotal}");
                    }
                }
                // Retorna verdadeiro indicando que a gravação foi bem-sucedida.
                return true;
            }
            catch (Exception ex)
            {
                // Em caso de exceção, imprime uma mensagem de erro e retorna falso.
                Console.WriteLine($"Erro ao gravar reserva: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Lê os detalhes das reservas de um arquivo e preenche a lista de reservas com esses detalhes.
        /// </summary>
        /// <param name="r">Caminho do arquivo de onde as reservas serão lidas.</param>
        /// <returns>Verdadeiro se a leitura for bem-sucedida, falso caso contrário.</returns>
        public bool LerReserva(string r)
        {
            if (!File.Exists(r))
            {
                // Se o arquivo não existir, cria um novo arquivo vazio.
                using (File.Create(r)) { }
                // Retorna falso porque não há dados para ler.
                return false;
            }
            // Usa StreamReader para ler o conteúdo do arquivo.
            using (StreamReader sr = File.OpenText(r))
            {
                string linha = sr.ReadLine();
                while (linha != null)
                {
                    // Divide a linha em partes usando '#' como delimitador.
                    string[] sdados = linha.Split('#');
                    int id = int.Parse(sdados[0]);
                    DateTime datainicio = DateTime.Parse(sdados[1]);
                    DateTime datafim = DateTime.Parse(sdados[2]);
                    int numpessoas = int.Parse(sdados[3]);
                    int clientenif = int.Parse(sdados[4]);
                    int quartoID = int.Parse(sdados[5]);
                    decimal precototal = decimal.Parse(sdados[6]);

                    // Cria instâncias de Cliente, Quarto e Reserva com os detalhes lidos.
                    Cliente cliente = new Cliente { NIF = clientenif };
                    Quarto quarto = new Quarto { ID = quartoID };

                    Reserva reserva = new Reserva(id, datainicio, datafim, numpessoas, cliente, quarto, precototal);

                    // Adiciona a reserva à lista de reservas.
                    reservas.Add(reserva);

                    // Lê a próxima linha.
                    linha = sr.ReadLine();
                }
            }
            // Retorna verdadeiro indicando que a leitura foi bem-sucedida.
            return true;
        }

        /// <summary>
        /// Insere uma nova reserva na lista de reservas.
        /// </summary>
        /// <param name="r">Objeto Reserva a ser inserido.</param>
        /// <returns>Verdadeiro se a inserção for bem-sucedida.</returns>
        /// <exception cref="EReserva">Exceção lançada se uma reserva com o mesmo ID já existir na lista.</exception>
        public bool InserirReserva(Reserva r)
        {
            // Verifica se já existe uma reserva com o mesmo ID.
            if (ExisteReserva(r.ID))
            {
                // Se existir, lança uma exceção personalizada (EReserva).
                throw new EReserva();
            }

            // Adiciona a nova reserva à lista de reservas.
            reservas.Add(r);

            // Retorna verdadeiro indicando que a inserção foi bem-sucedida.
            return true;
        }

        /// <summary>
        /// Remove uma reserva da lista de reservas.
        /// </summary>
        /// <param name="r">Objeto Reserva a ser removido.</param>
        /// <returns>Verdadeiro se a remoção for bem-sucedida.</returns>
        public bool RemoverReserva(Reserva r)
        {
            // Remove a reserva especificada da lista de reservas.
            reservas.Remove(r);

            // Retorna verdadeiro indicando que a remoção foi bem-sucedida.
            return true;
        }

        /// <summary>
        /// Verifica se existe uma reserva com o ID fornecido na lista de reservas.
        /// </summary>
        /// <param name="ID">ID da reserva a ser verificada.</param>
        /// <returns>Verdadeiro se uma reserva com o ID fornecido existir, falso caso contrário.</returns>
        public bool ExisteReserva(int ID)
        {
            // Itera sobre a lista de reservas para verificar se existe uma reserva com o ID fornecido.
            foreach (Reserva reserva in reservas)
            {
                if (reserva.ID == ID)
                {
                    // Retorna verdadeiro se uma reserva com o ID fornecido for encontrada.
                    return true;
                }
            }

            // Retorna falso se nenhuma reserva com o ID fornecido for encontrada.
            return false;
        }

        /// <summary>
        /// Retorna um novo ID para uma reserva com base na contagem atual de reservas.
        /// </summary>
        /// <param name="id">ID atual da reserva.</param>
        /// <returns>Novo ID baseado na contagem atual de reservas.</returns>
        public int ID(int id)
        {
            // Itera sobre a lista de reservas para obter o ID mais alto.
            for (int i = 0; i < reservas.Count; i++)
            {
                id = reservas[i].ID;
            }

            // Incrementa o ID mais alto encontrado para obter um novo ID.
            id++;

            // Retorna o novo ID.
            return id;
        }

        /// <summary>
        /// Ordena a lista de reservas.
        /// </summary>
        public void OrdenarReserva()
        {
            // Utiliza o método Sort para ordenar a lista de reservas.
            reservas.Sort();
        }

        #endregion
    }
}