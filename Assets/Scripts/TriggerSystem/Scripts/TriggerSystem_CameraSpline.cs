using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSystem_CameraSpline : MonoBehaviour, ITriggerable
{
    [Header("Configure")]
    public GameObject[] splinePoints;


    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnDrawGizmos() {
        for (int i=0; i < splinePoints.Length - 1; i++) {
            if ((splinePoints[i+1]) == null) return;
            Debug.DrawLine(splinePoints[i].transform.position, splinePoints[i + 1].transform.position);
        }
    }

    public void ExecuteTriggerFunction() {
        Debug.Log("EXECUTED: STATIC CAMERA");
        ServicesLocator.CameraManager.setShotDynamic(splinePoints, true, this.gameObject);
    }

    public void ExecuteLeaveTriggerFunction()
    {
        throw new System.NotImplementedException();
    }
}
