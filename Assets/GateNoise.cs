using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateNoise : MonoBehaviour
{
    void Start()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/LibraryAdv");
    }
}
