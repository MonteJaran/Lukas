using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Prefab of the enemy to spawn
    public Transform target; // Target around which enemies will be spawned
    public float minSpawnDistance = 5f; // Minimum distance from the target to spawn enemies
    public float maxSpawnDistance = 8f; // Maximum distance from the target to spawn enemies

    public int numberOfEnemies = 3; // Number of enemies to spawn

    private EnemyController enemyController;
    private void Start()
    {
        enemyController = GetComponent<EnemyController>();
        InvokeRepeating("SpawnEnemies", 1f, 4f);
        InvokeRepeating("MakeNoGreater", 30f, 30f);
    }

    private void SpawnEnemies()
    {
        for (int i = 0; i < numberOfEnemies; i++)
        {
            // Calculate random spawn distance within the specified range
            float spawnDistance = Random.Range(minSpawnDistance, maxSpawnDistance);

            // Calculate random angle in radians
            float randomAngle = Random.Range(0f, 2f * Mathf.PI);

            // Calculate spawn position based on distance and angle
            Vector3 spawnOffset = new Vector3(Mathf.Cos(randomAngle), 0f, Mathf.Sin(randomAngle)) * spawnDistance;
            Vector3 spawnPosition = target.position + spawnOffset;

            // Instantiate the enemy prefab at the spawn position
            GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            enemyController.AddNewEnemy(enemy);
        }
    }

    private void MakeNoGreater()
    {
        numberOfEnemies++;
    }
}
