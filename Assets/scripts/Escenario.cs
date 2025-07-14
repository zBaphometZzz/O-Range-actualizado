using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    [SerializeField] private float scrollSpeed = 2f; // Velocidad de desplazamiento
    [SerializeField] private float stopPositionY = -10f; // Posición Y donde se detendrá el desplazamiento
    [SerializeField] private float startPositionY = 10f; // Posición inicial en Y cuando se reinicia el desplazamiento

    private bool isScrolling = true; // Controla si el fondo se está moviendo o no

    private void Update()
    {
        if (isScrolling)
        {
            // Mueve el fondo hacia abajo en la posición X fija
            transform.Translate(Vector2.down * scrollSpeed * Time.deltaTime);

            // Si el fondo alcanza o pasa la posición de detención, detener el movimiento
            if (transform.position.y <= stopPositionY)
            {
                isScrolling = false;
                Debug.Log("El fondo se detuvo en la posición: " + transform.position.y);
            }
        }
    }

    /// <summary>
    /// Reinicia la posición del fondo para que vuelva a desplazarse desde el inicio.
    /// </summary>
    public void ResetPosition()
    {
        transform.position = new Vector2(transform.position.x, startPositionY);
        Debug.Log("Fondo reiniciado a la posición: " + transform.position);
    }

    /// <summary>
    /// Detiene el desplazamiento del fondo.
    /// </summary>
    public void StopScrolling()
    {
        isScrolling = false;
        Debug.Log("El desplazamiento del fondo se detuvo manualmente.");
    }

    /// <summary>
    /// Reanuda el desplazamiento del fondo.
    /// </summary>
    public void StartScrolling()
    {
        isScrolling = true;
        Debug.Log("El desplazamiento del fondo se reanudó.");
    }

    /// <summary>
    /// Ajusta la velocidad del desplazamiento dinámicamente.
    /// </summary>
    /// <param name="newSpeed">Nueva velocidad.</param>
    public void SetScrollSpeed(float newSpeed)
    {
        scrollSpeed = newSpeed;
        Debug.Log("Velocidad del fondo ajustada a: " + scrollSpeed);
    }
}
