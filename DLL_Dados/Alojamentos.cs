/// <summary>
/// Classe para criação de funções Alojamento
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
    public class Alojamentos : IAlojamento
    {
        #region ESTADO
        static List<Alojamento> alojamentos;
        #endregion

        #region CONSTRUTORES
        static Alojamentos()
        {
            alojamentos = new List<Alojamento>();
        }
        #endregion

        #region PROPRIEDADES
        public static List<Alojamento> ALOJAMENTO
        {
            get { return alojamentos; }
            set { alojamentos = value; }
        }

        #endregion

        #region OUTROS MÉTODOS

        public bool GravarAlojamento(string a)
        {
            try
            {
                using (StreamWriter writer = File.CreateText(a))
                {
                    foreach (var alojamento in alojamentos)
                    {
                        writer.WriteLine($"{alojamento.ID}#{alojamento.Nome}#{alojamento.Tipo}#{alojamento.Localizacao}");
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao gravar produtos: {ex.Message}");
                return false;
            }
        }

        public bool LerAlojamento(string a)
        {
            using (StreamReader sr = File.OpenText(a))
            {
                string linha = sr.ReadLine();
                while (linha != null)
                {
                    string[] sdados = linha.Split('#');
                    int id = int.Parse(sdados[0]);
                    string nome = (sdados[1]);
                    string tipo = (sdados[2]);
                    string localização = (sdados[3]);

                    Alojamento alojamento = new Alojamento(id, nome, tipo, localização);

                    alojamentos.Add(alojamento);

                    linha = sr.ReadLine();
                }
            }
            return true;
        }

        public bool InserirAlojamento(Alojamento a)
        {
            alojamentos.Add(a);
            return true;
        }

        public bool ListarAlojamentos()
        {
            foreach (Alojamento alojamento in ALOJAMENTO)
            {
                Console.WriteLine("ID: {0}\nNome: {1}\nTipo: {2}\nLocalização: {3}", alojamento.ID, alojamento.Nome, alojamento.Tipo, alojamento.Localizacao);
            }
            return true;
        }

        public bool ExisteAlojamento(int ID)
        {
            foreach (Alojamento alojamento in alojamentos)
            {
                if (alojamento.ID == ID)
                {
                    return true;
                }
            }
            return false;
        }

  
      

        #endregion

    }
}