using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Goes on an object in the world that can be picked up
public class Item
{
    public int ID;

    public string name;
    public string UIDesc;
    public GameObject UIModel;
    public string hoverText;
    public bool isCollected;
    public bool isPlaced;
    public bool isBook;
}
