/// <summary>
/// Classe para descrever um Quarto
/// David Martinho
/// Rafael Rodrigues
/// a25620@alunos.ipca.pt
/// a25998@alunos.ipca.pt
/// 09-11-2023
/// POO-LESI
/// </summary>

using System;

namespace DLL_Classes
{
    public class Quarto
    {
        #region ESTADO
        // Define campos privados para armazenar o estado do objeto Quarto.

        // Identificador único para o quarto.
        private int idQuarto;

        // Tipo de quarto.
        private string tipoQuarto;

        // Indica se o quarto está disponível.
        private bool disponibilidade;

        // Valor do quarto.
        private decimal valor;

        // Referência à instância de Alojamento à qual o quarto está associado.
        private Alojamento alojamento;

        #endregion

        #region COMPORTAMENTO

        #region CONSTRUTORES
        // Construtor padrão inicializa os campos com valores padrão.
        public Quarto()
        {
            idQuarto = 0;
            tipoQuarto = "";
            disponibilidade = false;
            valor = 0;
            alojamento = null;
        }
        // Construtor parametrizado inicializa o Quarto com valores específicos.
        public Quarto(int idQuarto, string tipoQuarto, bool disponibilidade, decimal valor, Alojamento alojamento)
        {
            this.idQuarto = idQuarto;
            this.tipoQuarto = tipoQuarto;
            this.disponibilidade = disponibilidade;
            this.valor = valor;
            this.alojamento = alojamento;
        }
        #endregion

        #region PROPRIEDADES
        // Propriedades para acessar os campos privados.

        public int ID
        {
            get { return idQuarto; }
            set { idQuarto = value; }
        }

        public string Tipo
        {
            get { return tipoQuarto; }
            set { tipoQuarto = value; }
        }

        public bool Disponibilidade
        {
            get { return disponibilidade; }
            set { disponibilidade = value; }
        }

        public decimal Valor
        {
            get { return valor; }
            set { valor = value; }
        }

        public Alojamento Alojamento
        {
            get { return alojamento; }
            set { alojamento = value; }
        }

        #endregion

        #region MÉTODOS

        // Outros métodos relacionados à gestão do quarto.

        #endregion

        #region OPERADORES 
        // Operador de igualdade para comparar dois quartos com base no ID do quarto.
        public static bool operator ==(Quarto q1, Quarto q2)
        {
            return q1.idQuarto == q2.idQuarto;
        }
        // Operador de desigualdade para negar a igualdade entre dois quartos.
        public static bool operator !=(Quarto q1, Quarto q2)
        {
            return !(q1 == q2);
        }

        #endregion

        #region OVERRIDES
        // Método ToString para obter uma representação de string do objeto Quarto.
        public override string ToString()
        {
            return string.Format("ID: {0}\nID Alojamento: {1}\nTipo: {2}\nDisponibilidade: {3}\nValor: {4}\n",
                                 idQuarto, alojamento.ID, tipoQuarto, disponibilidade, valor);
        }

        // Método Equals para comparar objetos Quarto.
        public override bool Equals(object obj)
        {
            if (obj is Quarto)
            {
                Quarto q = (Quarto)obj;
                return this == q;
            }
            return false;
        }

        #endregion

        #endregion
    }
}