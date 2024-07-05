using System.Collections.Generic;
using System.Linq;

namespace Entities
{
    [System.Serializable]
    public class ListaPerguntas
    {
        public Pergunta[] Perguntas;
    }

    [System.Serializable]
    public class Pergunta: BaseEntity
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
    public class Resposta: BaseEntity
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
        public List<RespostaSelecionada> listaPerguntasRespostas=new();
        public int ValorTotal() => listaPerguntasRespostas.Sum(x => x.Valor);
        public Caracteristicas Caracteristicas=new();
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