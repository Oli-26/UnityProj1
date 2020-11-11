using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float movementSpeed = 1f;
    float movementHiddenMultiplier = 0.001f;

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
        
        foreach(GameObject solid in solids){
            
            if(Mathf.Abs(newPosition.x - solid.transform.position.x) < (solid.GetComponent<SpriteRenderer>().bounds.size.x/2f)){
                if(Mathf.Abs(newPosition.y - solid.transform.position.y) < (solid.GetComponent<SpriteRenderer>().bounds.size.y/2f)){
                    return false;
                }
            }
            
        }
        return true;
    }
}
