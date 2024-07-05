using TMPro;
using UnityEngine;

public class JogoController : BaseController
{
    public TMP_Text Pontuacao;
    public TMP_Text PontuacaoResumo;
    public GameObject PanelFinalizar;
    void Start()
    {
        BuscarSetarUsuario();
    }

    private void Update()
    {
        Pontuacao.text = UserController.Pontuacao.ToString("F2");
        PontuacaoResumo.text = Pontuacao.text;
    }

}
