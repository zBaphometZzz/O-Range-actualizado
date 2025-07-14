using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    [SerializeField] private float scrollSpeed = 2f; // Velocidad de desplazamiento
    [SerializeField] private float stopPositionY = -10f; // Posici�n Y donde se detendr� el desplazamiento
    [SerializeField] private float startPositionY = 10f; // Posici�n inicial en Y cuando se reinicia el desplazamiento

    private bool isScrolling = true; // Controla si el fondo se est� moviendo o no

    private void Update()
    {
        if (isScrolling)
        {
            // Mueve el fondo hacia abajo en la posici�n X fija
            transform.Translate(Vector2.down * scrollSpeed * Time.deltaTime);

            // Si el fondo alcanza o pasa la posici�n de detenci�n, detener el movimiento
            if (transform.position.y <= stopPositionY)
            {
                isScrolling = false;
                Debug.Log("El fondo se detuvo en la posici�n: " + transform.position.y);
            }
        }
    }

    /// <summary>
    /// Reinicia la posici�n del fondo para que vuelva a desplazarse desde el inicio.
    /// </summary>
    public void ResetPosition()
    {
        transform.position = new Vector2(transform.position.x, startPositionY);
        Debug.Log("Fondo reiniciado a la posici�n: " + transform.position);
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
        Debug.Log("El desplazamiento del fondo se reanud�.");
    }

    /// <summary>
    /// Ajusta la velocidad del desplazamiento din�micamente.
    /// </summary>
    /// <param name="newSpeed">Nueva velocidad.</param>
    public void SetScrollSpeed(float newSpeed)
    {
        scrollSpeed = newSpeed;
        Debug.Log("Velocidad del fondo ajustada a: " + scrollSpeed);
    }
}
