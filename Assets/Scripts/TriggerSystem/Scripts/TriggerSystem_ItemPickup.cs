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

        // ITEM REFERENCE: ServicesLocator.ItemLibrary.ItemList[id]

    }
}