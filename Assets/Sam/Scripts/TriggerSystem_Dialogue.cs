using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSystem_Dialogue : MonoBehaviour, ITriggerable
{
    public TextAsset file;
    public int lineLength;
    // font, line spacing
    // should this be in the text file?

    // Start is called before the first frame update
    void Start()
    {
        // READ TEXT FROM FILE
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ExecuteTriggerFunction() 
    {
        // talks to a text manager
        // takes the text file, reads it, based on the notation it's able to break up
        // 
    }
    /*
    Avoid monobehaviors, and if you use one it should be a custom update function and not 
    the base one. The only function you would call is InstantiateText() and then hand it a text
    file, probably. 
    All this individual class is going to be doing is handing off a file to the dialogue manager.
    The manager class will split the text file into a list of strings separated by a custom delimiter 
    (-- or w/e). 
    When the dialogue closes, clear the list.
    */
}