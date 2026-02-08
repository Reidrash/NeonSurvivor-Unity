using UnityEngine;

public partial class ControladorJugador : MonoBehaviour
{
    public float speed = 10.0f;

    void Update()
    {
        // Obtenemos los ejes de movimiento (Flechas o WASD)
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Creamos un vector de dirección
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        // Movemos el objeto en relación al tiempo (Time.deltaTime) para que sea fluido
        transform.Translate(movement * speed * Time.deltaTime);
    }
}