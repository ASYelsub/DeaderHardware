using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotObjectHolder : MonoBehaviour
{
    public static ShotObjectHolder me;
    public ShotObjects[] shots;

    private int currentShot;

    void Awake()
    {
        me = this;
    }

    public void SwitchShot(int x)
    {
        Debug.Log("Switching from " + currentShot + " to " + x);
        for (int i = 0; i < shots[currentShot].Objs.Length; i++)
        {
            shots[currentShot].Objs[i].SetActive(false);
        }

        for (int i = 0; i < shots[x].Objs.Length; i++)
        {
            shots[x].Objs[i].SetActive(true);
        }

        currentShot = x;
    }
}

[System.Serializable]
public struct ShotObjects
{
    public MeshRenderer[] meshRends;
    public SpriteRenderer[] spriteRends;
}
 