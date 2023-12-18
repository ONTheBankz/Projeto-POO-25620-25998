/// <summary>
/// Classe para descrever um Alojamento
/// David Martinho
/// Rafael Rodrigues
/// a25620@alunos.ipca.pt
/// a25998@alunos.ipca.pt
/// 09-11-2023
/// POO-LESI
/// </summary>

using System;

namespace DLL_Objetos
{
    public class Alojamento
    {
        #region ESTADO 
        // Define campos privados para armazenar o estado do objeto Alojamento.

        // Identificador único para o alojamento.
        private int idAlojamento;

        // Nome do alojamento.
        private string nomeAlojamento;

        // Tipo de alojamento.
        private string tipoAlojamento;

        // Localização do alojamento.
        private string localizacao;

        #endregion

        #region COMPORTAMENTO 

        #region CONSTRUTORES
        // Construtor padrão inicializa os campos com valores padrão.
        public Alojamento()
        {
            idAlojamento = 0;
            nomeAlojamento = "";
            tipoAlojamento = "";
            localizacao = "";
        }
        // Construtor parametrizado inicializa o Alojamento com valores específicos.
        public Alojamento(int idAlojamento, string nomeAlojamento, string tipoAlojamento, string localizacao)
        {
            this.idAlojamento = idAlojamento;
            this.nomeAlojamento = nomeAlojamento;
            this.tipoAlojamento = tipoAlojamento;
            this.localizacao = localizacao;
        }

        #endregion

        #region PROPRIEDADES 
        // Propriedades para acessar os campos privados.

        public int ID
        {
            get { return idAlojamento; }
            set { idAlojamento = value; }
        }

        public string Nome
        {
            get { return nomeAlojamento; }
            set { nomeAlojamento = value; }
        }

        public string Tipo
        {
            get { return tipoAlojamento; }
            set { tipoAlojamento = value; }
        }

        public string Localizacao
        {
            get { return localizacao; }
            set { localizacao = value; }
        }

        #endregion

        #region OPERADORES 
        // Operador de igualdade para comparar dois alojamentos com base no ID do alojamento.
        public static bool operator ==(Alojamento al1, Alojamento al2)
        {
            return al1.idAlojamento == al2.idAlojamento;
        }
        // Operador de desigualdade para negar a igualdade entre dois alojamentos.
        public static bool operator !=(Alojamento al1, Alojamento al2)
        {
            return !(al1 == al2);
        }

        #endregion

        #region OVERRIDES 
        // Método ToString para obter uma representação de string do objeto Alojamento.
        public override string ToString()
        {
            return string.Format("ID: {0}\nNome: {1}\nTipo: {2}\nLocalização: {3}",
                                 idAlojamento, nomeAlojamento, tipoAlojamento, localizacao);
        }

        // Método Equals para comparar objetos Alojamento.
        public override bool Equals(object obj)
        {
            if (obj is Alojamento)
            {
                Alojamento al = (Alojamento)obj;
                return this == al;
            }
            return false;
        }

        #endregion

        #endregion
    }
}