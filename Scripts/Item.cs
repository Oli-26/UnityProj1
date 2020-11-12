using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;


public class Item : MonoBehaviour
{
    public ItemData data;
    public int amount = 1;
    // Start is called before the first frame update
    void Start()
    {
        loadItem(data.id);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void SaveIntoJson(){
        // Old functionality for saving new items.
        string item = JsonUtility.ToJson(data);
        System.IO.File.AppendAllText("\n"+Application.persistentDataPath + "/itemData.json", item);
    }

    public void loadItem(int idToLoad){
        // Reads file consisting of one jsonified item per line.
        // Splits each line in file into seperate string
        // Loads each json string into an item object, then checks to see if id matches.
        // If ID matches, replace itemData of this item to the matching itemData.
        StreamReader reader = new StreamReader (Application.persistentDataPath + "/itemData.json");
        string fileString = reader.ReadToEnd();
        reader.Close();
        string[] linesInFile = fileString.Split('\n');
        foreach(string line in linesInFile){
            ItemData temp = JsonUtility.FromJson<ItemData>(line);
            if(temp.id == idToLoad){
                JsonUtility.FromJsonOverwrite(line, data);
            }
        }
    }
}
