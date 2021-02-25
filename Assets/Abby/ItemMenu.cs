using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMenu : MonoBehaviour
{
    private bool menuOn;
    private bool menuIsMoving;

    [SerializeField]
    private Transform topMenuTransform;
    [SerializeField]
    private Transform bottomMenuTransform;

    private void Start()
    {
        menuOn = false;
        menuIsMoving = false;
        
    }
}
