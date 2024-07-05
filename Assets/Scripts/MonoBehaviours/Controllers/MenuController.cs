using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : BaseController
{
    public TMP_Text Titulo;
    #region Body

    [Header("Body")]

    public RectTransform MenuBody;
    public RectTransform HistoricoBody;
    public RectTransform CreditosBody;
    #endregion

    #region Footer

    [Space(20)]
    [Header("Footer")]

    public RectTransform MenuFooter;
    public RectTransform HistoricoFooter;
    public RectTransform CreditosFooter;
    #endregion

    #region Historico

    [Space(20)]
    [Header("Historico")]
    public RectTransform HistoricoPai;
    public RectTransform BaseHistorico;


    #endregion

    public void Start()
    {
        BuscarSetarUsuario();
        UserController.LerArquivosHistorico();
        CriarUiHistorico();
    }

    public void CriarUiHistorico()
    {
        var dadosHistorico = UserController.HistoricoResposta;


        foreach (var item in dadosHistorico)
        {
            // Instancia um clone do objeto
            GameObject clone = Instantiate(BaseHistorico.gameObject);
            // Define o objeto clonado como filho do objeto pai
            clone.transform.SetParent(HistoricoPai);

            var mostrarHistorico = clone.GetComponent<MostrarHistorico>();

            mostrarHistorico.Caracteristicas.text = item.Caracteristicas;
            var pontosTotalSemPeso = item.ValorTotal();
            var valorResultantePorPeso = item.ValorTotalComPeso();
            mostrarHistorico.Pontuacao.text = valorResultantePorPeso + "/"+ pontosTotalSemPeso+ " pontos";

            clone.SetActive(true);
        }
    }

    public void SetTitulo(string titulo)
    {
        Titulo.text = titulo;
    }
    public void CarregarCena()
    {
        SceneManager.LoadScene("ConfiguracaoUser");
    }
}
