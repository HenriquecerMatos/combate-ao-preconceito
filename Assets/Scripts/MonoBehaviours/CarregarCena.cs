using UnityEngine;
using UnityEngine.SceneManagement;

public class CarregarCena : MonoBehaviour
{
    public void NomeDaCena(string cena)
    {
        SceneManager.LoadScene(cena);
    }
}
