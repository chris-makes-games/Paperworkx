using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class PosterModule : MonoBehaviour
{
    
    private bool clickable = false;//clickable if player is close enough

    public GameObject HighLighter;//highlighter obj
    private Light2D HighlighterLight;// light compontent of highlighter

    public GameObject bigPoster;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        HighlighterLight = HighLighter.GetComponent<Light2D>();
        HighlighterLight.intensity = 0f;
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (clickable)
            {
                bigPoster.SetActive(true);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        HighlighterLight.intensity = 100f;
        clickable = true;
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        HighlighterLight.intensity = 0f;
        clickable = false;
    }
}
