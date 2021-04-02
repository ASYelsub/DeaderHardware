using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSystem_ItemPickup : MonoBehaviour, ITriggerable,IInteractable {

    
    public int itemId;

    enum BookNames { };

    public TextAsset file;
    private string _itemPopup;

    // Executes when you hit space near the object    
    public void ExecuteInteraction()
    {
        Item myItem = ServicesLocator.ItemLibrary.ItemList[itemId];

        _itemPopup = myItem.hoverText;

        GameManager.invM.AddItem(myItem.ID);

    }

    // Executes when you get near the object 
    public void ExecuteTriggerFunction() {

        Item myItem = ServicesLocator.ItemLibrary.ItemList[itemId];

        _itemPopup = myItem.hoverText;
      //  ServicesLocator.DialogueManager.SplitFile(file);
        Debug.Log("ExecuteTriggerFunction");
    }

    void ITriggerable.ExecuteLeaveTriggerFunction()
    {
        throw new System.NotImplementedException();
    }
}