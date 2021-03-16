using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteHolder : MonoBehaviour
{
    public static SpriteHolder me;
    public ShotSprites[] shots;

    private int currentShot;

    void Awake()
    {
        me = this;
    }

    public void SwitchShot(int x)
    {
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
public struct ShotSprites
{
    public GameObject[] sprites;
}
