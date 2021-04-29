using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSystem_Popup : MonoBehaviour, ITriggerable
{
    //This class is like this so particle effects (or whatever) dont play when itemPickup is null,
    //itemPickup is null when an item has been picked up and added to the inventory.
    //This script should be used specifically for items that are added to the inventory.
    [SerializeField]
    public enum objectType {Librarian, Book, Console};
    public ParticleSystem particleObject;
    [SerializeField]
    private Material onMat;
    [SerializeField]
    private Material offMat;
    [SerializeField]
    private GameObject matObj;
    public TriggerSystem_ItemPickup itemPickup;
    public void ExecuteInteraction(){}

    public void ExecuteTriggerFunction()
    {
        if(itemPickup.pickedUp == false || itemPickup == null)
        {
            particleObject.Play();

        }

        matObj.GetComponent<MeshRenderer>().material = onMat;
    }

    public void ExecuteLeaveTriggerFunction()
    {
        //print("WE STOPPED");
        particleObject.Stop();
        matObj.GetComponent<MeshRenderer>().material = offMat;
    }
}
