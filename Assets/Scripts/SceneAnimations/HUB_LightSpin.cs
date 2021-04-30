using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUB_LightSpin : MonoBehaviour
{
    [HideInInspector]
    public bool disabled;
    void Start()
    {
        disabled = false;
        yrot = transform.rotation.eulerAngles.y;
    }
    float yrot;
    void FixedUpdate()
    {
        if (!disabled)
        {
            yrot += Time.deltaTime * 30;
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, yrot, transform.rotation.eulerAngles.z);
        }
    }
}
      
