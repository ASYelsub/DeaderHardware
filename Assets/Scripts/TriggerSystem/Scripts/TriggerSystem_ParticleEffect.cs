using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//WHAT THIS SCRIPT DOES:
//This script is used on items like "the librarian" or "a button," anything that the player
//can interact with that they don't want to add to the inventory.
public class TriggerSystem_ParticleEffect : MonoBehaviour, ITriggerable
{
    public ParticleSystem ps;

    [SerializeField]
    Material offMat;
    [SerializeField]
    Material onMat;
    [SerializeField]

    List<GameObject> matBody = new List<GameObject>();

    public void ExecuteTriggerFunction()
    {
        ps.Play();
        for (int i = 0; i < matBody.Count; i++)
        {
            matBody[i].GetComponent<MeshRenderer>().material = onMat;
        }

    }


    public void ExecuteLeaveTriggerFunction()
    {
        ps.Stop();
        for (int i = 0; i < matBody.Count; i++)
        {
            matBody[i].GetComponent<MeshRenderer>().material = offMat;
        }

    }
}