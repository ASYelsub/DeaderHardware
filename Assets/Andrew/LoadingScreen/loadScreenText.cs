using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class loadScreenText : MonoBehaviour
{
    string[] s = { "LOADING", "LOADING.", "LOADING..", "LOADING...", };

    // Start is called before the first frame update
    void Start()
    {
        
    }
    int fr;
    int current;
    // Update is called once per frame
    void FixedUpdate()
    {
        fr++;
        if (fr % 20 == 0)
        {
            current++;
            if (current == s.Length) { current = 0; }
            GetComponent<TextMeshPro>().text = s[current];
        }
    }
}
