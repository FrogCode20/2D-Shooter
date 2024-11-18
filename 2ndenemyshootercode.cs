using UnityEngine;

public class EnemyType2Movement : MonoBehaviour
{
    public float speed = 3.0f;

    void Update()
    {
        // Move the enemy downwards with a slight horizontal oscillation
        float oscillation = Mathf.Sin(Time.time * speed) * 0.5f;
        transform.Translate(new Vector3(oscillation, -1, 0) * speed * Time.deltaTime);
    }
}
