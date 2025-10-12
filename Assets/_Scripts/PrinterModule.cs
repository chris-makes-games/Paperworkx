using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class PrinterModule : MonoBehaviour
{
    public Sprite printerPaperReady; //sprite with paper
    private bool paperReady = false;
    private SpriteRenderer spriteRenderer;
    public GameObject exlamationMark;// quest marker object

    private bool clickable = false;

    public GameObject HighLighter;//highlighter obj
    private Light2D HighlighterLight;// light compontent of highlighter

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        HighlighterLight = HighLighter.GetComponent<Light2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
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
        paperReady = true;
        spriteRenderer.sprite = printerPaperReady;
        exlamationMark.SetActive(true);
    }

    void PaperDone()
    {
        paperReady = false;
        spriteRenderer.sprite = printerPaperReady;
        exlamationMark.SetActive(false);
    }
}
