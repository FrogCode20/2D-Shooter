using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player; // Reference to the player GameObject
    public float playerSpeed = 5.0f;

    public GameObject enemyType1; // Reference to the first enemy prefab
    public GameObject enemyType2; // Reference to the second enemy prefab

    public float enemyType1SpawnInterval = 3.0f; // Interval for spawning the first enemy type
    public float enemyType2SpawnInterval = 5.0f; // Interval for spawning the second enemy type

    private float screenWidth;
    private float screenHeight;
    private float nextSpawnTimeEnemy1;
    private float nextSpawnTimeEnemy2;

    void Start()
    {
        // Get the screen dimensions in world units
        screenHeight = Camera.main.orthographicSize * 2.0f;
        screenWidth = screenHeight * Camera.main.aspect;

        // Initialize spawn times
        nextSpawnTimeEnemy1 = Time.time + enemyType1SpawnInterval;
        nextSpawnTimeEnemy2 = Time.time + enemyType2SpawnInterval;

        // Set the player's initial position to the center of the bottom half of the screen
        if (player != null)
        {
            player.transform.position = new Vector3(0, -screenHeight / 4, 0);
        }
        else
        {
            Debug.LogError("Player GameObject is not assigned in the GameManager.");
        }
    }

    void Update()
    {
        HandlePlayerMovement();
        HandleEnemySpawning();
    }

    void HandlePlayerMovement()
    {
        if (player == null) return;

        // Get player input
        float moveHorizontal = Input.GetAxis("Horizontal");

        // Calculate new position
        Vector3 newPosition = player.transform.position + new Vector3(moveHorizontal, 0, 0) * playerSpeed * Time.deltaTime;

        // Constrain movement to the bottom half of the screen
        newPosition.y = Mathf.Clamp(newPosition.y, -screenHeight / 2, 0);

        // Wrap around the screen horizontally
        if (newPosition.x > screenWidth / 2)
        {
            newPosition.x = -screenWidth / 2;
        }
        else if (newPosition.x < -screenWidth / 2)
        {
            newPosition.x = screenWidth / 2;
        }

        // Apply the new position
        player.transform.position = newPosition;
    }

    void HandleEnemySpawning()
    {
        // Spawn the first enemy type at intervals
        if (Time.time >= nextSpawnTimeEnemy1)
        {
            SpawnEnemy(enemyType1);
            nextSpawnTimeEnemy1 = Time.time + enemyType1SpawnInterval;
        }

        // Spawn the second enemy type at intervals
        if (Time.time >= nextSpawnTimeEnemy2)
        {
            SpawnEnemy(enemyType2);
            nextSpawnTimeEnemy2 = Time.time + enemyType2SpawnInterval;
        }
    }

    void SpawnEnemy(GameObject enemyPrefab)
    {
        if (enemyPrefab == null) return;

        // Random position at the top of the screen
        float spawnX = Random.Range(-screenWidth / 2, screenWidth / 2);
        Vector3 spawnPosition = new Vector3(spawnX, screenHeight / 2, 0);

        // Instantiate the enemy
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}
