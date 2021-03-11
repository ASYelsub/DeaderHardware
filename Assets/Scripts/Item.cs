using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Goes on an object in the world that can be picked up
public class Item : MonoBehaviour
{
    [SerializeField]
    string ID;

    string name;
    string UIDesc;
    GameObject UIModel;
    string hoverText;
    bool isCollected;
    bool isPlaced;
    bool isBook;

    public Item(string ID)
    {

    }

}
