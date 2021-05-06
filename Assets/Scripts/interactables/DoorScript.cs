using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : SceneChangeManager
{
    public int SceneToLoad;
    public static int staticSceneToLoad;
    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            staticSceneToLoad = SceneToLoad;
            //ChangeScene(SceneToLoad);
            ChangeSceneS("SceneLoadUp");
        }
    }
}


