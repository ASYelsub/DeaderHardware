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

        int length = 0;
        if(shots[currentShot].mrs.Length >= shots[currentShot].srs.Length){
            length = shots[currentShot].mrs.Length;
        }else{
            length = shots[currentShot].srs.Length;
        }
        for (int i = 0; i < length; i++){
            if(shots[currentShot].mrs[i] != null){
                shots[currentShot].mrs[i].enabled = false;
            }
            if(shots[currentShot].srs[i] != null){
                shots[currentShot].srs[i].enabled = false;
            }
//            shots[currentShot].Objs[i].SetActive(false);
        }

        if (shots[x].mrs.Length >= shots[x].srs.Length){
            length = shots[x].mrs.Length;
        }else{
            length = shots[x].srs.Length;
        }

        for (int i = 0; i < length; i++){
            if (shots[currentShot].mrs[i] != null){
                shots[x].mrs[i].enabled = true;
            }
            if(shots[currentShot].mrs[i] != null){
                shots[x].srs[i].enabled = true;
            }
           
          //  shots[x].Objs[i].SetActive(true);
        }
        currentShot = x;
    }
}

[System.Serializable]
public struct ShotObjects
{
    public MeshRenderer[] mrs;
    public SpriteRenderer[] srs;
}
 