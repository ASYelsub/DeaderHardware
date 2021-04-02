using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSystem_Popup : MonoBehaviour, ITriggerable, IInteractable
{
    [SerializeField]
    public enum objectType {Librarian, Book, Console};
    public ParticleSystem particleObject;
    public Material selectMat;
    public TriggerSystem_ItemPickup itemPickup;
    public void ExecuteInteraction(){}

    public void ExecuteTriggerFunction()
    {
        if(itemPickup.pickedUp == false || itemPickup == null)
        {
            particleObject.Play();

        }
    }

    void ITriggerable.ExecuteLeaveTriggerFunction()
    {
        //print("WE STOPPED");
        particleObject.Stop();
    }
}
