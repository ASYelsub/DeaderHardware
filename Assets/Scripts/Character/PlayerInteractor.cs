using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractor : MonoBehaviour
{
    Transform body;
    void Start()
    {
        body = transform;
    }

    public float radius;
    public Collider[] nearbyColliders;


    void Update()
    {
        nearbyColliders = Physics.OverlapSphere(transform.position,radius);
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
    }
}
