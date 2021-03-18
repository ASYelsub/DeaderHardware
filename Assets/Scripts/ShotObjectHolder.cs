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
        for (int i = 0; i < shots[currentShot].sprites.Length; i++)
        {
            shots[currentShot].sprites[i].SetActive(false);
        }

        for (int i = 0; i < shots[x].sprites.Length; i++)
        {
            shots[x].sprites[i].SetActive(true);
        }

        currentShot = x;
    }
}

[System.Serializable]
public struct ShotObjects
{
    public GameObject[] sprites;
}