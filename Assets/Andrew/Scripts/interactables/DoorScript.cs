using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : SceneChangeManager
{
    public int SceneToLoad;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) //whatever combination of proximity and input we use
        {
            TravelToScene();
        }
    }

    public void TravelToScene()
    {
        ChangeScene(SceneToLoad);
    }
}
