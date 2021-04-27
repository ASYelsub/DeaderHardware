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
    [SerializeField] GameObject gC;
    [SerializeField] Vector3 endPos;
    Vector3 opPos;

    [Header("Main Menu Variables")]
    [SerializeField] GameObject MenuHolder;
    [SerializeField] TextMeshPro pressAny;
    Color openColor;
    bool opening;
    float loadingFloat;
    int loadingInt;

    [SerializeField] Rotate CERotateScript;
    HUB_LightSpin hLSScript;
    [SerializeField] GameObject loadingText;

    [Header("Option Variables")]
    [SerializeField] GameObject[] options;
    int selectedOption = 1;
    [SerializeField] Material selectMat;
    [SerializeField] Material unselectMat;
   
    void Start()
    {
        hLSScript = FindObjectOfType<HUB_LightSpin>();
        SetMenuActive(false);
        SetOptionsActive(false);
        opPos = GameCamera.position; //So the camera knows where to return to on escape
        ChangeActiveOption(true); //To set the active option to play
        openColor = pressAny.color;
        pressAny.color = Color.clear;
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
        if(pressAny.color != openColor && loadingFloat < 1)
        {
            loadingFloat += 0.0025f;
            {
                pressAny.color = Color.Lerp(Color.clear, openColor, loadingFloat);
            }
        }

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
            }else if(loadingInt >= 70)
            {
                loadingText.GetComponent<TextMeshPro>().text = "Loading...";
            }
            else if(loadingInt >= 40)
            {
                loadingText.GetComponent<TextMeshPro>().text = "Loading..";
            }
            else if(loadingInt >= 10)
            {
                loadingText.GetComponent<TextMeshPro>().text = "Loading.";
            }
        }
    }

    void SetMenuActive(bool b)
    {
        MenuHolder.SetActive(b);
        CERotateScript.disabled = b;
        GameCamera.gameObject.GetComponent<Rotate>().disabled = b;
        hLSScript.disabled = b;
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
            SceneManager.LoadScene("Level 1");
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
