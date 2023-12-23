/// <summary>
/// Classe para criação de funções Quarto
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

namespace DLL_Dados
{
    public class Quartos : IQuarto
    {
        #region ESTADO
        static List<Quarto> quartos;
        #endregion

        #region CONSTRUTORES
        static Quartos()
        {
            quartos = new List<Quarto>();
        }
        #endregion

        #region PROPRIEDADES
        public static List<Quarto> QUARTO
        {
            get { return quartos; }
            set { quartos = value; }
        }

        #endregion

        #region OUTROS MÉTODOS

        public bool GravarQuarto(string q)
        {
            try
            {
                using (StreamWriter writer = File.CreateText(q))
                {
                    foreach (var quarto in quartos)
                    {
                        writer.WriteLine($"{quarto.ID}#{quarto.Tipo}#{quarto.Disponibilidade}#{quarto.Valor}#{quarto.Alojamento.ID}");
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao gravar quarto: {ex.Message}");
                return false;
            }
        }

        public bool LerQuarto(string q)
        {
            if (!File.Exists(q))
            {
                // Se o ficheiro não existir, cria um novo ficheiro vazio
                using (File.Create(q)) { }
                return false; // Retorna falso porque não há dados para ler
            }
            using (StreamReader sr = File.OpenText(q))
            {
                string linha = sr.ReadLine();
                while (linha != null)
                {
                    string[] sdados = linha.Split('#');
                    int id = int.Parse(sdados[0]);
                    string tipo = (sdados[1]);
                    bool disponibilidade = bool.Parse(sdados[2]);
                    decimal valor = decimal.Parse(sdados[3]);
                    int alojamentoID = int.Parse(sdados[4]);

                    Alojamento alojamento = new Alojamento { ID = alojamentoID };

                    Quarto quarto = new Quarto(id, tipo, disponibilidade, valor, alojamento);

                    quartos.Add(quarto);

                    linha = sr.ReadLine();
                }
            }
            return true;
        }

        public bool InserirQuarto(Quarto q)
        {
            quartos.Add(q);
            return true;
        }

        public bool RemoverQuarto(Quarto q)
        {
            quartos.Remove(q);
            return true;
        }

        public bool ListarQuartos()
        {
            foreach (Quarto quarto in QUARTO)
            {
                Console.WriteLine("ID Quarto: {0}\nTipo Quarto: {1}\nDisponibilidade: {2}\nValor por Noite: {3}\nID Alojamento: {4}\n",
                                 quarto.ID, quarto.Tipo, quarto.Disponibilidade, quarto.Valor, quarto.Alojamento.ID);
            }
            return true;
        }

        public bool ExisteQuarto(int ID)
        {
            foreach (Quarto quarto in quartos)
            {
                if (quarto.ID == ID)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

    }
}