using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    void Start() {

        //Initalize Services
        ServicesLocator.GameManager = this;
        ServicesLocator.CameraManager = new CameraManager();
        ServicesLocator.Music = new MusicManager();
        ServicesLocator.SceneChanger = new SceneChangeManager();
        //ServicesLocator.DialogueManager = new DialogueManager();

        ServicesLocator.Initialization();

        ServicesLocator.Music.changeTrack(0);

    }

    void Update() {

        ServicesLocator.CameraManager.Update();
        //ServicesLocator.DialogueManager.Update();
    }

}
