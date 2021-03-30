using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSystem_InstantiateObject : MonoBehaviour, ITriggerable
{

    [SerializeField]
    private GameObject objectToInstantiate;
    [SerializeField]
    private Vector3 overridePosition;

    public void ExecuteTriggerFunction() {
        //   if (overridePosition == Vector3.zero) {
        //      Instantiate(objectToInstantiate);
        //  } else {
        //      Instantiate(objectToInstantiate, overridePosition, Quaternion.identity);
        // }

        objectToInstantiate.SetActive(true);
    }

}
