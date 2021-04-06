using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSystem_ParticleEffect : MonoBehaviour, ITriggerable
{
    //This script is used on items like "the librarian" or "a button," anything that the player
    //can interact with that they don't want to add to the inventory.
    public ParticleSystem ps;

    public void ExecuteTriggerFunction()
    {
        ps.Play();
    }


    public void ExecuteLeaveTriggerFunction()
    {
        ps.Stop();
    }

}
