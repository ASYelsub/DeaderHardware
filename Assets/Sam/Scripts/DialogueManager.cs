using System.Collections;
using System.Collections.Generic;
using System.Runtime;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public TriggerSystem_Dialogue dialogue; // REMOVE LATER
    public string delimiter = "~";

    private string[] lines;
    private bool isPrinting;
    private int lineNum = 0;
    
    public void Update()
    {
        Debug.Log(isPrinting + " LineNum: " + lineNum);
        
        if (isPrinting && Input.GetKeyDown(KeyCode.Space)) {
            Debug.Log("SPACE");
            if (lineNum >= lines.Length) {
                Cleanup();
            } else {
                ClearText();
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
        foreach (string s in lines) s.Trim();
        //lines = dialogue.file.text.Split(new string[] { delimiter }, System.StringSplitOptions.RemoveEmptyEntries);
        Debug.Log("Lines to print: " + lines.Length);

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

    private void Cleanup() 
    {
        Object.Destroy(dialogue.gameObject);
        dialogue.textBox.text = "";
        dialogue = null;
        lines = null;
        lineNum = 0;
        isPrinting = false;
    }

    private void ClearText() => dialogue.textBox.text = "";
}