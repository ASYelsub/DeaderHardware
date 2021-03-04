using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMenu : MonoBehaviour
{
    private bool menuOn;
    private bool menuIsMoving;

    [SerializeField]
    private GameObject menuObject;
    [SerializeField]
    private Transform menuTransform;

    private SettingsMenu sm;



    private class ItemBox
    {
        Item currentItem;
        bool isFilled;
    }

    private class Item
    {
        bool isCollected;
        ItemBox currentItemBox;
    }

    private void Start()
    {
        menuOn = false;
        menuIsMoving = false;
        ToggleMenu();
        menuObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ToggleMenu();
        }
    }

    private void ToggleMenu()
    {
        menuOn = !menuOn;
        menuObject.SetActive(menuOn);
    }
}
