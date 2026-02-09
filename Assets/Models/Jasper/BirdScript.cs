using UnityEngine;

public class MoveAlongZ : MonoBehaviour
{
    [Header("Movement Settings")]
    [Tooltip("Speed of movement along the Z-axis (units per second)")]
    public float speed = 2f;

    [Header("Reset Settings")]
    [Tooltip("Distance to travel before resetting to start position")]
    public float resetDistance = 10f;

    [Header("Spawn Settings")]
    [Tooltip("Radius for random spawn on X and Y axes")]
    public float spawnRadius = 5f;

    private Vector3 startPosition;
    private float distanceTraveled = 0f;

    void Start()
    {
        // Store the initial position as the center point
        startPosition = transform.position;

        // Spawn at a random position within the radius
        RandomizePosition();
    }

    void RandomizePosition()
    {
        // Generate random offset within a circle on X and Y
        Vector2 randomCircle = Random.insideUnitCircle * spawnRadius;

        // Apply the random offset to X and Y, keep original Z
        transform.position = new Vector3(
            startPosition.x + randomCircle.x,
            startPosition.y + randomCircle.y,
            startPosition.z
        );
    }

    void Update()
    {
        // Calculate movement for this frame
        float movement = speed * Time.deltaTime;

        // Move along the Z-axis
        transform.Translate(Vector3.forward * movement);

        // Track total distance traveled
        distanceTraveled += Mathf.Abs(movement);

        // Check if we've reached the reset distance
        if (distanceTraveled >= resetDistance)
        {
            // Reset to a new random position
            RandomizePosition();
            distanceTraveled = 0f;
        }
    }
}