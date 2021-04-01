using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSystem_InstantiateObject : MonoBehaviour, ITriggerable
{

    [SerializeField]
    private GameObject[] objectsToEnable;
    [SerializeField]
    private GameObject[] objectsToDisable;
    //[SerializeField]
   // private Vector3 overridePosition;

    public void ExecuteTriggerFunction() {
        //   if (overridePosition == Vector3.zero) {
        //      Instantiate(objectToInstantiate);
        //  } else {
        //      Instantiate(objectToInstantiate, overridePosition, Quaternion.identity);
        // }
        print("object enabled");
        for (int i = 0; i < objectsToEnable.Length; i++)
        {
            objectsToEnable[i].SetActive(true);
        }
        for (int i = 0; i < objectsToDisable.Length; i++)
        {
            objectsToDisable[i].SetActive(false);
        }

    }

}
