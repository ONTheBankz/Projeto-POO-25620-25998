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
        /// <param name="co">Caminho do ficheiro de check-outs.</param>
        /// <returns>Verdadeiro se a gravação for bem-sucedida, falso caso contrário.</returns>
        public bool GravarCheck_O(string co)
        {
            try
            {
                // Cria um StreamWriter para escrever no ficheiro indicado.
                using (StreamWriter writer = File.CreateText(co))
                {
                    // Itera sobre todos os check-outs na lista.
                    foreach (var checkOut in checkOuts)
                    {
                        // Escreve os detalhes do check-out no ficheiro.
                        writer.WriteLine($"{checkOut.ID}#{checkOut.Check_In.ID}#{checkOut.DataCheckIO}");
                    }
                }
                return true; // Retorna verdadeiro se a gravação for bem-sucedida.
            }
            catch (Exception ex)
            {
                // Em caso de exceção, imprime uma mensagem de erro na consola.
                Console.WriteLine($"Erro ao gravar check-out: {ex.Message}");
                return false; // Retorna falso se a gravação falhar.
            }
        }

        /// <summary>
        /// Lê os detalhes dos check-outs a partir de um ficheiro e preenche a lista de check-outs com esses detalhes.
        /// </summary>
        /// <param name="co">Caminho do ficheiro de check-outs.</param>
        /// <returns>Verdadeiro se a leitura for bem-sucedida, falso caso contrário.</returns>
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
                    // Divide a linha em partes com base no caractere '#' e converte os valores para os tipos apropriados.
                    string[] sdados = linha.Split('#');
                    int id = int.Parse(sdados[0]);
                    int checkinID = int.Parse(sdados[1]);
                    DateTime dataCheckOut = DateTime.Parse(sdados[2]);

                    // Cria instâncias de CheckIn e CheckOut com os dados lidos.
                    CheckIn checkin = new CheckIn { ID = checkinID };
                    CheckOut checkout = new CheckOut(id, checkin, dataCheckOut);

                    // Adiciona o checkout à lista de check-outs.
                    checkOuts.Add(checkout);
                    linha = sr.ReadLine();
                }
            }
            return true; // Retorna verdadeiro se a leitura for bem-sucedida.
        }

        /// <summary>
        /// Insere um novo check-out na lista de check-outs.
        /// </summary>
        /// <param name="co">Check-out a ser inserido.</param>
        /// <returns>Verdadeiro se a inserção for bem-sucedida.</returns>
        public bool InserirCheck_O(CheckOut co)
        {
            // Verifica se já existe um check-out com o mesmo ID na lista.
            if (ExisteCheck_O(co.ID))
            {
                throw new ECheck_Out(); // Lança uma exceção se o check-out já existir.
            }

            // Adiciona o novo check-out à lista.
            checkOuts.Add(co);
            return true; // Retorna verdadeiro indicando que a inserção foi bem-sucedida.
        }

        /// <summary>
        /// Remove um check-out da lista de check-outs.
        /// </summary>
        /// <param name="co">Check-out a ser removido.</param>
        /// <returns>Verdadeiro se a remoção for bem-sucedida.</returns>
        public bool RemoverCheck_O(CheckOut co)
        {
            // Remove o check-out da lista.
            checkOuts.Remove(co);
            return true; // Retorna verdadeiro indicando que a remoção foi bem-sucedida.
        }

        /// <summary>
        /// Lista os detalhes do(s) check-out(s) na consola.
        /// </summary>
        /// <returns>Verdadeiro se a listagem for bem-sucedida.</returns>
        public bool ListarCheck_O()
        {
            OrdenarCheck_O(); // Chama o método de ordenação antes de listar os check-outs.
            foreach (CheckOut checkOut in CHECKOUT)
            {
                Console.WriteLine("ID Check-Out: {0}\nID Check-In: {1}\nData Check-Out: {2}\n",
                                 checkOut.ID, checkOut.Check_In.ID, checkOut.DataCheckIO.ToShortDateString());
            }
            return true; // Retorna verdadeiro indicando que a listagem foi bem-sucedida.
        }

        /// <summary>
        /// Verifica se existe um check-out com o ID fornecido na lista de check-outs.
        /// </summary>
        /// <param name="ID">ID do check-out a ser verificado.</param>
        /// <returns>Verdadeiro se um check-out com o ID fornecido existir, falso caso contrário.</returns>
        public bool ExisteCheck_O(int ID)
        {
            foreach (CheckOut checkOut in checkOuts)
            {
                if (checkOut.ID == ID)
                {
                    return true;
                }
            }
            return false; // Retorna falso se nenhum check-out com o ID fornecido for encontrado.
        }

        /// <summary>
        /// Gera um novo ID para um check-out adicionando mais um ao ID mais alto existente na lista de check-outs.
        /// </summary>
        /// <param name="id">ID a ser gerado para o novo check-out.</param>
        /// <returns>O próximo ID disponível para um novo check-out.</returns>
        public int ID(int id)
        {
            for (int i = 0; i < checkOuts.Count; i++)
            {
                id = checkOuts[i].ID;
            }
            id++;
            return id;
        }

        /// <summary>
        /// Ordena a lista de check-outs.
        /// </summary>
        public void OrdenarCheck_O()
        {
            checkOuts.Sort();
        }

        #endregion
    }
}