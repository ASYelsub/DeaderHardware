using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPopUp_Trigger : MonoBehaviour,ITriggerable
{
    bool open;

    public Transform towerBase;
    public Transform RightDoor;
    public Transform leftDoor;

    void Update()
    {
        if (open)
        {
            Vector3 r = RightDoor.localPosition;
            RightDoor.localPosition = Vector3.Lerp(RightDoor.localPosition, new Vector3(-2.85f,r.y,r.z), Time.deltaTime * 5);

            Vector3 l = leftDoor.localPosition;
            leftDoor.localPosition = Vector3.Lerp(leftDoor.localPosition, new Vector3(2.85f, l.y, l.z), Time.deltaTime * 5);

            Vector3 t = towerBase.localPosition;
            towerBase.localPosition = Vector3.Lerp(towerBase.localPosition, new Vector3(t.x,8.750f,t.z), Time.deltaTime * 0.5f);
        }
    }

    public void ExecuteTriggerFunction()
    {
        open = true;
    }
}
