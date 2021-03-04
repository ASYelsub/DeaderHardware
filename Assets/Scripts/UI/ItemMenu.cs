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

    [SerializeField]private GameObject boxPrefab;
    private ItemBox[] itemBoxes;

  

    private void Start()
    {
        menuOn = false;
        menuIsMoving = false;
        menuObject.SetActive(menuOn);
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
