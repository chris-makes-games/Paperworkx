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

    //main controller
    public GameObject gameManager;
    private Manager managerScript;

    //paper
    public GameObject paper;

    //camera
    public GameObject playerCamera;

    //rigidbody and movement
    private Rigidbody2D rb;
    public float speed = 20f;
    float xInput;
    float yInput;

    //variable for battery
    public float batteryLevel;

    //all locations
    private Vector2 tutIntoMain = new Vector2(-14, -6);
    private Vector2 tutStart = new Vector2(-44, -25);
    private Vector2 mainIntoTut = new Vector2(-14, -7);
    private Vector2 mainIntoTurret = new Vector2(-14, 14);
    private Vector2 turretExit = new Vector2(-14, -7);

    //persistent player
    public static playerMove Instance { get; private set; }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
  {
        Manager managerScript = gameManager.GetComponent<Manager>();
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
      batteryLevel -= .01f;
      rb.linearVelocity = new Vector2(xInput * speed, rb.linearVelocity.y);
      float direction = Mathf.Sign(xInput);
      transform.localScale = new Vector3(direction, 1, 1);
    }
    if (Mathf.Abs(yInput) > 0)
    {
       batteryLevel -= .01f;
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
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("tutIntoMain"))
        {
            managerScript.movePlayer(tutIntoMain);
        }
        else if (collision.CompareTag("mainIntoTut"))
        {
            managerScript.movePlayer(mainIntoTut);
        }
        else if (collision.CompareTag("mainIntoTurret"))
        {
            playerCamera.transform.position = new Vector2(0, 8);
            managerScript.movePlayer(mainIntoTurret);
        }
        else if (collision.CompareTag("turretExit"))
        {
            playerCamera.transform.position = new Vector2(0, 0);
            managerScript.movePlayer(turretExit);
        }
        else
        {
            Debug.Log("Error: no such player location");
        }
    }

    public void getPaper()
    {
        paper.SetActive(true);
    }

    public void takePaper()
    {
        paper.SetActive(false);
    }
}
