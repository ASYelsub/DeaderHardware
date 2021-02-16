using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : SceneChangeManager,ITriggerable,IInteractable
{
    public int SceneToLoad;
    public bool interactable; //determines whether this is a door in scene, or if this is just an object to teleport a player when interacting with a trigger (such as going down a hallway or around a corner, or off screen or something.

    private void Start()
    {
        foreach (MeshRenderer mesh in GetComponentsInChildren<MeshRenderer>())
        {
            mesh.enabled = interactable;
        }
        foreach (Collider coll in GetComponentsInChildren<Collider>())
        {
            coll.enabled = interactable;
        }
    }

    public void ExecuteInteraction()
    {
        ChangeScene(SceneToLoad);
    }

    public void ExecuteTriggerFunction()
    {
        if (!interactable)
        {
            ChangeScene(SceneToLoad);
        }
    }
}
