using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSystem_Text : MonoBehaviour,ITriggerable
{
    public Sprite DebugIcon;

    public string TestText;

    public void ExecuteTriggerFunction() {
        Debug.Log(TestText);
    }

    public void OnDrawGizmos() {
//        Gizmos.DrawIcon(transform.position, "TextGizmo.png", true);
    }
}
