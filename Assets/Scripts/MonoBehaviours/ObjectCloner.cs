using Entities;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem.XR;

/// <summary>
/// Responsável por criar as caixas que caem na cena "Jogo"
/// </summary>
public class ObjectCloner : MonoBehaviour
{

    public TextAsset textAsset;
    public GameObject objectToClone; // O objeto que será clonado
    public float cloneInterval = 2f; // Intervalo de tempo entre clones (em segundos)
    public Vector2 spawnLimit = new Vector2(-5f, 5f); // Limite de posição para instanciar clones

    public ListaPerguntas Perguntas;
    public List<GameObject> CaixaDePerguntas = new();

    #region Painel PerguntaRestpota
    public Transform PainelPerguntaResposta;
    #endregion

    [Space(20)]
    public JogoController Controller;
    private void Start()
    {
        // Inicia a rotina para clonar objetos em intervalos
        CriarListaDePerguntas();
        StartCoroutine(CloneObjects());
    }

    private void CriarListaDePerguntas()
    {
        Perguntas = JsonUtility.FromJson<ListaPerguntas>(textAsset.text);
    }

    private IEnumerator CloneObjects()
    {
        while (Perguntas.Perguntas.Count() > 0)
        {
            // Instancia um clone do objeto
            GameObject clone = Instantiate(objectToClone, GetRandomSpawnPosition(), Quaternion.identity);
            // Define o objeto clonado como filho do objeto pai
            clone.transform.SetParent(transform);

            //randomiza uma pergunta 
            var perguntaRando = Random.Range(0, Perguntas.Perguntas.Count());
            var perguntaSelecionada = Perguntas.Perguntas[perguntaRando];
            clone.GetComponent<PerguntaDroper>().Pergunta = perguntaSelecionada;
            //ativa o elemento
            clone.SetActive(true);
            clone.transform.localScale = Vector3.one;

            CaixaDePerguntas.Add(clone);
            // Aguarda o próximo intervalo
            Perguntas.Perguntas.Remove(perguntaSelecionada);
            yield return new WaitForSeconds(cloneInterval);
        }
    }

    async void Update()
    {
        var caixasRestantes = CaixaDePerguntas.Where(x => x != null);
        if (Perguntas.Perguntas.Count() == 0 && caixasRestantes.Count() == 0)
        {
            Debug.Log("Finalizou");
            // yield return new WaitForSeconds(5);
            Debug.Log("Finalizar jogo em 5 Sec");

            Controller.PanelFinalizar.SetActive(true);
            await Controller.UserController.SalvarArquivoHistorico();
        }
    }



    private Vector3 GetRandomSpawnPosition()
    {
        // Gera uma posição aleatória dentro do limite definido
        float x = Random.Range(50, spawnLimit.x);
        //float y = Random.Range(spawnLimit.x, spawnLimit.y);
        return new Vector3(x, spawnLimit.y, 0f);
    }

    #region Mostrar UI para Responder
    /// <summary>
    /// MostrarPainelPerguntaResposta (ativado por UI)
    /// </summary>
    /// <param name="pergunta"></param>
    public void MostrarPainelPerguntaResposta(PerguntaDroper pergunta)
    {
        //resgata a pergunta contida na caixa e transmite para o panel de pergunta resposta
        PainelPerguntaResposta.GetComponent<PerguntaResposta>().Pergunta = pergunta.Pergunta;
        if (PainelPerguntaResposta.gameObject.activeSelf != true)
        {
            PainelPerguntaResposta.gameObject.SetActive(true);
        }

        PainelPerguntaResposta.GetComponent<PerguntaResposta>().CriarPerguntaAlternativas();
    }
    #endregion
}