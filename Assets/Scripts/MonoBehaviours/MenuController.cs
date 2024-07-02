using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public TMP_Text Titulo;
    #region Body

    [Header("Body")]

    public RectTransform MenuBody;
    public RectTransform HistoricoBody;
    public RectTransform CreditosBody;
    #endregion

    #region Footer

    #endregion
    [Space(20)]
    [Header("Footer")]

    public RectTransform MenuFooter;
    public RectTransform HistoricoFooter;
    public RectTransform CreditosFooter;


    public void SetTitulo(string titulo)
    {
        Titulo.text = titulo;
    }
    public void CarregarCena()
    {
        SceneManager.LoadScene("Serie");
    }
}
