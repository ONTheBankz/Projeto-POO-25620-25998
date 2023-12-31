/// <summary>
/// Classe para criação de funções Check-In
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
using DLL_Exceptions;
using DLL_Objetos;

namespace DLL_Dados
{
    public class Check_Ins : ICheck_In
    {
        #region ESTADO

        /// <summary>
        /// Lista que contém os check-ins.
        /// </summary>

        static List<CheckIn> checkIns;
        #endregion

        #region CONSTRUTORES

        /// <summary>
        /// Construtor que inicializa a lista dos check-ins.
        /// </summary>

        static Check_Ins()
        {
            checkIns = new List<CheckIn>();
        }
        #endregion

        #region PROPRIEDADES

        /// <summary>
        /// Propriedade que acede à lista dos check-ins.
        /// </summary>

        public static List<CheckIn> CHECKIN
        {
            get { return checkIns; }
            set { checkIns = value; }
        }

        #endregion

        #region OUTROS MÉTODOS

        /// <summary>
        /// Grava os detalhes dos check-ins num ficheiro.
        /// </summary>
        /// <param name="ci">Caminho do ficheiro onde os dados dos check-ins serão gravados.</param>
        /// <returns>Verdadeiro se a gravação for bem-sucedida, falso caso contrário.</returns>
        public bool GravarCheck_I(string ci)
        {
            try
            {
                // Abre um StreamWriter para criar ou substituir o conteúdo do ficheiro especificado.
                using (StreamWriter writer = File.CreateText(ci))
                {
                    // Itera sobre cada check-in na lista.
                    foreach (var checkIn in checkIns)
                    {
                        // Escreve a linha formatada no ficheiro contendo os detalhes do check-in.
                        writer.WriteLine($"{checkIn.ID}#{checkIn.Reserva.ID}#{checkIn.DataCheckIO}");
                    }
                }
                return true; // Retorna verdadeiro se a gravação for bem-sucedida.
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao gravar check-in: {ex.Message}");
                return false; // Retorna falso se ocorrer uma exceção ao tentar gravar os dados.
            }
        }

        /// <summary>
        /// Lê os detalhes dos check-ins a partir de um ficheiro e preenche a lista de check-ins com esses detalhes.
        /// </summary>
        /// <param name="ci">Caminho do ficheiro de onde os dados dos check-ins serão lidos.</param>
        /// <returns>Verdadeiro se a leitura for bem-sucedida, falso caso contrário.</returns>
        public bool LerCheck_I(string ci)
        {
            if (!File.Exists(ci))
            {
                // Se o ficheiro não existir, cria um novo ficheiro vazio.
                using (File.Create(ci)) { }
                return false; // Retorna falso porque não há dados para ler.
            }
            using (StreamReader sr = File.OpenText(ci))
            {
                string linha = sr.ReadLine();
                while (linha != null)
                {
                    // Divide a linha usando '#' como delimitador.
                    string[] sdados = linha.Split('#');
                    int id = int.Parse(sdados[0]);
                    int reservaID = int.Parse(sdados[1]);
                    DateTime dataCheckIn = DateTime.Parse(sdados[2]);

                    // Cria instâncias de Reserva e CheckIn com os dados lidos.
                    Reserva reserva = new Reserva { ID = reservaID };
                    CheckIn checkIn = new CheckIn(id, reserva, dataCheckIn);

                    // Adiciona o CheckIn à lista de check-ins.
                    checkIns.Add(checkIn);

                    linha = sr.ReadLine();
                }
            }
            return true; // Retorna verdadeiro se a leitura for bem-sucedida.
        }

        /// <summary>
        /// Insere um novo check-in na lista de check-ins.
        /// </summary>
        /// <param name="ci">Check-in a ser inserido.</param>
        /// <returns>Verdadeiro se a inserção foi bem-sucedida.</returns>
        public bool InserirCheck_I(CheckIn ci)
        {
            // Verifica se já existe um check-in com o mesmo ID.
            if (ExisteCheck_I(ci.ID))
            {
                // Lança uma exceção personalizada se o check-in já existe.
                throw new ECheck_In();
            }

            // Adiciona o novo check-in à lista de check-ins.
            checkIns.Add(ci);
            return true;
        }

        /// <summary>
        /// Remove um check-in da lista de check-ins.
        /// </summary>
        /// <param name="ci">Check-in a ser removido.</param>
        /// <returns>Verdadeiro se a remoção for bem-sucedida.</returns>
        public bool RemoverCheck_I(CheckIn ci)
        {
            // Remove o check-in especificado da lista de check-ins.
            checkIns.Remove(ci);
            return true;
        }

        /// <summary>
        /// Lista os detalhes do(s) check-in(s) na consola.
        /// </summary>
        /// <returns>Verdadeiro se a listagem for bem-sucedida.</returns>
        public bool ListarCheck_I()
        {
            OrdenarCheck_I(); // Chama o método de ordenação antes de listar os check-ins.
            foreach (CheckIn checkIn in CHECKIN)
            {
                Console.WriteLine("ID Check-In: {0}\nID Reserva: {1}\nData Check-In: {2}\n",
                                    checkIn.ID, checkIn.Reserva.ID, checkIn.DataCheckIO.ToShortDateString());
            }
            return true;
        }

        /// <summary>
        /// Verifica se existe um check-in com o ID fornecido na lista de check-ins.
        /// </summary>
        /// <param name="ID">ID do check-in a ser verificado.</param>
        /// <returns>Verdadeiro se um check-in com o ID fornecido existir, falso caso contrário.</returns>
        public bool ExisteCheck_I(int ID)
        {
            foreach (CheckIn checkIn in checkIns)
            {
                if (checkIn.ID == ID)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Gera um novo ID para um check-in adicionando mais um ao ID mais alto existente na lista de check-ins.
        /// </summary>
        /// <param name="id">ID a ser gerado para o novo check-in.</param>
        /// <returns>O próximo ID disponível para um novo check-in.</returns>
        public int ID(int id)
        {
            for (int i = 0; i < checkIns.Count; i++)
            {
                id = checkIns[i].ID;
            }
            id++;
            return id;
        }

        /// <summary>
        /// Ordena a lista de check-ins.
        /// </summary>
        public void OrdenarCheck_I()
        {
            checkIns.Sort();
        }

        #endregion

    }
}
