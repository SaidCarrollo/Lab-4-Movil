using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    [Header("Enemy Settings")]
    public GameObject enemyPrefab;
    public float enemySpawnInterval = 2f;
    public float enemySpawnHeight = 5f;
    public int initialEnemyPoolSize = 10;

    [Header("Obstacle Settings")]
    public GameObject obstaclePrefab;
    public float obstacleSpawnInterval = 3f;
    public float obstacleSpawnHeight = 4f;
    public int initialObstaclePoolSize = 8;

    [Header("Spawn Area")]
    public float spawnXPosition = 10f;
    public float minSpawnY = -5f;
    public float maxSpawnY = 5f;

    private void Start()
    {
        // Precargar pools
        StaticObjectPool.Preload(enemyPrefab, initialEnemyPoolSize);
        StaticObjectPool.Preload(obstaclePrefab, initialObstaclePoolSize);

        // Iniciar corrutinas de spawn
        StartCoroutine(SpawnEnemies());
        StartCoroutine(SpawnObstacles());
    }

    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            SpawnObject(enemyPrefab, enemySpawnHeight);
            yield return new WaitForSeconds(enemySpawnInterval);
        }
    }

    private IEnumerator SpawnObstacles()
    {
        while (true)
        {
            SpawnObject(obstaclePrefab, obstacleSpawnHeight);
            yield return new WaitForSeconds(obstacleSpawnInterval);
        }
    }

    private void SpawnObject(GameObject prefab, float heightRange)
    {
        float randomY = Random.Range(-heightRange, heightRange);
        Vector3 spawnPosition = new Vector3(spawnXPosition, randomY, 0f);

        GameObject obj = StaticObjectPool.Get(prefab);
        obj.transform.position = spawnPosition;
        obj.transform.rotation = Quaternion.identity;
        obj.SetActive(true);
    }

    // Método para ajustar la dificultad según progreso del juego
    public void AdjustDifficulty(float gameTime)
    {
        // Reducir intervalos de spawn con el tiempo
        enemySpawnInterval = Mathf.Max(0.5f, 2f - gameTime * 0.01f);
        obstacleSpawnInterval = Mathf.Max(1f, 3f - gameTime * 0.015f);
    }
}