using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerSystem_Dialogue : MonoBehaviour, ITriggerable, IInteractable
{
    public TextAsset file;
    //public Text textBox;
    // public int lineLength;

    public DialogueManager manager;

    // TODO:
    // * font
    // * line spacing

    void Start() {
        if(manager == null)
        {
            manager = GameObject.Find("DialogueManager").GetComponent<DialogueManager>();
        }
        //textBox.text = "";
        //ExecuteTriggerFunction(); // REMOVE LATER
    } 

    public void ExecuteTriggerFunction() { //ServicesLocator.DialogueManager.SplitFile(this);
    }

    public void ExecuteInteraction()
    {
        List<IDialogueCommand> dialogueCommands = new List<IDialogueCommand>();
        foreach (IDialogueCommand d in GetComponentsInChildren<IDialogueCommand>())
        {
            dialogueCommands.Add(d);
        }
        if(ServicesLocator.DialogueManager.canEngage)
            ServicesLocator.DialogueManager.SplitFile(file,dialogueCommands.ToArray());
    }

    public void ExecuteLeaveTriggerFunction()
    {
     //   throw new System.NotImplementedException();
    }
}