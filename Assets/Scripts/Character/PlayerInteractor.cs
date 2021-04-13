using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInteractor : MonoBehaviour
{
    InvMenu inv;
    SettingsMenu settings;
    Transform body;

    TextMeshPro displayText;

    void Start()
    {
        displayText = GameObject.FindGameObjectWithTag("POPUP").GetComponent<TextMeshPro>();
        body = transform;
        inv = FindObjectOfType<InvMenu>();
        settings = FindObjectOfType<SettingsMenu>();
    }

    public float radius;
    public Collider[] nearbyColliders;

    public GameObject displayedItem;

    void Update()
    {
        nearbyColliders = Physics.OverlapSphere(transform.position,radius);
        if (ServicesLocator.DialogueManager.isShowing == false && inv.menuOn == false && settings.settingsActive == false)
        {
            if (Input.GetKeyDown(KeyCode.Space) && ServicesLocator.DialogueManager.isShowing == false)
            {
                float dist = Mathf.Infinity;
                Collider nearestCollider = null;
                foreach (Collider item in nearbyColliders)
                {
                    //if (item.GetComponent<IInteractable>() == null) { return; }
                    //find the closest one
                    //if (Vector3.Distance(item.ClosestPoint(transform.position), transform.position + body.forward) < dist)
                    //{
                    //    dist = Vector3.Distance(item.ClosestPoint(transform.position), transform.position + body.forward);
                    //    nearestCollider = item;
                    //}
                    //nearestCollider.GetComponentInChildren<IInteractable>().ExecuteInteraction();
                    if (item.GetComponent<IInteractable>() != null)
                    {
                        item.GetComponentInChildren<IInteractable>().ExecuteInteraction();
                    }
                }
            }

            displayedItem = null;
            foreach (Collider item in nearbyColliders)
            {
                if (item.GetComponent<IInteractable>() != null)
                {
                    displayedItem = item.gameObject;
                }
            }
        }
        else
        {
            displayedItem = null;
        }

        if (displayedItem == null)
        {
            displayText.color = Color.Lerp(displayText.color,new Color(1,1,1,0), Time.deltaTime * 7f);
        }
        else
        {
            displayText.text = "INTERACTABLE NEARBY...";
            displayText.color = Color.Lerp(displayText.color, new Color(1, 1, 1, 1), Time.deltaTime * 7f);
        }
    }

    public void queryItemInteraction(int itemId) {
        foreach(Collider col in nearbyColliders) {
            if (col.GetComponent<InteractionQuery>() != null) {
                col.GetComponent<InteractionQuery>().ExecuteInteractionQuery(itemId);
            }
        }
    }
}
