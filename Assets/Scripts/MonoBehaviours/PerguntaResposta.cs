using Entities;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PerguntaResposta : MonoBehaviour
{
    public TMP_Text PerguntaTexto;
    public Transform AlternativaExemplo;
    public Pergunta Pergunta;
    public List<RectTransform> Alternativas;
    public RectTransform AlternativaSelecionada;
    public Color CorAlternativaSelecionada = Color.green;
    public Color CorAlternativaPadrao = Color.white;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CriarPerguntaAlternativas()
    {
        Alternativas = new();
        var tmpPergunta = PerguntaTexto;
        tmpPergunta.text = Pergunta.Texto;
        for (int i = 0; i < Pergunta.Respostas.Length; i++)
        {

            GameObject clone = Instantiate(AlternativaExemplo.gameObject, new(), Quaternion.identity);
            // Define o objeto clonado como filho do objeto pai
            clone.transform.SetParent(transform);

            clone.GetComponent<AlternativaElemento>().Header.text = $"{i+1}° Alternativa";
            clone.GetComponent<AlternativaElemento>().Alternativa.text = Pergunta.Respostas[i].Texto;

            //ativa o elemento
            clone.SetActive(true);

            Alternativas.Add(clone.GetComponent<RectTransform>());
        }
        // Aguarda o próximo intervalo
    }
    /// <summary>
    /// altera a cor das alternativas e seleciona uma resposta, chamado por UI
    /// </summary>
    /// <param name="elemento"></param>
    public void SetarResposta(RectTransform elemento)
    {
        AlternativaSelecionada = elemento;
        Alternativas.ForEach(e =>
        {
            e.GetComponent<UnityEngine.UI.Image>().color = CorAlternativaPadrao;
        });
        AlternativaSelecionada.GetComponent<UnityEngine.UI.Image>().color = CorAlternativaSelecionada;
    }
}
