using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDown : MonoBehaviour
{
    public Vector3 upPos;
    public Vector3 downPos;
    float timer;
    bool isVis = false;
    

    private void FixedUpdate()
    {
        if (!isVis){
            while (timer < 2){
                gameObject.transform.localPosition = Vector3.Lerp(upPos, downPos, timer);
                timer += 1;
            }if (timer >= 2){
                isVis = true;
            }

        }

    }

}
