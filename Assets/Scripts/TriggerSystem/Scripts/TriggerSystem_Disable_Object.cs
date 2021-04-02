using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSystem_DisableObject : MonoBehaviour, ITriggerable
{

    [SerializeField]
    private GameObject objectToDisable;

    public void ExecuteLeaveTriggerFunction()
    {
        throw new System.NotImplementedException();
    }

    public void ExecuteTriggerFunction()
    {
        objectToDisable.SetActive(false);
    }

}
