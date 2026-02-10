using UnityEngine;

public partial class ControladorJugador : MonoBehaviour
{
    // Propiedad publica que se puede ver desde el editor de Unity. Con esta controlamos la velocidad del jugador
    public float speed = 10.0f;

    public GameObject bulletPrefab; // El molde de la bala
    public Transform firePoint;     // El lugar desde donde sale

    // Metodo que se ejecuta una vez por fotograma. Es decir, si corremos el juego a 60 FPS, se ejecutará 60 veces
    // en un segundo
    void Update()
    {
        // Obtenemos los ejes de movimiento (Flechas o WASD).
        // "Horizontal" y "Vertical" ya están definidos en Unity. Por lo que puede reconocer tanto 'W' 'A' 'S' 'D'
        // como las Flechas Direccionales del teclado
        // El metodo "GetAxis" devuelve un valor entre -1 y 1. Por lo tanto, podriamos usar un Joystick para un
        // movimiento más lento.
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Creamos un vector de dirección en el espacio para permitir el movimiento
        // Es un objeto tipo Vector3 (3D) que recibe el tipo de movimiento en el siguiente orden:
        // X(moveHorizontal), Y(0.0f), Z(moveVertical)
        // Esto nos permite deslizarnos por el suelo sin volar o interactuar de otra forma.
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        // Movemos el objeto en relación al tiempo (Time.deltaTime) para que sea fluido y consistente en todos los equipos
        // DeltaTime simboliza el tiempo que pasó desde el último frame.
        transform.Translate(movement * speed * Time.deltaTime);

        if (Input.GetButtonDown("Fire1") || Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }
    void Shoot()
    {
        // Crear la bala en la posición y rotación del FirePoint
        Instantiate(bulletPrefab, firePoint.position, transform.rotation);
    }
}