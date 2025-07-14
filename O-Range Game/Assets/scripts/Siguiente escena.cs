using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Siguienteescena : MonoBehaviour
{
    public string sceneToLoad = "NombreDeLaEscena";  // Nombre de la escena a la que deseas cambiar

    void Update()
    {
        // Detecta si se hace clic izquierdo en el mouse
        if (Input.GetMouseButtonDown(0))
        {
            // Cambia a la escena especificada
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
