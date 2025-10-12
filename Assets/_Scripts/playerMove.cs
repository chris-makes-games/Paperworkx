using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class playerMove : MonoBehaviour
{
    //sprite stuff with colors
    public SpriteRenderer spriteRenderer;
    public Sprite greenMode;
    public Sprite yellowMode;
    public Sprite redMode;
    private LightBlink blinkScript;
    public Light2D blinker;

    //rigidbody and movement
    private Rigidbody2D rb;
    public float speed = 20f;
    float xInput;
    float yInput;

    //variable for battery
    public float batteryLevel;

    public static playerMove Instance { get; private set; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
        rb = GetComponent<Rigidbody2D>();//set rigidbody to component
        spriteRenderer = GetComponent<SpriteRenderer>(); //set sprite renderer to component
        blinkScript = blinker.GetComponent<LightBlink>();//gets the script from blinking light
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ProcessBattery();
    }

    void Update()
    {
        getInput();
        MoveWithInput();
    }

    void MoveWithInput()
    {
        if (Mathf.Abs(xInput) > 0)
        {
            rb.linearVelocity = new Vector2(xInput * speed, rb.linearVelocity.y);
            float direction = Mathf.Sign(xInput);
            transform.localScale = new Vector3(direction, 1, 1);
        }
        if (Mathf.Abs(yInput) > 0)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, yInput * speed);
        }
    }

    void getInput()
    {
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");
    }

    void ProcessBattery()//updates sprite depending on battery level
    {
        //if battery is less than 700, turn yellow
        if (batteryLevel < 700 && batteryLevel > 300)
        {
            spriteRenderer.sprite = yellowMode;
            blinker.color = Color.yellow;
            blinkScript.setInterval(0.5f);
        }
        //if battery is less than 300, turn red
        else if (batteryLevel <= 300)
        {
            spriteRenderer.sprite = redMode;
            blinker.color = Color.red;
            blinkScript.setInterval(0.25f);
        }
        //keep battery green
        else
        {
            spriteRenderer.sprite = greenMode;
        }
    }
}