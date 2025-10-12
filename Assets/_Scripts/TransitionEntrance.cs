//using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class TransitionEntrance : MonoBehaviour
{
  public string sceneLoad;

  void OnTriggerEnter2D(Collider2D collision)
  {
    if (collision.gameObject.CompareTag("Player"))
    {
      SceneManager.LoadScene(sceneLoad);
    }
  }
}
