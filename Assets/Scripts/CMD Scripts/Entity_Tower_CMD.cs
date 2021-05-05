using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity_Tower_CMD : MonoBehaviour, IDialogueCommand
{
    [SerializeField]
    private TowerPopUp_Trigger tower;

    [SerializeField]
    private bool isTower;
    [SerializeField]
    private GameObject toDisable;
    [SerializeField] private GameObject toEnable;
    public void ExcecuteDialogueCommand()
    {
        Debug.Log("Checking Execute Dialogue Command");
        tower.ExecuteTriggerFunction();

        if (isTower)
        {
            toEnable.SetActive(true);
            toDisable.SetActive(false);
        }
    }

    
}
