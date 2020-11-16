using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Invent : MonoBehaviour
{
    GameObject[] itemList = new GameObject[16];
    bool[] filledList = new bool[16];
    public GameObject[] guiItemList = new GameObject[16];
    public GameObject[] guiItemAmount = new GameObject[16];

    GameObject getItem(int n){
        if(filledList[n]){
            return itemList[n];
        }else{
            return null;
        }
    }

    void setItem(int n, GameObject item){
        itemList[n] = item;
        filledList[n] = true;
        guiItemList[n].GetComponent<SpriteRenderer>().sprite = item.GetComponent<SpriteRenderer>().sprite;

        guiItemAmount[n].SetActive(true);
        guiItemAmount[n].GetComponent<TextMeshPro>().text = item.GetComponent<Item>().amount+"";
    }

    public GameObject removeItem(int n, out bool success){
        if(filledList[n]){
            GameObject tempItem = itemList[n];
            tempItem.transform.position = gameObject.transform.position+ new Vector3(0.5f,0f,0f);
            
            filledList[n] = false;
            itemList[n] = null;
            guiItemList[n].GetComponent<SpriteRenderer>().sprite = null;
            guiItemAmount[n].SetActive(false);
            success = true;
            return tempItem;
        }else{
            success = false;
            return null;
        }
    }

    void swapSlots(int n1, int n2){
        GameObject tempItem = itemList[n1];
        bool tempSpace = filledList[n1];
        itemList[n1] = itemList[n2];
        itemList[n2] = tempItem;
        filledList[n1] = filledList[n2];
        filledList[n2] = tempSpace;
    }

    public int fillFreeSlot(GameObject item){
        // This function iterates through the filledList to check for the next available slot, if none exist, false is returned. 
        // If a free slot if found, the item is added and true is returned.
        int i = 0;
        while(filledList[i] == true){
            if(itemList[i].GetComponent<Item>().data.id == item.GetComponent<Item>().data.id){
                itemList[i].GetComponent<Item>().amount += item.GetComponent<Item>().amount;
                guiItemAmount[i].GetComponent<TextMeshPro>().text = itemList[i].GetComponent<Item>().amount+"";
                return 2;
            }
            i++;
            
        }
        if(i > 15){
            return 1;
        }
        Debug.Log(i);
        setItem(i,item);
        return 0;
        
    }
}
