using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsoleEntitySpinner : MonoBehaviour
{
    public Vector3 spin;



    void FixedUpdate()
    {
        transform.Rotate(spin);
    }
}

