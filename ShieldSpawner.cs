using UnityEngine;

public class ShieldSpawner : MonoBehaviour
{
    public GameObject shieldPrefab;  // Reference to the shield power-up prefab
    public float spawnInterval = 20f;  // Time interval between shield spawns
    private Vector2 spawnAreaMin;  // Min X and Y for shield spawn
    private Vector2 spawnAreaMax;  // Max X and Y for shield spawn

    private void Start()
    {
        // Calculate camera bounds
        float cameraHeight = Camera.main.orthographicSize * 2;
        float cameraWidth = cameraHeight * Camera.main.aspect;

        // Set spawn area (e.g., bottom half of the screen)
        spawnAreaMin = new Vector2(-cameraWidth / 2, -cameraHeight / 2);
        spawnAreaMax = new Vector2(cameraWidth / 2, 0);  // 0 is the middle of the screen vertically

        // Start spawning shields at intervals
        InvokeRepeating("SpawnShield", 10f, spawnInterval);
    }

    void SpawnShield()
    {
        float randomX = Random.Range(spawnAreaMin.x, spawnAreaMax.x);
        float randomY = Random.Range(spawnAreaMin.y, spawnAreaMax.y);
        Vector2 spawnPosition = new Vector2(randomX, randomY);

        Instantiate(shieldPrefab, spawnPosition, Quaternion.identity);
    }
}
