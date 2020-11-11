using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputControl : MonoBehaviour
{
    GameObject game;
    Game gameScript;
    // Start is called before the first frame update
    void Start()
    {
        game = GameObject.FindGameObjectWithTag("Game");
        gameScript = game.GetComponent<Game>();
    }

    // The update function will be used to detect keyboard+mouse activity
    void Update()
    {
        Mouse();
        Keyboard();
    }

    void Mouse(){
        if (Input.GetMouseButtonDown(0)){
            // LEFT
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            GameObject[] buttons = GameObject.FindGameObjectsWithTag("Button");
            
            foreach(GameObject button in buttons){
                if(Mathf.Abs(mousePosition.x - button.transform.position.x) < (button.GetComponent<SpriteRenderer>().bounds.size.x/2f)){
                    if(Mathf.Abs(mousePosition.y - button.transform.position.y) < (button.GetComponent<SpriteRenderer>().bounds.size.y/2f)){
                        // Hit button
                        Debug.Log(button);
                        button.GetComponent<SpriteButton>().onClick();
                    }
                }   
            }


        }
        if (Input.GetMouseButtonDown(1)){
            // RIGHT
        }

    }


    void Keyboard(){
        if (Input.GetKey(KeyCode.A)){
            gameScript.getPlayerScript().Move("left");
        }
        if (Input.GetKey(KeyCode.D)){
            gameScript.getPlayerScript().Move("right");
        }
        if (Input.GetKey(KeyCode.W)){
            gameScript.getPlayerScript().Move("up");
        }
        if (Input.GetKey(KeyCode.S)){
            gameScript.getPlayerScript().Move("down");
        }
    }

}
