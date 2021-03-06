﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Hidden Variables
    float movementHiddenMultiplier = 0.003f;

    //Player Stats
    float movementSpeed = 1f;
    
    //Player owned
    public int coins = 0;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool Move(string direction){
        float distance = movementHiddenMultiplier*movementSpeed;

        if(direction == "left"){
            Vector3 newPos = transform.position + new Vector3(-distance, 0f, 0f);
            if(checkMovement(newPos)){
                transform.position = newPos;
                return true;
            }else{
                return false; 
            }
        }

        if(direction == "right"){
            Vector3 newPos = transform.position + new Vector3(distance, 0f, 0f);
            if(checkMovement(newPos)){
                transform.position = newPos;
                return true;
            }else{
                return false; 
            }
        }

        if(direction == "up"){
            Vector3 newPos = transform.position + new Vector3(0f, distance, 0f);
            if(checkMovement(newPos)){
                transform.position = newPos;
                return true;
            }else{
                return false; 
            }
        }

        if(direction == "down"){
            Vector3 newPos = transform.position + new Vector3(0f, -distance, 0f);
            if(checkMovement(newPos)){
                transform.position = newPos;
                return true;
            }else{
                return false; 
            }
        }
        return false;
    }



    bool checkMovement(Vector3 newPosition){
        GameObject[] solids = GameObject.FindGameObjectsWithTag("SolidSquare");
        GameObject[] floors = GameObject.FindGameObjectsWithTag("Floor");

       
        foreach(GameObject solid in solids){
            if(Mathf.Abs(newPosition.x - solid.transform.position.x) < (solid.GetComponent<SpriteRenderer>().bounds.size.x/2f)){
                if(Mathf.Abs(newPosition.y - solid.transform.position.y) < (solid.GetComponent<SpriteRenderer>().bounds.size.y/2f + GetComponent<SpriteRenderer>().bounds.size.y/2f)){
                    return false;
                }
            } 
        }

        foreach(GameObject floor in floors){
            if(Mathf.Abs(newPosition.x - floor.transform.position.x) < (floor.GetComponent<SpriteRenderer>().bounds.size.x/2f)){
                 if(Mathf.Abs(newPosition.y - floor.transform.position.y) < (floor.GetComponent<SpriteRenderer>().bounds.size.y/2f - GetComponent<SpriteRenderer>().bounds.size.y/2f)){
                    return true;
                 }      
            }
        }

        return false;
    }


    public void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.tag == "Item"){
            pickUpItem(col.gameObject);
        }
        if(col.gameObject.tag == "Stairs"){
            GameObject spawn = GameObject.FindGameObjectWithTag("Spawn");
            GameObject.FindGameObjectWithTag("Game").GetComponent<Game>().spawnNextRoom();
            GameObject.FindGameObjectWithTag("Game").GetComponent<Game>().spawnNextRoom();
            gameObject.transform.position = new Vector3(spawn.transform.position.x, spawn.transform.position.y, 0);
            Camera.main.transform.position = new Vector3(spawn.transform.position.x, spawn.transform.position.y, -10f);

            Destroy(spawn);
        }

    }

    void pickUpItem(GameObject item){
        if(item.GetComponent<Item>().data.itemName == "coin"){
            coins += item.GetComponent<Item>().amount;
            Destroy(item);
        }
        if(item.GetComponent<Item>().data.type == "material"){
            int freeSlot = GetComponent<Invent>().fillFreeSlot(item);
            if(freeSlot == 0){
                item.transform.position = new Vector3(-100f, -100f, 0f);
            }
            if(freeSlot == 2){
                Destroy(item);
            }
        }
        
    }
}
