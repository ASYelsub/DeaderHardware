using System.Collections.Generic;

public class ItemLibrary
{
    public List<Item> ItemList = new List<Item>();

    public void Initialize(string ItemDictionary) {

        string[] lines = ItemDictionary.Split('\n');

        for (int i = 1; i < lines.Length; i++) {
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
