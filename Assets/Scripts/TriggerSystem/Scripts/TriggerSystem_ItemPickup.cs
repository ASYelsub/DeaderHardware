using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSystem_ItemPickup : MonoBehaviour, ITriggerable {

    public int itemId;

    private string _itemPopup;

    public void ExecuteTriggerFunction() {

        Item myItem = ServicesLocator.ItemLibrary.ItemList[itemId];

        _itemPopup = myItem.hoverText;

        //Insert add inventory item here code
        if (myItem.isBook == false)
            ServicesLocator.GameManager.invM.AddItem(myItem.ID);
        else
            ServicesLocator.GameManager.invM.SetBook(myItem.ID);
        // ITEM REFERENCE: ServicesLocator.ItemLibrary.ItemList[id]
        ServicesLocator.GameManager.invM.AddItem(itemId);

    }
}