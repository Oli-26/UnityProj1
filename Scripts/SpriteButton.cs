using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteButton : MonoBehaviour
{
    public GameObject target;
    int animationFrames = 0;
    float storeXScale = 0;
    float storeYScale = 0;
    bool toggle = false;

    public enum typeButton {Invent, SideButton};
    public typeButton type; 
    public int animationType = 1;
    void Start(){
        storeXScale = transform.localScale.x;
        storeYScale = transform.localScale.y;
    }

    public void onClick(){
        startAnimation();

        if(type == typeButton.SideButton){
            GetComponent<SpriteRenderer>().flipX = !GetComponent<SpriteRenderer>().flipX;
            if(toggle){
                target.transform.position += new Vector3(-1.7f,0f,0f);
            }else{
                target.transform.position += new Vector3(1.7f,0f,0f); 
            }
            toggle = !toggle;
        }

    }   
    void startAnimation(){
        if(animationType == 1){
            animationFrames = 40;
            GetComponent<SpriteRenderer>().color = new Color(1f,0.6f,0.6f);
            transform.localScale = new Vector3(0.80f*storeXScale, 0.80f*storeYScale, 0);
        }
    }

    void Animation(){
        if(animationType == 1){
            if(animationFrames > 1){
                animationFrames--;
            }else if(animationFrames == 1){
                animationFrames = 0;
                GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f);
                transform.localScale = new Vector3(storeXScale, storeYScale, 0);
            }  
        }
        
        
        
    }     

    void Update()
    {
        Animation();
    }

}
