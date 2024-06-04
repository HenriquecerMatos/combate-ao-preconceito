using Assets.Scripts.Extencions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class PainelSerieSelect : MonoBehaviour
{
    [SerializeField]
    public List<string> Series = new();

    public List<Toggle> SerieElemento = new();
    public UserController UserController;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SerieElemento = (GetComponentsInChildren<Toggle>(true)).ToList() ?? new List<Toggle>();
        BuscarSetarUsuario();
        AtualizarTextoElementos();
    }

    private void BuscarSetarUsuario()
    {
        if (UserController is null)
        {
            UserController[] userControllers = FindObjectsOfType<UserController>();

            if (userControllers.Length > 0)
            {
                UserController = userControllers[0];
                UserController.Serie = SeriesEnum.Serie6;
            }
            else
            {
                // Nenhum UserController encontrado na cena
                Debug.LogWarning("Nenhum UserController encontrado na cena.");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void AtualizarTextoElementos()
    {
        if (SerieElemento.Count > 0)
        {
            SerieElemento.ForEach(e =>
            {
                var textElemento = e.GetComponentInChildren<Text>();
                var index = SerieElemento.IndexOf(e);
                textElemento.text = Series[index];
                e.group = transform.GetComponent<ToggleGroup>();
            });
        }
    }

    public void AtualizarSerieDoUsuario()
    {
        Toggle elemento = SerieElemento.FirstOrDefault(x => x.isOn);
        var index = SerieElemento.IndexOf(elemento);
        UserController.Serie = (SeriesEnum)index;
        //Debug.Log(UserController.Serie.ToString());

    }


}
