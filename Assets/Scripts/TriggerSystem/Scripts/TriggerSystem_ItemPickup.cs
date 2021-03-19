using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSystem_ItemPickup : MonoBehaviour, ITriggerable,IInteractable {

    public int itemId;
    public TextAsset file;
    private string _itemPopup;
    
    public void ExecuteInteraction()
    {
        Item myItem = ServicesLocator.ItemLibrary.ItemList[itemId];

        _itemPopup = myItem.hoverText;

        ServicesLocator.GameManager.invM.AddItem(myItem.ID);

    }
    public void ExecuteTriggerFunction() {

        Item myItem = ServicesLocator.ItemLibrary.ItemList[itemId];

        _itemPopup = myItem.hoverText;
      //  ServicesLocator.DialogueManager.SplitFile(file);
        Debug.Log("ExecuteTriggerFunction");
    }
}