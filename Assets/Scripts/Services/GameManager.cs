using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class GameManager : MonoBehaviour
{
    public TextAsset ItemDictionary;
    [HideInInspector]
    public ItemLibrary il;
    
    void Start() {
 
        //ItemDictionary = Resources.Load<TextAsset>("Text/ItemDat");
        
        Volume PPV = FindObjectOfType<Volume>();
        if (!PPV == null) {
            if (PPV.profile.TryGet<Bloom>(out var bloom)) {
                bloom.active = true;
            }
        }
        //Initalize Services
        ServicesLocator.GameManager = this;
        ServicesLocator.CameraManager = new CameraManager();
        ServicesLocator.Music = new MusicManager();
        ServicesLocator.SceneChanger = new SceneChangeManager();
        //ServicesLocator.DialogueManager = new DialogueManager();
        il = new ItemLibrary(ItemDictionary.text);

        ServicesLocator.Initialization();
       // if (ItemDictionary != null) {
         //   ServicesLocator.ItemLibrary.Initialize(ItemDictionary.text);
        //}

        ServicesLocator.Music.changeTrack(0);

    }

    void Update() {

        ServicesLocator.CameraManager.Update();
        //ServicesLocator.DialogueManager.Update();
    }

}
