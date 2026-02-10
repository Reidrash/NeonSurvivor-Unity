using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 3.0f;
    private Transform playerTarget;

    void Start()
    {
        // Al nacer, el enemigo busca automáticamente al objeto con el Tag "Jugador"
        GameObject playerObj = GameObject.FindGameObjectWithTag("Jugador");

        // Verificación de seguridad (por si olvidaste poner el Tag al jugador)
        if (playerObj != null)
        {
            playerTarget = playerObj.transform;
        }
    }

    void Update()
    {
        // Si encontramos al jugador, nos movemos hacia él
        if (playerTarget != null)
        {
            // MoveTowards es perfecto para esto: Mueve de A a B a una velocidad constante
            transform.position = Vector3.MoveTowards(transform.position, playerTarget.position, speed * Time.deltaTime);

            // Opcional: Que el enemigo mire hacia el jugador
            transform.LookAt(playerTarget);
        }
    }

    // Esta función se activa cuando algo "entra" en el Trigger del enemigo
    void OnTriggerEnter(Collider other)
    {
        // ¿Lo que me tocó tiene la etiqueta "Bullet"?
        if (other.CompareTag("Bala"))
        {
            // 1. Destruir la bala (other.gameObject)
            Destroy(other.gameObject);

            // 2. Destruirme a mí mismo (gameObject)
            Destroy(gameObject);

            // ¡Aquí podrías sumar puntos o poner una explosión!
            Debug.Log("¡Enemigo eliminado!");
        }
    }
}