using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_SwitchSprites : MonoBehaviour, ITriggerable
{
    public int shotNumber;

    public void ExecuteLeaveTriggerFunction()
    {
        //throw new System.NotImplementedException();
    }

    public void ExecuteTriggerFunction() {
        ServicesLocator.LightManager.UpdatelightManager(shotNumber);
        Debug.Log("EXECUTED: SWITCHSPRITES");
        ShotObjectHolder.me.SwitchShot(shotNumber);
    }
}
