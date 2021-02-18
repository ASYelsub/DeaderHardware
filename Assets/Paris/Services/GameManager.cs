using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    void Start() {

        //Initalize Services
        ServicesLocator.GameManager = this;
        ServicesLocator.CameraManager = new CameraManager();

        ServicesLocator.Initialization();

    }

    void Update() {

        ServicesLocator.CameraManager.Update();



    }

}
