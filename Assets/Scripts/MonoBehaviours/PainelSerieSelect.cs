using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class PainelSerieSelect : BaseController
{
    [SerializeField]
    public List<string> Series = new();

    public List<Toggle> SerieElemento = new();
    //public UserController UserController; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SerieElemento = (GetComponentsInChildren<Toggle>(true)).ToList() ?? new List<Toggle>();
        BuscarSetarUsuario();
        AtualizarTextoElementos();
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
        var serie = (SeriesEnum)index;
        UserController.SetSerie(serie);
        //Debug.Log(UserController.Serie.ToString());

    }


}
