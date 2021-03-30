using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Create_item_library_test : MonoBehaviour
{
    public string[] fileNames; // if you want to use multiple text files, put them here in order, and it will add all of the text together, then process them as a string. 
    TextAsset itemsTXT; 

    public static ItemLibrary_2 itemLibrary;

    void Start()
    {
        CreateItemLibrary();
    }

    void CreateItemLibrary()
    {
        string condensedString = "\n";

        foreach (string file in fileNames)
        {
            itemsTXT = Resources.Load<TextAsset>($"ItemInfo/{file}");
            condensedString += itemsTXT.text;
            condensedString += "\n";
        }

        if (fileNames.Length > 0)
        {
            itemLibrary = new ItemLibrary_2(condensedString);
        }
        else
        {
            print("NO FILE NAMES INCLUDED.");
        }

        for (int i = 0; i < 12; i++)
        {
            if (i == 3) { i = 6; }
            print(i);
        }
    }

}
