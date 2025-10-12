using UnityEngine;

public class PlayerLoader : MonoBehaviour
{
    public GameObject player;
    private Vector2 playerPosition = new Vector2(-14, -7);
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        player.transform.position = playerPosition;
    }

    // Update is called once per frame
    void Update()
    {
        playerPosition = player.transform.position;
    }
}
