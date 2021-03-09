using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class GameManager : MonoBehaviour
{
    
    void Start() {

        Volume PPV = FindObjectOfType<Volume>();
        if (PPV.profile.TryGet<Bloom>(out var bloom))
        {
            bloom.active = true;
        }
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
