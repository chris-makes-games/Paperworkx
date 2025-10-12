using JetBrains.Annotations;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public static Manager Instance { get; private set; }
    public GameObject playerObject;
    private Vector2 playerLocation;
    playerMove playerScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerScript = playerObject.GetComponent<playerMove>();
        DontDestroyOnLoad(gameObject);
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); // Destroy duplicate instances
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setPlayerLocation(Vector2 currentPos)
    {
        playerLocation = currentPos;
    }

    public void movePlayer(Vector2 newPos)
    {
        playerObject.transform.position = newPos;
    }

    public void givePaper()
    {
        playerScript.getPaper();
    }

    public void takePaper()
    {
        playerScript.takePaper();
    }
}
