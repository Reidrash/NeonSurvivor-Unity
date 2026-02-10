using UnityEngine;

public class ControladorBala : MonoBehaviour
{
    public float speed = 20f;
    public float lifeTime = 2f; // Segundos antes de desaparecer

    void Start()
    {
        // Al nacer, programamos su muerte en 2 segundos
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        // Moverse hacia adelante (Z positivo) en su propio espacio local
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
