using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ImageMovement : MonoBehaviour
{
    /// <summary>
    /// Velocidade de movimento da imagem
    /// </summary>
    public float speed = 15.0f; 
    /// <summary>
    /// Tamanho da imagem
    /// </summary>
    public Vector2 imageSize = new Vector2(120f, 50f); 
    private RectTransform imageTransform;
    /// <summary>
    /// Referência ao componente de texto
    /// </summary>
    private TextMeshProUGUI randomText; 

    public int AlturaAPercorrer = 0;

    private void Start()
    {
        // Obtém a referência ao componente RectTransform da imagem
        imageTransform = GetComponent<RectTransform>();
        imageTransform.sizeDelta = imageSize;
        RandomizeImageColor();

        // Obtém a referência ao componente de texto como um filho do GameObject
        randomText = GetComponentInChildren<TextMeshProUGUI>();

        // Inicializa o texto com um número aleatório
        UpdateRandomText();


        //var pai =transform.GetComponentInParent<RectTransform>();
        AlturaAPercorrer = Screen.height*-1;

    }

    private void Update()
    {
        // Move a imagem para baixo com base na velocidade e no tempo
        float newYPosition = imageTransform.anchoredPosition.y - (speed * Time.deltaTime);
        imageTransform.anchoredPosition = new Vector2(imageTransform.anchoredPosition.x, newYPosition);

        if (imageTransform.anchoredPosition.y <= (AlturaAPercorrer))
        {
            Destroy(gameObject);
        }
       //var altura = Screen.height;
    }

    private void UpdateRandomText()
    {
        var Pergunta = GetComponent<PerguntaDroper>();
        randomText.text = Pergunta.Pergunta.ValorMax.ToString("F2"); // Exibe o número no texto
    }

    private void RandomizeImageColor()
    {
        // Gera valores aleatórios para os componentes R, G e B da cor
        float r = Random.Range(0.2f, 1f);
        float g = Random.Range(0.2f, 1f);
        float b = Random.Range(0.2f, 1f);

        // Cria uma nova cor com os valores aleatórios
        Color randomColor = new Color(r, g, b);

        // Aplica a cor à imagem
        imageTransform.GetComponent<Image>().color = randomColor;
    }

    private void OnBecameInvisible()
    {
        // Quando o objeto não está mais visível na câmera, remova-o da cena
        Destroy(gameObject);
    }
}
