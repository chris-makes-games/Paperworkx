using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionEntrance : MonoBehaviour
{
    public string sceneLoad;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(sceneLoad);
        }
    }
}
