using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    // This class provides fast access to important game objects.
    // This class also stores global game valiables and states.

    public GameObject player1;
    public GameObject currentRoom;
    public GameObject nextRoom;
    int floorLevel = 0;
    

    public GameObject roomPrefab1;


    public GameObject getPlayer(){
        return player1;
    }
    
    public Player getPlayerScript(){
        return player1.GetComponent<Player>();
    }


    public void spawnNextRoom(){
        progressRoom();
        GameObject spawn = GameObject.FindGameObjectWithTag("Spawn");
        GameObject nextRoom = Instantiate(roomPrefab1, spawn.transform.position + new Vector3(0, 10f, 0), Quaternion.identity);
    }

    public void progressRoom(){
        currentRoom = nextRoom;

    }
}
