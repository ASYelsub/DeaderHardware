using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSystem_Text : MonoBehaviour,ITriggerable
{
    public string TestText;

    public void ExecuteTriggerFunction() {
        Debug.Log(TestText);
    }
}
