using Entities;
using UnityEngine;

public class PerguntaDroper : MonoBehaviour
{
    public Pergunta Pergunta;
   public void DestroirDroper()
    {
        Destroy(gameObject);
    }
}
