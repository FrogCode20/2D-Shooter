using UnityEngine;

public class EnemyType1Movement : MonoBehaviour
{
    public float speed = 2.0f;

    void Update()
    {
        // Move the enemy downwards
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }
}
