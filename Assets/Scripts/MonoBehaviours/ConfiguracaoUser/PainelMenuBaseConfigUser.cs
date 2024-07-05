using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PainelMenuBaseConfigUser : MonoBehaviour
{
    public TMP_Text Label;
    public Button ButtonBase;

    public void SetLabel(string valor)
    {
        Label.text = valor;
    }
}
