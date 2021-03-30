using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ItemLibrary_2
{
    public List<Item> ItemList = new List<Item>();

    public ItemLibrary_2(string ItemDictionary)
    {
        //Debug.Log(ItemDictionary);
        //string[] lines = ItemDictionary.Split(new string[] { "__" }, StringSplitOptions.None);
        string[] lines = ItemDictionary.Split('~');

        for (int i = 0; i < lines.Length; i++)
        {
            ItemList.Add(TXTtoITEM(lines[i], i));
        }
    }


    public Item TXTtoITEM(string itemInfo, int id)
    {
        Item itemEntry = new Item();
        string[] elements = itemInfo.Split('\n');

        itemEntry.ID = id;
        itemEntry.name = elements[1];
        itemEntry.UIDesc = elements[2];
        if (elements[3] != null && elements[3]!="" && elements[3].Length>1)
        {
            itemEntry.hoverText = elements[3];
        }
        else
        {
            itemEntry.hoverText = $"press SPACE to pick up {itemEntry.name}";
        }

        return itemEntry;
    }
}
