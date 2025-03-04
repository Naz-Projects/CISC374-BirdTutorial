using UnityEngine;

public class CloudMovement : MonoBehaviour
{
    public float moveSpeed = 2f; // Speed at which the cloud moves

    void Update()
    {
        // Move the cloud to the left
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;
    }
}