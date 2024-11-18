using UnityEngine;
using TMPro;

public class PlayerLives : MonoBehaviour
{
    public int lives = 3; // Initial number of lives
    public TMP_Text livesText; // Reference to the TextMeshPro component

    void Start()
    {
        // Initialize the lives text
        UpdateLivesText();
    }

    // Method to decrease lives
    public void LoseLife()
    {
        if (lives > 0)
        {
            lives--;
            UpdateLivesText();
        }
    }

    // Method to update the lives text on screen
    void UpdateLivesText()
    {
        livesText.text = "Lives: " + lives;
    }
}
