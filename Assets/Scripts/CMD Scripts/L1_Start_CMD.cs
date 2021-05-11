using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L1_Start_CMD : MonoBehaviour, IDialogueCommand
{
    [SerializeField]
    public GameObject nextlib;
    [SerializeField]
    public GameObject currentlib;

    public void ExcecuteDialogueCommand()
    {
        print("yes");
        nextlib.SetActive(true);
        currentlib.SetActive(false);
    }

}
