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

    public void ExecuteInteraction() { ServicesLocator.DialogueManager.SplitFile(file); }
}