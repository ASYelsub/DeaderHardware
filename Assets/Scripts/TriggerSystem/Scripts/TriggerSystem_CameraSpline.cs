using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSystem_CameraSpline : MonoBehaviour, ITriggerable
{
    [Header("Configure")]
    public bool log;
    public GameObject[] playerSplinePoints;
    public GameObject[] cameraSplinePoints;


    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnDrawGizmos() {

        if (cameraSplinePoints.Length == 0 || playerSplinePoints.Length == 0) return;

        for (int i=0; i < cameraSplinePoints.Length - 1; i++) {
            if ((cameraSplinePoints[i+1]) == null) return;
            Debug.DrawLine(cameraSplinePoints[i].transform.position, cameraSplinePoints[i + 1].transform.position);
        }

        for (int i = 0; i < playerSplinePoints.Length - 1; i++) {
            if ((playerSplinePoints[i + 1]) == null) return;
            Debug.DrawLine(playerSplinePoints[i].transform.position, playerSplinePoints[i + 1].transform.position, Color.blue);
        }
    }

    public void ExecuteTriggerFunction() {
        if (log) Debug.Log("EXECUTED: DYNAMIC CAM");
        ServicesLocator.CameraManager.setShotDynamic(cameraSplinePoints,playerSplinePoints, true, this.gameObject);
    }
}
