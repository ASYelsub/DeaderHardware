using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PopupTextScript : MonoBehaviour
{
    bool fadeIn;

    public void StartUp(string textToDisplay="")
    {
        if (textToDisplay != "")
        {
            GetComponent<TextMeshPro>().text = "no text input...";
        }
        else
        {
            GetComponent<TextMeshPro>().text = textToDisplay;
        }
        fadeIn = true;
    }
    public void Stop()
    {
        fadeIn = false;
    }

    void Update()
    {
        if (fadeIn)
        {
            GetComponent<TextMeshPro>().color = Color.Lerp(GetComponent<TextMeshPro>().color,new Color(1,1,1,1), Time.deltaTime * 5);
        }
        else
        {
            GetComponent<TextMeshPro>().color = Color.Lerp(GetComponent<TextMeshPro>().color, new Color(1, 1, 1, 0), Time.deltaTime * 5);
        }
    }
}
