using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpriteButton : MonoBehaviour
{
    int animationFrames = 0;
    float storeXScale = 0;
    float storeYScale = 0;


    public UnityEvent leftButtonAction;
    public UnityEvent rightButtonAction;

    public int animationType = 1;
    void Start(){
        storeXScale = transform.localScale.x;
        storeYScale = transform.localScale.y;
    }

    public void onClick(int clickType){
        startAnimation();
        


        if(clickType == 1){
            //GameObject player = GameObject.FindGameObjectWithTag("Game").GetComponent<Game>().getPlayer();
            //GameObject item;
            //bool success;
           // item = player.GetComponent<Invent>().removeItem(generalValue, out success);
            leftButtonAction.Invoke();
            
        }else{
            leftButtonAction.Invoke();
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
