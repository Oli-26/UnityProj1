using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invent : MonoBehaviour
{
    Item[] itemList = new Item[16];
    bool[] filledList = new bool[16];
    GameObject[] guiItemList = new GameObject[16];

    Item getItem(int n){
        if(filledList[n]){
            return itemList[n];
        }else{
            return null;
        }
    }

    void setItem(int n, Item item){
        itemList[n] = item;
        filledList[n] = true;
    }

    Item removeItem(int n){
        if(filledList[n]){
            filledList[n] = false;
            itemList[n] = null;
            return itemList[n];
        }else{
            return null;
        }
    }

    void swapSlots(int n1, int n2){
        Item tempItem = itemList[n1];
        bool tempSpace = filledList[n1];
        itemList[n1] = itemList[n2];
        itemList[n2] = tempItem;
        filledList[n1] = filledList[n2];
        filledList[n2] = tempSpace;
    }
}
