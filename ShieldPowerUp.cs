using UnityEngine;

public class ShieldPowerUp : MonoBehaviour
{
    public float shieldDuration = 5f; // Duration of the shield effect

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the player picks up the shield
        if (other.CompareTag("Player"))
        {
            PlayerScore playerScore = other.GetComponent<PlayerScore>();
            if (playerScore != null)
            {
                playerScore.ActivateShield(shieldDuration); // Activate shield on player
                Destroy(gameObject); // Destroy the shield power-up object
            }
        }
    }
}
