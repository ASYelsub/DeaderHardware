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

    [HideInInspector]
    public string[] lines;
    private bool isTyping;
    [HideInInspector]
    public int lineNum = 0;
    [HideInInspector]
    public bool canEngage = true;
    [HideInInspector]
    public bool isShowing;
    private bool playCore;

    public TextMeshPro tm;
    
    public void Start()
    {
        tm = GameObject.Find("GameCamera").GetComponentInChildren<TextMeshPro>();
        tm.text = "";
        canEngage = true;
    }

    public void Update()
    {
       // print(canEngage);
        if(!GameManager.invM.menuOn && !GameManager.settingsM.settingsActive)
        {
            if (isShowing && Input.GetKeyUp(KeyCode.Space) && canEngage)
            {

                //Debug.Log("SPACE");
                if (lineNum >= lines.Length && !isTyping)
                {
                    ClearText();
                    Cleanup();
                    isShowing = false;
                    Debug.Log("This is happening");
                }
                else if(!isTyping)
                {
                    ClearText();
                    StartCoroutine(DisplayText(lines[lineNum]));
                }
            }
        }
        
    }

    public void SplitFile (TextAsset d, IDialogueCommand[] commands)
    {
        isShowing = true;

        lines = d.text.Split('\n');
        
        Debug.Log("Lines to print: " + lines.Length);

        Debug.Log(lines[lineNum]);
        currentCommands = commands;
        if (commands.Length == 0)
        {
            currentCommands = null;
        }
        //StartCoroutine("DisplayText", lines[lineNum]);
    }

    IDialogueCommand[] currentCommands;
    [SerializeField]
    private float typeSpeed;//lower is faster
    public IEnumerator DisplayText (string current) 
    {
        
        Debug.Log("Display Text is happening");
        isTyping = true;
        lineNum++;

        for (int i = 0; i < current.Length; i++)
        {
            if (commandInText(current, i)) // if a command is detected in the dialogue
            {
                foreach (IDialogueCommand cmd in currentCommands)// go through all the scripts in the trigger's children that use the interface 'IDialogueCommands'
                {
                    cmd.ExcecuteDialogueCommand(); //excecute the commands
                }
                i += 5; //skip ahead in the text so that you dont end up printing '<CMD>' on screen
                //Cleanup();
                yield return null;
            }
            if(i < current.Length)
            tm.text += current[i];
            yield return new WaitForSeconds(typeSpeed);
        }

        //foreach (char c in current) {
        //    tm.text += c;
        //    yield return null;
        //}
        isTyping = false;
        yield return null;
    }

    public void FillText(string current)
    {
        Debug.Log("FillText");
        isTyping = true;
        for (int i = 0; i < current.Length; i++)
        {
            if (commandInText(current, i)) // if a command is detected in the dialogue
            {
                foreach (IDialogueCommand cmd in currentCommands)// go through all the scripts in the trigger's children that use the interface 'IDialogueCommands'
                {
                    cmd.ExcecuteDialogueCommand(); //excecute the commands
                }
                i += 5;
            }
            if (i < current.Length)
                tm.text += current[i];
        }

        isTyping = false;
    }

    bool commandInText(string str, int i) //checks to see if string "<CMD>" is in text
    {
        bool b = false;
        b = str[i] == '<' &&
            str[i+1] == 'C' &&
            str[i+2] == 'M' &&
            str[i + 3] == 'D' &&
            str[i + 4] == '>';
        return b;
    }

    private void Cleanup() 
    {
        Debug.Log("Cleanup");
        //Object.Destroy(dialogue.gameObject
        tm.text = "";
        lines = null;
        lineNum = 0;
        isShowing = false;
        StartCoroutine(SpaceSpace(3));
    }

    private void ClearText()
    {
        tm.text = "";
    }
    private void FillLine()
    {

    }
    private IEnumerator SpaceSpace(float time)
    {
        canEngage = false;
        yield return new WaitForSeconds(time);
        canEngage = true;
        yield return null;
    }
}