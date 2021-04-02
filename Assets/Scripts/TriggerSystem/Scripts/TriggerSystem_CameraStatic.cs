using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSystem_CameraStatic : MonoBehaviour,ITriggerable
{
    [Header("Configure")]
    public GameObject ShotObject;
    public bool track = true;
   // public int shotID;

    void OnDrawGizmos() {
        if (ShotObject == null) return;
        Debug.DrawLine(transform.position, ShotObject.transform.position, Color.green);
    }

    public void SetShot() {
        Transform camTransform = GameObject.FindGameObjectWithTag("MainCamera").transform;
        ShotObject.transform.position = camTransform.position;
        ShotObject.transform.rotation = camTransform.rotation;
    }

    public void ExecuteTriggerFunction() {
//        Debug.Log("EXECUTED: STATIC CAMERA");
        ServicesLocator.CameraManager.setShotStatic(ShotObject, track, this.gameObject);
    }

    public void ExecuteLeaveTriggerFunction()
    {
     //   throw new System.NotImplementedException();
    }
}