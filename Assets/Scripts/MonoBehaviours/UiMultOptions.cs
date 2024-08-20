using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//pode ser usado para destacar uma seleção (menu,opções)
public class UiMultOptions : MonoBehaviour
{
    public RectTransform AlternativaSelecionada;
    public List<RectTransform> Alternativas;
    public Color CorAlternativaSelecionada = Color.green;
    public Color CorAlternativaPadrao = Color.white;

    //cria o elemento e adiciona o evento 
    public void CriarElemento(RectTransform elemento)
    {
        Alternativas.Add(elemento);
        if (elemento.GetComponent<Button>())
        {
            elemento.GetComponent<Button>().onClick.AddListener(
                () => SetarResposta(elemento));
        }        
    }
    public void SetarResposta(RectTransform elemento)
    {
        AlternativaSelecionada = elemento;
        Alternativas.ForEach(e =>
        {
            e.GetComponent<Image>().color = CorAlternativaPadrao;
        });
        AlternativaSelecionada.GetComponent<Image>().color = CorAlternativaSelecionada;
    }
}
