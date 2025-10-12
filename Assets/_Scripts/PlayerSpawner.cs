using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public Transform playerTransform;

    void Start()
    {

        if (QuizManager.useCustomSpawnPosition)
        {
            playerTransform.position = QuizManager.nextSpawnPosition;

            QuizManager.useCustomSpawnPosition = false;
        }
    }
}