using System.Collections;
using System.Collections.Generic;
using System.Runtime;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager me;

    public TriggerSystem_Dialogue dialogue; // REMOVE LATER

    private string[] lines;
    private bool dialogueUp;
    private bool isTyping;
    private int lineNum = 0;
    public bool isShowing;
    private bool playCore;


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

    public void SplitFile (TriggerSystem_Dialogue d)
    {
        isShowing = true;
        dialogue = d;
        dialogueUp = true;

        lines = dialogue.file.text.Split('\n');
        
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
            dialogue.textBox.text += c;
            yield return null;
        }
        
        isTyping = false;
        yield return null;
    }

    private void Cleanup() 
    {
        //Object.Destroy(dialogue.gameObject
        isShowing = false;
        dialogue.textBox.text = "";
        dialogue = null;
        lines = null;
        lineNum = 0;
        dialogueUp = false;
    }

    private void ClearText() => dialogue.textBox.text = "";
}