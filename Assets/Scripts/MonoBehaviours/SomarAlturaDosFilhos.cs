using System.Linq;
using UnityEngine;

public class SomarAlturaDosFilhos : MonoBehaviour
{
    public float AlturaDosFilhos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   public void Somar()
    {
        AlturaDosFilhos = 0;
       var alturaAtual = transform.GetComponent<RectTransform>().rect.height;
       //var filhos = gameObject.GetComponentsInChildren<RectTransform>();
       //
       //AlturaDosFilhos = filhos.Sum(x => x.rect.height);
       //


        Transform parentTransform = this.transform;

        // Itera sobre cada filho direto
        for (int i = 0; i < parentTransform.childCount; i++)
        {
            Transform childTransform = parentTransform.GetChild(i);
            AlturaDosFilhos += childTransform.GetComponent<RectTransform>().rect.height;
            // Faz algo com cada filho direto
            //Debug.Log("Filho direto: " + childTransform.name);
        }

       //gameObject.GetComponent<RectTransform>().rect.height = AlturaDosFilhos;
    }

    // Update is called once per frame
    void Update()
    {
        Somar();

        RectTransform rectTransform = GetComponent<RectTransform>();
        Vector2 newSize = rectTransform.sizeDelta;
        newSize.y = AlturaDosFilhos; // Defina o novo valor da altura
        rectTransform.sizeDelta = newSize;
    }
}
