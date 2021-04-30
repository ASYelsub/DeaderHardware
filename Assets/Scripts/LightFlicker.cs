using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlicker : MonoBehaviour
{
    // Start is called before the first frame update

    private Light light;
    private float lightIntensity;
    private int timer;
    [SerializeField] private Color red;
    [SerializeField] private Color yellow;

    void Start()
    {
        light = GetComponent<Light>();
        lightIntensity = light.intensity;
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        timer++;
        light.color = Color.Lerp(red, yellow, Mathf.Abs(Mathf.Sin(timer * 0.01f)));
        light.intensity = Mathf.Lerp(lightIntensity * 0.8f, lightIntensity * 1.2f, Mathf.Abs(Mathf.Cos(timer * 0.02f)));   
    }
}
