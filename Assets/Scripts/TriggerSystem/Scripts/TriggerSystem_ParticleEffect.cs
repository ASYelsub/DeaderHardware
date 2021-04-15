using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSystem_ParticleEffect : MonoBehaviour, ITriggerable
{
    public ParticleSystem ps;
    public string hoverText;

    public void ExecuteTriggerFunction()
    {
        ps.Play();
        if (GameObject.FindGameObjectWithTag("POPUP"))
        {
            GameObject.FindGameObjectWithTag("POPUP").GetComponent<PopupTextScript>().StartUp(hoverText);
        }
    }


    public void ExecuteLeaveTriggerFunction()
    {
        ps.Stop();
        if (GameObject.FindGameObjectWithTag("POPUP"))
        {
            GameObject.FindGameObjectWithTag("POPUP").GetComponent<PopupTextScript>().Stop();
        }
    }


}
