using UnityEngine;

public class BaseController : MonoBehaviour
{
    public UserController UserController;
    protected void BuscarSetarUsuario()
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
}
