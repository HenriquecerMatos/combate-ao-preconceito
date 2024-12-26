using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
public class ImageMovement : MonoBehaviour
{
    ///// <summary>
    ///// Velocidade de movimento da imagem
    ///// </summary>
    //public float speed = 15.0f; 
    /// <summary>
    /// Tamanho da imagem
    /// </summary>
    public Vector2 imageSize = new Vector2(120f, 50f);
    public RectTransform ImageTransform;
    /// <summary>
    /// Referencia ao componente de texto
    /// </summary>
    private TextMeshProUGUI randomText;

    public int AlturaAPercorrer = 0;




    public float minSpeed = 1f;
    public float maxSpeed = 5f;
    private Vector2 velocity;

    private Rigidbody2D rb;

    #region vida do box
    //[Multiline()]
    [Space(10)]
    public int Vida = 10;
    public int VidaReferencia = 10;
    public Image VidaUi;

    private AudioSource AudioSource;
    public AudioClip SonFinalVida;
    private void InicializarVida()
    {
        if (VidaUi != null)
        {
            var pergunta = GetComponent<PerguntaDroper>().Pergunta;
            Vida = pergunta.ValorMax;
            VidaReferencia = pergunta.ValorMax;
        }
        else
        {
            Debug.Log("pergunta sem quantidade de vida");
        }
    }

    private void ReduzirVida()
    {
        if (rb != null && VidaUi != null)
        {
            Vida--;


            var valorPorcentagem = ((float)Vida / (float)VidaReferencia);

            VidaUi.fillAmount = valorPorcentagem;

            if (Vida <= 0)
            {
                StartCoroutine(DestroiObj());
               
            }

        }
    }

    private IEnumerator DestroiObj()
    {
        AudioSource.clip = SonFinalVida;
        AudioSource.Play();
        yield return new WaitForSeconds(SonFinalVida.length);
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        ReduzirVida();
        ReproduzirSom();
    }

    public void ReproduzirSom()
    {
        if (AudioSource != null && AudioSource.clip != null)
        {
            // Reproduz o som
            AudioSource.Play();
        }
    }
    #endregion

    private void Start()
    {
        // Obtém a o AudioSource
        AudioSource = GetComponent<AudioSource>();

        // Obtém a referência ao componente de texto como um filho do GameObject
        randomText = GetComponentInChildren<TextMeshProUGUI>();

        // Inicializa o texto com um número aleatório
        UpdateRandomText();




        //var pai =transform.GetComponentInParent<RectTransform>();
        AlturaAPercorrer = Screen.height * -1;


        rb = GetComponent<Rigidbody2D>();
        float speed = Random.Range(minSpeed, maxSpeed);
        float angle = Random.Range(0, 360) * Mathf.Deg2Rad;
        velocity = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * speed;
        rb.linearVelocity = velocity;


        var pergunta = GetComponent<PerguntaDroper>().Pergunta;

        //RandomizeImageColor();


        ObterCorPorRaridade(pergunta.ValorMax);
        InicializarVida();

    }

    void FixedUpdate()
    {
        // Limitar a velocidade do objeto
        if (rb.linearVelocity.magnitude > maxSpeed)
        {
            rb.linearVelocity = rb.linearVelocity.normalized * maxSpeed;
        }
    }

    private void Update()
    {
    }

    private void UpdateRandomText()
    {
        var Pergunta = GetComponent<PerguntaDroper>();
        randomText.text = Pergunta.Pergunta.ValorMax.ToString("F2"); // Exibe o n�mero no texto
    }

    private void RandomizeImageColor()
    {
        // Gera valores aleat�rios para os componentes R, G e B da cor
        float r = Random.Range(0.2f, 1f);
        float g = Random.Range(0.2f, 1f);
        float b = Random.Range(0.2f, 1f);

        // Cria uma nova cor com os valores aleat�rios
        Color randomColor = new Color(r, g, b);

        // Aplica a cor � imagem
        ImageTransform.GetComponent<Image>().color = randomColor;
    }

    public void ObterCorPorRaridade(int valorPassado)
    {
        // Dicionário com as cores de raridade
        var raridadeCores = new Dictionary<int, string>
    {
        { 6, "#808080" },   // Comum (Cinza)
        { 12, "#FFFFFF" },  // Padrão (Branco)
        { 18, "#1EFF00" },  // Incomum (Verde)
        { 24, "#0070DD" },  // Raro (Azul)
        { 30, "#A335EE" },  // Épico (Roxo)
        { 36, "#FF8000" },  // Lendário (Laranja)
        { 42, "#E6CC80" },  // Mítico (Dourado)
        { 50, "#FF0000" }  // Divino (Vermelho)
    };

        // Validar o valor passado para estar entre 0 e 100
        if (valorPassado < 0) valorPassado = 0;
        if (valorPassado > 100) valorPassado = 100;

        // Encontrar o maior valor no dicionário menor ou igual ao valor passado
        int chaveMaisProxima = raridadeCores.Keys
            .Where(chave => chave <= valorPassado)
            .Max();

        // Retornar a cor correspondente

        // return ;

        ImageTransform.GetComponent<Image>().color = HexToColor(raridadeCores[chaveMaisProxima]);
    }



    Color HexToColor(string hex)
    {
        Color color;
        if (UnityEngine.ColorUtility.TryParseHtmlString(hex, out color))
        {
            return color;
        }
        else
        {
            return Color.white;  // Retorna branco caso o hex seja inválido
        }
    }
    private void OnBecameInvisible()
    {
        // Quando o objeto n�o est� mais vis�vel na c�mera, remova-o da cena
        Destroy(gameObject);
    }
}
