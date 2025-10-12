using UnityEngine;

public class killPlayer : MonoBehaviour
{
    public Transform targetObject; // Assign your target object in the Inspector
    public float rotationSpeed = 5f; // For smooth rotation
    private float delay = 5f;
    private float timer;

    private void Start()
    {
        targetObject = playerMove.Instance.transform;
        timer = delay;
    }

    void Update()
    {
        if (targetObject != null)
        {
            // Calculate the direction to the target
            Vector3 direction = (targetObject.position - transform.position).normalized;

            // Calculate the desired rotation
            Quaternion targetRotation = Quaternion.LookRotation(direction);

            // Smoothly rotate towards the target
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            // Or for instant rotation:
            // transform.rotation = targetRotation;
        }
        timer -= Time.deltaTime;

        if (timer <= 0f && Input.anyKey)
        {
            gameObject.SetActive(false);
            timer = delay;
        }
    }
}
