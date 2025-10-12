using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class LightBlink : MonoBehaviour
{
    public float interval;
    private float timer;
    private bool isActive;
    private Light2D blinkLight;
    public float intensity;

    void Start()
    {
        gameObject.SetActive(true);
        blinkLight = GetComponent<Light2D>();
    }
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > interval)
        {
            if (isActive)
            {
                blinkLight.intensity = 0f;
                isActive = false;
            }
            else
            {
                blinkLight.intensity = intensity;
                isActive = true;
            }
            timer = 0f;
        }
    }

    public void setInterval(float newInterval)
    {
        interval = newInterval;
    }
}
