using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public TriggerSystem_Dialogue dialogue; // REMOVE LATER

    private string[] lines;
    private bool isPrinting;
    private int lineNum = 0;

    void Awake() {
        //lines = new List<string>();
    }
    
    public void Update()
    {
        Debug.Log(isPrinting + " LineNum: " + lineNum);
        if (isPrinting && Input.GetKeyDown(KeyCode.Space)) {
            Debug.Log("SPACE");
            if (lineNum >= lines.Length) {
                ClearDialogue();
            } else {
                StartCoroutine("DisplayText", lines[lineNum]);
            }
        }
    }

    public void SplitFile (TriggerSystem_Dialogue d)
    {
        dialogue = d;
        isPrinting = true;

            // The code doesn't want to compile with a delimiter longer than 
            // one character
        lines = dialogue.file.text.Split('~');


        StartCoroutine("DisplayText", lines[lineNum]);
    }

    private IEnumerator DisplayText (string current) 
    {
        lineNum++;

        foreach (char c in current) {
            dialogue.textBox.text += c;
            yield return null;
        }
        
        yield return null;
    }

    private void ClearDialogue() 
    {
        Object.Destroy(dialogue.gameObject);
        dialogue = null;
        lines = null;
        lineNum = 0;
        isPrinting = false;
    } 
}