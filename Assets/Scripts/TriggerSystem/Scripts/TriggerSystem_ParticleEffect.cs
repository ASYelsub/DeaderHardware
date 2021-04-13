using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSystem_ParticleEffect : MonoBehaviour, ITriggerable
{
    public ParticleSystem ps;
    //
    public void ExecuteTriggerFunction()
    {
        ps.Play();
    }


    public void ExecuteLeaveTriggerFunction()
    {
        ps.Stop();
    }

}
