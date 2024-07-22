using Entities;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PerguntaResposta : MonoBehaviour
{
    public JogoController Controller;
    [Space(20)]
    public TMP_Text PerguntaTexto;
    public Transform AlternativaExemplo;
    public Pergunta Pergunta;
    public List<RectTransform> Alternativas;
    public RectTransform AlternativaSelecionada;
    public Color CorAlternativaSelecionada = Color.green;
    public Color CorAlternativaPadrao = Color.white;
    [Space(10)]
    public GameObject[] ListaDeObjetosIgnoradosAoSeTornarVisivel;

    public void ApagarAlternativasGeradas()
    {
        Alternativas = new();
        Transform[] listaDeletar = GetComponentsInChildren<Transform>();

        var listaParaRemover =new  List<GameObject>();
        for (int i = 0; i < listaDeletar.Count(); i++)
        {
            var item = listaDeletar[i];
            if (!ListaDeObjetosIgnoradosAoSeTornarVisivel.Contains(item.gameObject) && item != transform)
            {
                listaParaRemover.Add(item.gameObject);
            }
        }

        foreach (var item in listaParaRemover)
        {
            Destroy(item);
        }
    }

   
    public void CriarPerguntaAlternativas()
    {
        ApagarAlternativasGeradas();

        var tmpPergunta = PerguntaTexto;
        tmpPergunta.text = Pergunta.Texto;
        for (int i = 0; i < Pergunta.Respostas.Length; i++)
        {

            GameObject clone = Instantiate(AlternativaExemplo.gameObject, new(), Quaternion.identity);
            // Define o objeto clonado como filho do objeto pai
            clone.transform.SetParent(transform);

            var cloneAlternativaElemento = clone.GetComponent<AlternativaElemento>();
            cloneAlternativaElemento.Header.text = $"{i + 1}° Alternativa";
            cloneAlternativaElemento.Alternativa.text = Pergunta.Respostas[i].Texto;

            cloneAlternativaElemento.RespostaSelecionada = new()
            {
                PerguntaKey = Pergunta.Key,
                RepostaKey = Pergunta.Respostas[i].Key,
                Valor = Pergunta.Respostas[i].Valor
            };

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

        var alternativas = elemento.GetComponent<AlternativaElemento>();
        if (alternativas != null)
        {
            var perguntaResposta = alternativas.RespostaSelecionada;
            if (perguntaResposta is not null)
            {
                Controller.UserController.CalcularPontuacao(perguntaResposta);
            }
        }

        gameObject.SetActive(false);
    }
}
