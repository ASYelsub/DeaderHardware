using System.Collections.Generic;
using UnityEngine;

public class ItemLibrary
{
    public List<Item> ItemList = new List<Item>();

    public ItemLibrary(string ItemDictionary)
    {
        //This might look weird but it works
        //so... don't change it. :)
        string[] lines = new string[1];
        lines = ItemDictionary.Split('\n');
        
        for (int i = 1; i < lines.Length; i++)
        {
            //Debug.Log(lines[i]);
            ItemList.Add(CSVItemDictionaryToItemClass(lines[i]));
        }
    }


    public Item CSVItemDictionaryToItemClass(string line) {

        Item itemEntry = new Item();
        string[] elements = line.Split(',');
        
        //ID
        itemEntry.ID = int.Parse(elements[0]);
        //Name
        itemEntry.name = elements[1];
        Debug.Log(itemEntry.name);
        //Description
        itemEntry.UIDesc = elements[2];
        //Float Text
        itemEntry.hoverText = elements[3];
        //Is a book?
        itemEntry.isBook = bool.Parse(elements[4]);

        itemEntry.UIModel = null;

        return itemEntry;


    }

}
