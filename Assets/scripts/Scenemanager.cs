using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    public static GameSceneManager instance;

    private void Awake()
    {
        // Singleton para acceder al SceneManager desde cualquier script
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Mant�n el objeto al cambiar de escena
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // M�todo para cargar una escena espec�fica
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(1);
    }

    // M�todo para salir del juego
    public void QuitGame()
    {
        Debug.Log("Saliendo del juego...");
        Application.Quit();
    }
}
