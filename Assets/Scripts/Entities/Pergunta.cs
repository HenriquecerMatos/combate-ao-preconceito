using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

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
        public string Id;
    }

    #region Salvar Respostas


    [System.Serializable]
    public class ListaPerguntasRespostas
    {
        public bool Sincronizado;
        public PerguntasRespostas[] listaPerguntasRespostas;
        public int ValorTotal() => listaPerguntasRespostas.Sum(x => x.Valor);
    }

    [System.Serializable]
    public class PerguntasRespostas
    {
        public DificuldadeEnum Dificuldade;
        public string PerguntaId;
        public string RepostaId;
        public int Valor;
    }
    #endregion
}