using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;  // ¿Qué vamos a generar?
    public float spawnInterval = 2.0f; // ¿Cada cuántos segundos?

    // Límites del área donde pueden aparecer (ajusta según el tamaño de tu suelo)
    public float xRange = 10.0f;
    public float zRange = 10.0f;

    private float timer = 0.0f;

    void Update()
    {
        // Sumamos el tiempo que pasa en cada frame
        timer += Time.deltaTime;

        // Si el contador supera el intervalo...
        if (timer >= spawnInterval)
        {
            SpawnEnemy(); // ¡Llamamos a la función de crear!
            timer = 0f;   // Reseteamos el contador
        }
    }

    void SpawnEnemy()
    {
        // Generar una posición aleatoria dentro de los rangos X y Z
        // Random.Range(min, max) nos da un número al azar entre esos dos valores
        float randomX = Random.Range(-xRange, xRange);
        float randomZ = Random.Range(-zRange, zRange);

        // Creamos el vector de posición (Y = 1 para que no aparezcan enterrados)
        Vector3 spawnPos = new Vector3(randomX, 1.0f, randomZ);

        // Instanciamos el enemigo (Prefab, Posición, Rotación por defecto)
        Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
    }
}