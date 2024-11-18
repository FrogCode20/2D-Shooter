using UnityEngine;

public class Coin : MonoBehaviour
{
    public float lifetime = 5f;  // Time in seconds before the coin disappears
    public int scoreValue = 1;   // Score earned when the coin is collected

    private void Start()
    {
        // Destroy the coin after a certain amount of time if not collected
        Destroy(gameObject, lifetime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))  // Make sure the player has the "Player" tag
        {
            PlayerScore playerScore = other.GetComponent<PlayerScore>();
            if (playerScore != null)
            {
                playerScore.IncreaseScore(scoreValue);  // Call to increase score
            }
            Destroy(gameObject);  // Destroy the coin after collection
        }
    }
}
