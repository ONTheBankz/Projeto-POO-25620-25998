/// <summary>
/// Classe para criação de funções Funcionario
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
    public class Funcionarios : IFuncionario
    {
        #region ESTADO
        static List<Funcionario> funcionarios;
        #endregion

        #region CONSTRUTORES
        static Funcionarios()
        {
            funcionarios = new List<Funcionario>();
        }
        #endregion

        #region PROPRIEDADES
        public static List<Funcionario> FUNCIONARIO
        {
            get { return funcionarios; }
            set { funcionarios = value; }
        }

        #endregion

        #region OUTROS MÉTODOS

        public bool GravarFunc(string f)
        {
            try
            {
                using (StreamWriter writer = File.CreateText(f))
                {
                    foreach (var funcionario in funcionarios)
                    {
                        writer.WriteLine($"{funcionario.ID}#{funcionario.Nome}#{funcionario.Email}#{funcionario.Password}#{funcionario.Contacto}#{funcionario.DataNascimento}#{funcionario.Alojamento.ID}");
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao gravar funcionario: {ex.Message}");
                return false;
            }
        }

        public bool LerFunc(string f)
        {
            if (!File.Exists(f))
            {
                // Se o ficheiro não existir, cria um novo ficheiro vazio
                using (File.Create(f)) { }
                return false; // Retorna falso porque não há dados para ler
            }

            using (StreamReader sr = File.OpenText(f))
            {
                string linha = sr.ReadLine();
                while (linha != null)
                {
                    string[] sdados = linha.Split('#');
                    int idFunc = int.Parse(sdados[0]);
                    string nome = sdados[1];
                    string email = sdados[2];
                    string password = sdados[3];
                    int contacto = int.Parse(sdados[4]);
                    DateTime datanasc = DateTime.Parse(sdados[5]);
                    int alojamentoID = int.Parse(sdados[6]);

                    Alojamento alojamento = new Alojamento { ID = alojamentoID };

                    Funcionario funcionario = new Funcionario(idFunc, nome, email, password, contacto, datanasc, alojamento);

                    funcionarios.Add(funcionario);

                    linha = sr.ReadLine();
                }
            }
            return true;
        }

        public bool InserirFunc(Funcionario f)
        {
            funcionarios.Add(f);
            return true;
        }

        public bool RemoverFunc(Funcionario f)
        {
            funcionarios.Remove(f);
            return true;
        }

        public bool ListarFunc()
        {
            foreach (Funcionario funcionario in FUNCIONARIO)
            {
                Console.WriteLine("ID: {0}\nNome: {1}\nEmail: {2}\nPassword: {3}\nContacto: {4}\nData Nascimento: {5}\nID Alojamento: {6}\n",
                                 funcionario.ID, funcionario.Nome, funcionario.Email, funcionario.Password, funcionario.Contacto,
                                 funcionario.DataNascimento.ToShortDateString(), funcionario.Alojamento.ID);
            }
            return true;
        }

        public bool ExisteFunc(int ID)
        {
            foreach (Funcionario funcionario in funcionarios)
            {
                if (funcionario.ID == ID)
                {
                    return true;
                }
            }
            return false;
        }

        public bool AuthFunc(int ID, string Password)
        {
            foreach (Funcionario funcionario in funcionarios)
            {
                if (funcionario.ID == ID && funcionario.Password == Password)
                {
                    return true;
                }
            }
            return false; // Alterado de true para false, indicando que a autenticação falhou.
        }

        #endregion
    }
}