using UnityEngine;
using UnityEngine.Rendering.Universal;
using System.Collections;

public class AIModule : MonoBehaviour
{
    public GameObject exlamationMark;// quest marker object
    private bool clickable = false;

    public GameObject HighLighter;//highlighter obj
    private Light2D HighlighterLight;// light compontent of highlighter

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        HighlighterLight = HighLighter.GetComponent<Light2D>();
        HighlighterLight.intensity = 0f;
        exlamationMark.SetActive(true);
        StartCoroutine(DisableAfterDelay());
    }
    IEnumerator DisableAfterDelay()
    {
        yield return new WaitForSeconds(5f);
        playerMove.Instance.bigBrother.SetActive(false);
        playerMove.Instance.welcome.SetActive(false);
        playerMove.Instance.rejected.SetActive(false);
        playerMove.Instance.accepted.SetActive(false);
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
                if (playerMove.Instance.hasPaper)
                {
                    playerMove.Instance.bigBrother.SetActive(true);
                    if(playerMove.Instance.paperPrinting > 12)
                    {
                        playerMove.Instance.accepted.SetActive(true);
                    }
                    else
                    {
                        playerMove.Instance.rejected.SetActive(true);
                    }
                        exlamationMark.SetActive(false);
                }
                else
                {
                    playerMove.Instance.bigBrother.SetActive(true);
                    playerMove.Instance.welcome.SetActive(true);
                    exlamationMark.SetActive(false);

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
