﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    // This class provides fast access to important game objects.
    // This class also stores global game valiables and states.

    public GameObject player1;
   


    public GameObject getPlayer(){
        return player1;
    }
    
    public Player getPlayerScript(){
        return player1.GetComponent<Player>();
    }

}
