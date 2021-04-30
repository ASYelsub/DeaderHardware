using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class GameManager : MonoBehaviour
{
    //public TextAsset ItemDictionary;
    [HideInInspector]
    public static InvMenu invM;
    public static SettingsMenu settingsM;
    public DialogueManager diaMan;

    void Start() {
        invM = FindObjectOfType<InvMenu>();
        settingsM = FindObjectOfType<SettingsMenu>();
        Volume PPV = FindObjectOfType<Volume>();
        if (!PPV == null) {
            if (PPV.profile.TryGet<Bloom>(out var bloom)) {
                bloom.active = true;
            }
        }
        //Initalize Services
        ServicesLocator.GameManager = this;
        ServicesLocator.LightManager = FindObjectOfType<LightManager>();
        ServicesLocator.LabelManager = FindObjectOfType<LabelManager>();
        ServicesLocator.CameraManager = new CameraManager();
      //  ServicesLocator.Music = new MusicManager();
        ServicesLocator.SceneChanger = FindObjectOfType<SceneChangeManager>();
        // ServicesLocator.ItemLibrary = new ItemLibrary(ItemDictionary.text);
        CreateItemLibrary();

        ServicesLocator.DialogueManager = diaMan;
        ServicesLocator.PlayerInteractor = FindObjectOfType<PlayerInteractor>();
       // invM.DoInvMenu();
          
        ServicesLocator.Initialization();
        // ServicesLocator.ItemLibrary.Initialize(ItemDictionary.text);

    //    ServicesLocator.Music.changeTrack(0);
    }

    public string[] fileNames; // if you want to use multiple text files, put them here in order, and it will add all of the text together, then process them as a string. 
    TextAsset itemsTXT;
    void CreateItemLibrary()
    {
        string condensedString = "\n";

        foreach (string file in fileNames)
        {
            itemsTXT = Resources.Load<TextAsset>($"ItemInfo/{file}");
            condensedString += itemsTXT.text;
            condensedString += "\n";
        }

        if (fileNames.Length > 0)
        {
            ServicesLocator.ItemLibrary = new ItemLibrary_2(condensedString);
        }
        else
        {
            print("NO FILE NAMES INCLUDED.");
        }
        //print(ServicesLocator.ItemLibrary.ItemList[0].name);
    }


    void Update() {

        ServicesLocator.CameraManager.Update();
        //ServicesLocator.DialogueManager.Update();
    }

}
