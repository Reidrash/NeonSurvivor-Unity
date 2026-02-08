using UnityEngine;

public class MovimientoCamara : MonoBehaviour
{
    public Transform target; // A quién vamos a seguir (El Player)
    public float smoothSpeed = 0.125f; // Qué tan suave es el movimiento (0 a 1)
    public Vector3 offset; // La distancia entre la cámara y el jugador

    void LateUpdate() // LateUpdate se ejecuta justo DESPUÉS de que el jugador se haya movido
    {
        // Calculamos la posición deseada (Posición del jugador + la distancia original)
        Vector3 desiredPosition = target.position + offset;

        // Movemos la cámara suavemente hacia esa posición (Interpolación lineal o Lerp)
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Aplicamos el movimiento
        transform.position = smoothedPosition;
    }
}