using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_System_RotateDoor : MonoBehaviour, ITriggerable
{
    bool open;
    bool opened;
    [SerializeField] bool spinDir;
    [SerializeField] GameObject pivot;
    int rotateAmount;
    public void ExecuteLeaveTriggerFunction()
    {
        //N/A
    }

    //[SerializeField]
    // private Vector3 overridePosition;

    public void ExecuteTriggerFunction()
    {
        open = true;
    }

    void FixedUpdate()
    {
        if(open && !opened)
        {
            rotateAmount++;
            
            if (spinDir) pivot.transform.Rotate(0, 1, 0);
            else pivot.transform.Rotate(0, 1, 0);

            if (rotateAmount > 90) opened = true;
        }
    }
}
