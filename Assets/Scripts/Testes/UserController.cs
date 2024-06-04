using Assets.Scripts.Extencions;
using Entities;
using UnityEngine;

public class UserController : MonoBehaviour
{
    [SerializeField]
    public SeriesEnum Serie  = SeriesEnum.Serie6;

    [SerializeField]
    public Caracteristicas Caracteristicas { get; set; } = new Caracteristicas();

    public void SetSerie(SeriesEnum serie)
    {
        Serie=serie;
        Debug.Log(serie.ToString());
    }

    public void SetDificuldade(DificuldadeEnum dificuldade)
    {
        Debug.Log(dificuldade.ValorDescription()+"-"+ dificuldade.ValorPeso());
    }
}
