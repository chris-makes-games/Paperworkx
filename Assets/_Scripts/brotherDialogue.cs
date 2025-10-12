using UnityEngine;

public class brotherDialogue : MonoBehaviour
{
    private Vector3 originalLocalScale;

    //delay before closing so it doesn't close on opening click
    private float delay = 2f;
    private float timer;

    // Hides poster if player does anything
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0f && Input.anyKey)
        {
            gameObject.SetActive(false);
            timer = delay;
        }
    }
    void Start()
    {
        timer = delay;
        originalLocalScale = transform.localScale;
    }

    void LateUpdate()
    {
        // Get the parent's local scale
        Vector3 parentLocalScale = transform.parent.localScale;

        // Check if the parent is flipped horizontally
        if (parentLocalScale.x < 0)
        {
            // If the child is not already flipped, flip it back
            if (transform.localScale.x > 0)
            {
                Vector3 compensatedScale = originalLocalScale;
                compensatedScale.x *= -1f;
                transform.localScale = compensatedScale;
            }
        }
        else // Parent is not flipped
        {
            // If the child is flipped, flip it back to its original state
            if (transform.localScale.x < 0)
            {
                transform.localScale = originalLocalScale;
            }
        }
    }

}
