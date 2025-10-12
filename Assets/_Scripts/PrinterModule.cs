using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class PrinterModule : MonoBehaviour
{
    public Sprite printerPaperReady; //sprite with paper
    public Sprite printerPaperUnloaded; //regular sprite
    private bool hasPaper = false;
    private SpriteRenderer spriteRenderer;
    public GameObject exlamationMark;// quest marker object

    //used to give paper to player
    public GameObject playerPaper;

    private bool clickable = false;

    public GameObject HighLighter;//highlighter obj
    private Light2D HighlighterLight;// light compontent of highlighter

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        HighlighterLight = HighLighter.GetComponent<Light2D>();
        HighlighterLight.intensity = 0f;
        exlamationMark.SetActive(false);
        PaperReady();
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (clickable)
            {
                if (hasPaper)
                {
                    PaperDone();
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

    void PaperReady()
    {
        hasPaper = true;
        spriteRenderer.sprite = printerPaperReady;
        exlamationMark.SetActive(true);
    }

    void PaperDone()
    {
        hasPaper = false;
        spriteRenderer.sprite = printerPaperUnloaded;
        exlamationMark.SetActive(false);
        playerPaper.SetActive(true);
    }
}
