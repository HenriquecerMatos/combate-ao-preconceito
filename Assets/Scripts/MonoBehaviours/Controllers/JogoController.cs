using TMPro;

public class JogoController : BaseController
{
    public TMP_Text Pontuacao; 
    void Start()
    {
        BuscarSetarUsuario();
    }

    private void Update()
    {
        Pontuacao.text = UserController.Pontuacao.ToString();        
    }

}
