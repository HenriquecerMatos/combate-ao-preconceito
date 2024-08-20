using TMPro;
using UnityEngine;

public class ConfiguracaoUserMostrarController : BaseController
{
    public TMP_Text Caracteristicas;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        BuscarSetarUsuario();
        MostrarConfig();
    }

    void MostrarConfig()
    {
        if (UserController)
        {
            Caracteristicas.text = UserController.Caracteristicas.Descrever();
        }
    }
}
