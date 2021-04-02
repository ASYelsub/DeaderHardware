using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSystem_DeleteObject : MonoBehaviour, ITriggerable {

    [SerializeField]
    private GameObject objectToDelete;

    public void ExecuteLeaveTriggerFunction()
    {
        throw new System.NotImplementedException();
    }

    public void ExecuteTriggerFunction() {
    	print("object disabled");
        objectToDelete.SetActive(false);
    }

}
