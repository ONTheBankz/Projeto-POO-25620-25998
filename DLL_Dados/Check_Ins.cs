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
using DLL_Objetos;

namespace DLL_Dados
{
    public class Check_Ins : ICheck_In
    {
        #region ESTADO
        static List<CheckIn> checkIns;
        #endregion

        #region CONSTRUTORES
        static Check_Ins()
        {
            checkIns = new List<CheckIn>();
        }
        #endregion

        #region PROPRIEDADES
        public static List<CheckIn> CHECKIN
        {
            get { return checkIns; }
            set { checkIns = value; }
        }

        #endregion

        #region OUTROS MÉTODOS

        public bool GravarCheck_I(string ci)
        {
            try
            {
                using (StreamWriter writer = File.CreateText(ci))
                {
                    foreach (var check_i in checkIns)
                    {
                        writer.WriteLine($"{check_i.ID}#{check_i.Reserva.ID}#{check_i.DataCheckIO}");
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao gravar check_in: {ex.Message}");
                return false;
            }
        }

        public bool LerCheck_I(string ci)
        {
            if (!File.Exists(ci))
            {
                // Se o ficheiro não existir, cria um novo ficheiro vazio
                using (File.Create(ci)) { }
                return false; // Retorna falso porque não há dados para ler
            }
            using (StreamReader sr = File.OpenText(ci))
            {
                string linha = sr.ReadLine();
                while (linha != null)
                {
                    string[] sdados = linha.Split('#');
                    int id = int.Parse(sdados[0]);
                    int reservaID = int.Parse(sdados[1]);
                    DateTime dataCheck_I = DateTime.Parse(sdados[2]);

                    Reserva reserva = new Reserva { ID = reservaID };
                    CheckIn checkin = new CheckIn(id, reserva, dataCheck_I);

                    checkIns.Add(checkin);

                    linha = sr.ReadLine();
                }
            }
            return true;
        }

        public bool InserirCheck_I(CheckIn ci)
        {
            checkIns.Add(ci);
            return true;
        }

        public bool ExisteCheck_I(int ID)
        {
            foreach (CheckIn check_in in checkIns)
            {
                if (check_in.ID == ID)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

    }
}