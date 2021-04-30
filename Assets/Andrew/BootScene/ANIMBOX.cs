using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ANIMBOX : MonoBehaviour
{
    public TextAsset tt;
    string bigString;
    string[] boxFrames;

    // Start is called before the first frame update
    void Start()
    {
        bigString = tt.text;
        bigString = bigString.Replace('`', ' ');
        boxFrames = bigString.Split('~');
    }

    int fr;
    int currentFR;
    int increment = 1;
    // Update is called once per frame
    void FixedUpdate()
    {
        fr++;
        if (fr % 2 == 0)
        {
            if (currentFR == 0)
            {
                currentFR = 4;
            }
            else
            {
                currentFR = 0;
            }
        }
        if (currentFR == boxFrames.Length-1) { increment = -1; }
        if (currentFR == 0) { increment = 1; }
        GetComponent<TextMeshPro>().text = boxFrames[currentFR];
    }
}
