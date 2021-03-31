using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity_Tower_CMD : MonoBehaviour, IDialogueCommand
{
    [SerializeField]
    private TowerPopUp_Trigger tower;
    public void ExcecuteDialogueCommand()
    {
        tower.ExecuteTriggerFunction();
    }

    
}
