using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LibCam : MonoBehaviour
{
    public GameObject cameraHolder;

    private void Awake()
    {
        cameraHolder.SetActive(true);

    }
}
