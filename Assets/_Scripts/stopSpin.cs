using UnityEngine;

public class stopSpin : MonoBehaviour
{
    public Transform playerTransform; // Assign your player GameObject here in the Inspector
    public float followSpeed = 1f; // Adjust this for parallax effect

    void LateUpdate()
    {
        if (playerTransform != null)
        {
            // Follow the player's X and Y position, keeping the background's Z
            transform.position = new Vector3(
                playerTransform.position.x,
                playerTransform.position.y + 8,
                transform.position.z
            );
        }
    }
}
