using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSystem_ItemPickup : MonoBehaviour, ITriggerable,IInteractable {

    public int itemId;

    private string _itemPopup;

    public void ExecuteInteraction()
    {
        Item myItem = ServicesLocator.ItemLibrary.ItemList[itemId];

        _itemPopup = myItem.hoverText;

        if (myItem.isBook == false)
            ServicesLocator.GameManager.invM.AddItem(myItem.ID);
        else
            ServicesLocator.GameManager.invM.SetBook(myItem.ID);
        ServicesLocator.GameManager.invM.AddItem(itemId);

    }
    public void ExecuteTriggerFunction() {

        Item myItem = ServicesLocator.ItemLibrary.ItemList[itemId];

        _itemPopup = myItem.hoverText;
    }
}