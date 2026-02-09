using UnityEngine;

public class MoveAlongZ : MonoBehaviour
{
    [Header("Movement Settings")]
    [Tooltip("Speed of movement along the Z-axis (units per second)")]
    public float speed = 2f;

    [Header("Reset Settings")]
    [Tooltip("Distance to travel before resetting to start position")]
    public float resetDistance = 10f;

    private Vector3 startPosition;
    private float distanceTraveled = 0f;

    void Start()
    {
        // Store the starting position
        startPosition = transform.position;
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
            // Reset to start position
            transform.position = startPosition;
            distanceTraveled = 0f;
        }
    }
}