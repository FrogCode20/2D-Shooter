using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab;  // Reference to the coin prefab
    public float spawnInterval = 5f;  // Time interval between coin spawns
    private Vector2 spawnAreaMin;  // Min X and Y for coin spawn
    private Vector2 spawnAreaMax;  // Max X and Y for coin spawn

    private void Start()
    {
        // Calculate camera bounds
        float cameraHeight = Camera.main.orthographicSize * 2;
        float cameraWidth = cameraHeight * Camera.main.aspect;

        // Set spawn area for bottom half of the screen
        spawnAreaMin = new Vector2(-cameraWidth / 2, -cameraHeight / 2);
        spawnAreaMax = new Vector2(cameraWidth / 2, 0); // 0 is the middle of the screen vertically

        // Start spawning coins at intervals
        InvokeRepeating("SpawnCoin", 0f, spawnInterval);
    }

    void SpawnCoin()
    {
        float randomX = Random.Range(spawnAreaMin.x, spawnAreaMax.x);
        float randomY = Random.Range(spawnAreaMin.y, spawnAreaMax.y);
        Vector2 spawnPosition = new Vector2(randomX, randomY);

        Instantiate(coinPrefab, spawnPosition, Quaternion.identity);
    }
}
