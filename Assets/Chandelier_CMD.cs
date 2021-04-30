using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chandelier_CMD : MonoBehaviour, IDialogueCommand
{
    [SerializeField]
    private ChandelierFall_Trigger chandelier;
    public void ExcecuteDialogueCommand()
    {
        Debug.Log("Checking Execute Dialogue Command");
        chandelier.ExecuteTriggerFunction();
    }
}
