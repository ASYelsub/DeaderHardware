using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    bool menuState = false;
    bool menuActive = false;
    bool optionsActive = false;
    
    [Header("Camera Variables")]
    [SerializeField] Transform GameCamera;
    [SerializeField] Vector3 endPos;
    Vector3 opPos;

    [Header("Main Menu Variables")]
    [SerializeField] GameObject MenuHolder;
    int loadingInt;

    [SerializeField] Rotate CERotateScript;

    [Header("Option Variables")]
    [SerializeField] GameObject[] options;
    int selectedOption = 1;
    [SerializeField] Material selectMat;
    [SerializeField] Material unselectMat;

    void Start()
    {
        opPos = GameCamera.position; //So the camera knows where to return to on escape
        ChangeActiveOption(true); //To set the active option to play
    }

    void Update()
    {
        if(!menuState && Input.anyKeyDown) //On Title Screen
        {
            menuState = true;
        }

        if (menuState && optionsActive) //For Navigating Menu
        {
            if(Input.GetKeyDown(KeyCode.Escape)) //Returns to Title
            {
                menuState = false;
                SetOptionsActive(false);
                SetMenuActive(false);
            }

            if(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) //Moves up Option Selection
            {
                ChangeActiveOption(true);
            }

            if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)) //Moves down Option Selection
            {
                ChangeActiveOption(false);
            }

            if(Input.GetKeyDown(KeyCode.Space))
            {
                SelectOption();
            }
        }
    }

    void FixedUpdate()
    {
        if(menuState)
        {
            //Moves Camera Up
            if (Vector3.Distance(GameCamera.position, endPos) > 25)
            {
                GameCamera.position = Vector3.Lerp(GameCamera.position, endPos, 0.02f);
            }
            else
            {
                if (!menuActive)
                {
                    SetMenuActive(true);
                }
            }
        }
        else
        {
            if (Vector3.Distance(GameCamera.position, opPos) > 0.01f)
            {
                GameCamera.position = Vector3.Lerp(GameCamera.position, opPos, 0.05f);
            }
        }

        if(menuActive)
        {
            loadingInt += Random.Range(1, 2);
            if(loadingInt >= 100)
            {
                SetOptionsActive(true);
            }
        }
    }

    void SetMenuActive(bool b)
    {
        MenuHolder.SetActive(b);
        CERotateScript.disabled = b;
        loadingInt = 0;
        menuActive = b;
    }

    void SetOptionsActive(bool b)
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].SetActive(b);
            optionsActive = b;
        }
    }

    void ChangeActiveOption(bool optionUp)
    {
        if (optionUp)
        {
            if (selectedOption == 0)
            {
                selectedOption = 2;
            }
            else
            {
                selectedOption -= 1;
            }
        }
        else
        {
            if (selectedOption == 2)
            {
                selectedOption = 0;
            }
            else
            {
                selectedOption += 1;
            }
        }

        for (int i = 0; i < options.Length; i++)
        {
            if (i == selectedOption)
            {
                options[i].GetComponent<MeshRenderer>().material = selectMat;
            }
            else
            {
                options[i].GetComponent<MeshRenderer>().material = unselectMat;
            }
        }
    }

    void SelectOption()
    {
        if(selectedOption == 0)
        {
            SceneManager.LoadScene(2);
        }

        if(selectedOption == 1)
        {
            //Put Controls Screen stuff here
        }

        if(selectedOption == 2)
        {
            Application.Quit();
        }
    }
}
