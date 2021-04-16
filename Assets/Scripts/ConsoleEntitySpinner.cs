using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsoleEntitySpinner : MonoBehaviour
{
    int timer;
    public int spin;

    void FixedUpdate()
    {
        timer++;
        transform.Rotate(new Vector3(0,spin * Mathf.Sin(timer * 0.001f), 0));
    }
}

