using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : SceneChangeManager
{
    public int SceneToLoad;

    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            ChangeScene(SceneToLoad);
        }
    }
}


