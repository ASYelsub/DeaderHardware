using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_SwitchSprites : MonoBehaviour, ITriggerable
{
    public int shotNumber;

    public void ExecuteTriggerFunction() {
        Debug.Log("EXECUTED: SWITCHSPRITES");
        SpriteHolder.me.SwitchShot(shotNumber);     
    }
}
