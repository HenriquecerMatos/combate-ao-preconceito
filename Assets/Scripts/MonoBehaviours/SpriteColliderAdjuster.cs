using UnityEngine;

public class SpriteColliderAdjuster : MonoBehaviour
{
    void Start()
    {
        // Obtém o RectTransform e o BoxCollider2D
        RectTransform rectTransform = GetComponent<RectTransform>();
        BoxCollider2D boxCollider = GetComponent<BoxCollider2D>();

        // Ajusta o BoxCollider2D para o tamanho do RectTransform
        if (rectTransform != null && boxCollider != null)
        {
            // Define o tamanho do BoxCollider para o tamanho do RectTransform
            boxCollider.size = rectTransform.rect.size;
            boxCollider.offset = rectTransform.rect.center - (Vector2)rectTransform.position;
        }

        // Se o Rigidbody2D também precisar ser ajustado, você pode fazer isso aqui
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            // Exemplo de ajuste de massa com base na área do RectTransform (opcional)
            float area = rectTransform.rect.width * rectTransform.rect.height;
            rb.mass = area * 0.1f; // Ajuste a constante conforme necessário
        }
    }
}
