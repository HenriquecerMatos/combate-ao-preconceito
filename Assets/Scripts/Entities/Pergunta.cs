using System.Collections.Generic;
using System.Linq;

namespace Entities
{
    [System.Serializable]
    public class ListaPerguntas
    {
        public List<Pergunta> Perguntas;
    }

    [System.Serializable]
    public class Pergunta : BaseEntity
    {

        public string Texto;
        public Resposta[] Respostas;
        public int ValorMax
        {
            get
            {
                return Respostas.Max(x => x.Valor);
            }
        }
    }

    [System.Serializable]
    public class Resposta : BaseEntity
    {
        public string Texto;
        public int Valor;
    }

    [System.Serializable]
    public class BaseEntity
    {
        public int Id;
        public string Key;
    }

    #region Salvar Respostas


    [System.Serializable]
    public class ListaRespostasDadas
    {
        public bool Sincronizado;
        public List<RespostaSelecionada> listaPerguntasRespostas = new();
        public string Caracteristicas;
        public float Peso;
        public int ValorTotal() => listaPerguntasRespostas.Sum(x => x.Valor);
        public float ValorTotalComPeso() => listaPerguntasRespostas.Sum(x => CalculadoApartirDasCaracteisticas(x.Valor));

        private float CalculadoApartirDasCaracteisticas(float entrada)
        {
            //float entrada = ValorTotal();
            var pesoTotal = Peso;

            //se a resposta tiver valor 0 não é necessário calcular
            if (entrada == 0)
            {
                return entrada;
            }
            else if (entrada > 0)//se entrada maior q 0 calcula de acordo com o peso
            {
                return entrada + (entrada * (pesoTotal) * -1);
            }
            else
            {
                return entrada - (entrada * (pesoTotal) * -1);
            }
        }
    }

    [System.Serializable]
    public class RespostaSelecionada
    {
        //public DificuldadeEnum Dificuldade;
        public string PerguntaKey;
        public string RepostaKey;
        public int Valor;
    }
    #endregion
}