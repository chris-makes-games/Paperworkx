using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class playerMove : MonoBehaviour
{
    //sprite stuff with colors
    public SpriteRenderer spriteRenderer;
    public Sprite greenMode;
    public Sprite yellowMode;
    public Sprite redMode;

    //rigidbody and movement
    private Rigidbody2D rb;
    public float speed = 20f;
    float xInput;
    float yInput;

    //variable for battery
    public float batteryLevel;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();//set rigidbody to component
        spriteRenderer = GetComponent<SpriteRenderer>(); //set sprite renderer to component
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
        }
        //if battery is less than 300, turn red
        else if (batteryLevel <= 300)
        {
            spriteRenderer.sprite = redMode;
        }
        //keep battery green
        else
        {
            spriteRenderer.sprite = greenMode;
        }
    }
}