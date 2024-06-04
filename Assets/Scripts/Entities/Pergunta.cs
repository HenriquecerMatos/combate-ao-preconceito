using System.Linq;

namespace Entities
{
    [System.Serializable]
    public class ListaPerguntas
    {
        public Pergunta[] Perguntas;
    }

    [System.Serializable]
    public class Pergunta
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
    public class Resposta
    {
        public string Texto;
        public int Valor;
    }
}