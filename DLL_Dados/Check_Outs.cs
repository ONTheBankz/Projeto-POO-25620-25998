/// <summary>
/// Classe para criação de funções Check-Out
/// David Martinho
/// Rafael Rodrigues
/// a25620@alunos.ipca.pt
/// a25998@alunos.ipca.pt
/// 09-11-2023
/// POO-LESI
/// </summary>

using System;
using System.Collections.Generic;
using DLL_Exceptions;
using System.IO;
using DLL_Objetos;

namespace DLL_Dados
{
    public class Check_Outs : ICheck_Out
    {
        #region ESTADO

        /// <summary>
        /// Lista que contém os check-outs.
        /// </summary>

        static List<CheckOut> checkOuts;
        #endregion

        #region CONSTRUTORES

        /// <summary>
        /// Construtor que inicializa a lista dos check-outs.
        /// </summary>

        static Check_Outs()
        {
            checkOuts = new List<CheckOut>();
        }
        #endregion

        #region PROPRIEDADES

        /// <summary>
        /// Propriedade que acede à lista dos check-outs.
        /// </summary>

        public static List<CheckOut> CHECKOUT
        {
            get { return checkOuts; }
            set { checkOuts = value; }
        }

        #endregion

        #region OUTROS MÉTODOS

        /// <summary>
        /// Grava os detalhes dos check-outs num ficheiro.
        /// </summary>
        /// <returns> Verdadeiro se a gravação for bem-sucedida, falso caso contrário. </returns>

        public bool GravarCheck_O(string co)
        {
            try
            {
                using (StreamWriter writer = File.CreateText(co))
                {
                    foreach (var check_o in checkOuts)
                    {
                        writer.WriteLine($"{check_o.ID}#{check_o.Check_In.ID}#{check_o.DataCheckIO}");
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao gravar check_out: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Lê os detalhes dos check-outs a partir de um ficheiro e preenche a lista de check-outs com esses detalhes.
        /// </summary>
        /// <returns> Verdadeiro se a leitura for bem-sucedida, falso caso contrário. </returns>

        public bool LerCheck_O(string co)
        {
            if (!File.Exists(co))
            {
                // Se o ficheiro não existir, cria um novo ficheiro vazio
                using (File.Create(co)) { }
                return false; // Retorna falso porque não há dados para ler
            }
            using (StreamReader sr = File.OpenText(co))
            {
                string linha = sr.ReadLine();
                while (linha != null)
                {
                    string[] sdados = linha.Split('#');
                    int id = int.Parse(sdados[0]);
                    int checkinID = int.Parse(sdados[1]);
                    DateTime dataCheck_O = DateTime.Parse(sdados[2]);

                    CheckIn checkin = new CheckIn { ID = checkinID };
                    CheckOut checkout = new CheckOut(id, checkin, dataCheck_O);

                    checkOuts.Add(checkout);
                    linha = sr.ReadLine();
                }
            }
            return true;
        }

        /// <summary>
        /// Insere um novo check-out na lista de check-outs.
        /// </summary>
        /// <returns> Verdadeiro se a inserção for bem-sucedida. </returns>

        public bool InserirCheck_O(CheckOut co)
        {
            if (ExisteCheck_O(co.ID))
            {
                throw new ECheck_Out();
            }
            checkOuts.Add(co);
            return true;
        }

        /// <summary>
        /// Remove um check-out da lista de check-outs.
        /// </summary>
        /// <returns> Verdadeiro se a remoção for bem-sucedida. </returns>

        public bool RemoverCheck_O(CheckOut co)
        {
            checkOuts.Remove(co);
            return true;
        }

        /// <summary>
        /// Lista os detalhes do(s) check-out(s) na consola.
        /// </summary>
        /// <returns> Verdadeiro se a listagem for bem-sucedida. </returns>

        public bool ListarCheck_O()
        {
            foreach (CheckOut check_o in CHECKOUT)
            {
                Console.WriteLine("ID Check-Out: {0}\nID Check_IN: {1}\nData Check-Out: {2}\n",
                                 check_o.ID, check_o.Check_In.ID, check_o.DataCheckIO.ToShortDateString());
            }
            return true;
        }

        /// <summary>
        /// Verifica se existe um check-out com o ID fornecido na lista de check-outs.
        /// </summary>
        /// <param name="ID"> ID do check-out a ser verificado. </param>
        /// <returns> Verdadeiro se um check-out com o ID fornecido existir, falso caso contrário. </returns>

        public bool ExisteCheck_O(int ID)
        {
            foreach (CheckOut check_out in checkOuts)
            {
                if (check_out.ID == ID)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Gera um novo ID para um check-out adicionando mais um ao ID mais alto existente na lista de check-outs.
        /// </summary>
        /// <param name="id"> ID a ser gerado para o novo check-out. </param>
        /// <returns> O próximo ID disponível para um novo check-out. </returns>

        public int ID(int id)
        {
            for (int i = 0; i < checkOuts.Count; i++)
            {
                id = checkOuts[i].ID;
            }
            id++;
            return id;
        }

        #endregion

    }
}