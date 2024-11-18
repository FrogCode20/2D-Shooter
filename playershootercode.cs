using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    private float screenWidth;
    private float screenHeight;

    void Start()
    {
        // Get the screen dimensions in world units
        screenHeight = Camera.main.orthographicSize * 2.0f;
        screenWidth = screenHeight * Camera.main.aspect;
    }

    void Update()
    {
        // Get player input
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Calculate new position
        Vector3 newPosition = transform.position + new Vector3(moveHorizontal, moveVertical, 0) * speed * Time.deltaTime;

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
        transform.position = newPosition;
    }
}
