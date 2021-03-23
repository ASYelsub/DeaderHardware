using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemLibrary
{
    public List<Item> ItemList = new List<Item>();

    public ItemLibrary(string ItemDictionary)
    {
        //Debug.Log(ItemDictionary);


        string[] lines = ItemDictionary.Split('\n');

        for (int i = 1; i < lines.Length-1; i++)
        {
            ItemList.Add(CSVItemDictionaryToItemClass(lines[i]));
        }

    }
    public void Initialize(string ItemDictionary) {

        

    }

    public Item CSVItemDictionaryToItemClass(string line) {

        Item itemEntry = new Item();
        string[] elements = line.Split(',');

        //ID
        itemEntry.ID = int.Parse(elements[0]);
        //Name
        itemEntry.name = elements[1];
        //Description
        itemEntry.UIDesc = elements[2];
        //Float Text
        itemEntry.hoverText = elements[3];
        //Is a book?
        //Got the error "string is not recognized as valid boolean" so commented this out, I'm sure it can be figured out later. :^)
        //itemEntry.isBook = bool.Parse(elements[4]);

       // itemEntry.UIModel = null;

        return itemEntry;


    }

}
