using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class Module : MonoBehaviour
{

    private bool hasQuest = false;
    public GameObject exlamationMark;// quest marker object
    private bool clickable = false;

    public GameObject HighLighter;//highlighter obj
    private Light2D HighlighterLight;// light compontent of highlighter

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        HighlighterLight = HighLighter.GetComponent<Light2D>();
        HighlighterLight.intensity = 0f;
        exlamationMark.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (clickable)
            {
                if (hasQuest)
                {
                    //get the news
                }                
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
