using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerSystem_Dialogue : MonoBehaviour, ITriggerable
{
    public TextAsset file;
    public Text textBox;
    // public int lineLength;

    public DialogueManager manager; // REMOVE LATER

    // TODO:
    // * font
    // * line spacing

    void Start() {
        textBox.text = ""; 
        ExecuteTriggerFunction(); // REMOVE LATER
    } 

    public void ExecuteTriggerFunction() { manager.SplitFile(this); }
}