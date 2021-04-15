using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSystem_ItemPickup : MonoBehaviour, ITriggerable,IInteractable {

    
    public int itemId;

    enum BookNames { };

    public TextAsset file;
    private string _itemPopup;
    [HideInInspector]
    public bool pickedUp = false;
    public GameObject bookModel;

    private void Start()
    {
        pickedUp = false;
    }
    // Executes when you hit space near the object    
    public void ExecuteInteraction()
    {
        if(pickedUp == false)
        {
            Item myItem = ServicesLocator.ItemLibrary.ItemList[itemId];

            _itemPopup = myItem.hoverText;

            GameManager.invM.AddItem(myItem.ID);
            bookModel.GetComponent<MeshRenderer>().enabled = false;
            pickedUp = true;
        }
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
        //throw new System.NotImplementedException();
    }
}