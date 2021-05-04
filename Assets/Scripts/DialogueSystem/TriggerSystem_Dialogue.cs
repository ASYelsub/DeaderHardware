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


    //Set to true if first dialogue with librarian or console entity, otherwise set to false
    [SerializeField]
    private bool grabPlayer;
    [SerializeField]
    private bool afterItemDeposit;

    // TODO:
    // * font
    // * line spacing
    [Header("Console (and Chandelier) Specific")]
    [SerializeField]
    private bool isConsole;
    [SerializeField]
    private GameObject oldConsole;
    [SerializeField]
    private GameObject newConsole;
    void Start() {
        if(manager == null)
        {
            manager = GameObject.Find("DialogueManager").GetComponent<DialogueManager>();
        }
        //textBox.text = "";
        //ExecuteTriggerFunction(); // REMOVE LATER
    } 

    public void ExecuteTriggerFunction() { //ServicesLocator.DialogueManager.SplitFile(this);

        print("This happened1");
        if (grabPlayer)
        {
            
            List<IDialogueCommand> dialogueCommands = new List<IDialogueCommand>();
            foreach (IDialogueCommand d in GetComponentsInChildren<IDialogueCommand>())
            {
                dialogueCommands.Add(d);
            }
            if (ServicesLocator.DialogueManager.canEngage)
            {
                ServicesLocator.DialogueManager.SplitFile(file, dialogueCommands.ToArray());
                StartCoroutine(ServicesLocator.DialogueManager.DisplayText(ServicesLocator.DialogueManager.lines[ServicesLocator.DialogueManager.lineNum]));
            }
        }
    }

    public void ExecuteInteraction()
    {
        print("This happened");

        if (!grabPlayer)
        {
            List<IDialogueCommand> dialogueCommands = new List<IDialogueCommand>();
            foreach (IDialogueCommand d in GetComponentsInChildren<IDialogueCommand>())
            {
                dialogueCommands.Add(d);
            }
            if (ServicesLocator.DialogueManager.canEngage)
                ServicesLocator.DialogueManager.SplitFile(file, dialogueCommands.ToArray());
        }
    }

    public void ExecuteLeaveTriggerFunction()
    {
        if (isConsole)
        {
            oldConsole.SetActive(false);
            newConsole.SetActive(true);
        }

    }
}