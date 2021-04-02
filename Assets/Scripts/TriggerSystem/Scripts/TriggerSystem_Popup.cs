using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSystem_Popup : MonoBehaviour, ITriggerable, IInteractable
{
    [SerializeField]
    public enum objectType {Librarian, Book, Console};
    public ParticleSystem particleObject;
    public Material selectMat;
    public void ExecuteInteraction(){}

    public void ExecuteTriggerFunction()
    {
        particleObject.Emit(1);
        
    }
}
