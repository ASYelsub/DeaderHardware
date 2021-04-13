using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    Transform tf;

    public bool disabled;
    public Vector3 rotPerFrame;
    void Start()
    {
        tf = GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!disabled)
        {
            tf.Rotate(rotPerFrame);
        }
    }
}
