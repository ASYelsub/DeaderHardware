using System.Collections;
using System.Collections.Generic;
using System.Runtime;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager me;
    public TextAsset file;

    private string[] lines;
    private bool dialogueUp;
    private bool isTyping;
    private int lineNum = 0;
    public bool isShowing;
    private bool playCore;

    public TextMeshPro tm;

    public void Start()
    {
        tm = GameObject.Find("GameCamera").GetComponentInChildren<TextMeshPro>();
        tm.text = "";
    }

    public void Update()
    {
        
        if (dialogueUp && Input.GetKeyUp(KeyCode.Space)) {
            Debug.Log("SPACE");
            if (lineNum >= lines.Length) {
                Cleanup();
            } else {
                StopCoroutine("DisplayText");
                ClearText();
                StartCoroutine("DisplayText", lines[lineNum]);
            }
        }
    }

    public void SplitFile (TextAsset d)
    {
        isShowing = true;
        dialogueUp = true;

        lines = d.text.Split('\n');
        
        Debug.Log("Lines to print: " + lines.Length);

        Debug.Log(lines[lineNum]);
        //StartCoroutine("DisplayText", lines[lineNum]);
    }

    public IEnumerator DisplayText (string current) 
    {
        Debug.Log("Display Text is happening");
        isTyping = true;
        lineNum++;

        foreach (char c in current) {
            tm.text += c;
            yield return null;
        }
        
        isTyping = false;
        yield return null;
    }

    private void Cleanup() 
    {
        //Object.Destroy(dialogue.gameObject
        isShowing = false;
        tm.text = "";
        lines = null;
        lineNum = 0;
        dialogueUp = false;
    }

    private void ClearText() => tm.text = "";
}