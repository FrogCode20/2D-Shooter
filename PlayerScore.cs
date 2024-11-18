using TMPro;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    public int score = 0;
    public TextMeshProUGUI scoreText;
    public bool isShieldActive = false;
    private float shieldEndTime;
    public GameObject shieldPrefab; // Reference to the shield prefab

    private GameObject currentShieldVisual; // The current shield instance

    public AudioClip shieldPowerUpSound; // Reference to the shield power-up sound
    public AudioClip shieldPowerDownSound; // Reference to the shield power-down sound
    private AudioSource audioSource; // Reference to the AudioSource component

    private void Start()
    {
        audioSource = GetComponent<AudioSource>(); // Get the AudioSource attached to the player
        UpdateScoreText();
    }

    private void Update()
    {
        // Check if the shield should be deactivated
        if (isShieldActive && Time.time >= shieldEndTime)
        {
            DeactivateShield();
        }
    }

    public void IncreaseScore(int value)
    {
        score += value;
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }

    public void ActivateShield(float duration)
    {
        if (shieldPrefab == null)
        {
            Debug.LogError("Shield Prefab is not assigned!");
            return;
        }

        // If the shield is already active, don't activate it again
        if (isShieldActive)
            return;

        isShieldActive = true;
        shieldEndTime = Time.time + duration;

        // Instantiate the shield and make it a child of the player
        currentShieldVisual = Instantiate(shieldPrefab, transform.position, Quaternion.identity);
        currentShieldVisual.transform.SetParent(transform); // Set it as a child of the player
        currentShieldVisual.transform.localPosition = Vector3.zero; // Ensure it's at the player's position

        currentShieldVisual.SetActive(true); // Show the shield visual

        // Play the shield power-up sound
        if (shieldPowerUpSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(shieldPowerUpSound);
        }

        Debug.Log("Shield activated! Duration: " + duration + " seconds.");
    }

    public void DeactivateShield()
    {
        if (currentShieldVisual != null)
        {
            isShieldActive = false;
            currentShieldVisual.SetActive(false); // Hide the shield visual
            Destroy(currentShieldVisual); // Destroy the shield after deactivating

            // Play the shield power-down sound
            if (shieldPowerDownSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(shieldPowerDownSound);
            }

            Debug.Log("Shield deactivated!");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin"))
        {
            IncreaseScore(1);
            Destroy(other.gameObject);
        }
    }
}
