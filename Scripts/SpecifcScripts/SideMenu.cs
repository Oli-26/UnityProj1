using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideMenu : MonoBehaviour
{
    bool toggle = false;
    public GameObject button;

    // Update is called once per frame
    public void onClick()
    {
        button.GetComponent<SpriteRenderer>().flipX = !button.GetComponent<SpriteRenderer>().flipX;
        if(toggle){
            gameObject.transform.position += new Vector3(-2.27f,0f,0f);
        }else{
            gameObject.transform.position += new Vector3(2.27f,0f,0f); 
        }
        toggle = !toggle;
    }
    
}
