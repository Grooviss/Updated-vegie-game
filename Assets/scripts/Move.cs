using UnityEngine;

public class UpDownMovement : MonoBehaviour
{
    public float amplitude = 0.5f;  // Set the amplitude of the movement
    public float frequency = 1f;    // Set the frequency of the movement

    private Vector2 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        // Calculate the new Y position based on time
        float newY = startPos.y + amplitude * Mathf.Sin(frequency * Time.time);

        // Update the object's position
        transform.position = new Vector2(transform.position.x, newY);
    }
}