using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ConfiguracaoUserController : BaseController
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        BuscarSetarUsuario();
    }

    public void AtualizarDificuldade(int index)
    {
        UserController.Dificuldade = (DificuldadeEnum)index;
        //Debug.Log(UserController.Serie.ToString());

    }

    // Update is called once per frame
    void Update()
    {

    }
}
