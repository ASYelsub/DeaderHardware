using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDown : MonoBehaviour
{
    public Vector3 upPos;
    public Vector3 downPos;


    float timer;

    private void FixedUpdate()
    {
        while(timer < 3)
        {
            gameObject.transform.localPosition = Vector3.Lerp(upPos, downPos, timer);
            timer += 1;
        }
    }
}
