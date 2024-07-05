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
            }
            else//somente para debugar, para não precisar fazer todo o fluxo login>jogo
            {
                // Crie um componente com o script UserController
                GameObject userControllerObject = new GameObject("UserController");
                UserController = userControllerObject.AddComponent<UserController>();
            }
        }
    }
}
