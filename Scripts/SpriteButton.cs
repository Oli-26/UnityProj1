using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteButton : MonoBehaviour
{
    int animationFrames = 0;
    float storeXScale = 0;
    float storeYScale = 0;

    void Start(){
        storeXScale = transform.localScale.x;
        storeYScale = transform.localScale.y;
    }

    public void onClick(){
        startAnimation();


    }   
    void startAnimation(){
        animationFrames = 40;
        GetComponent<SpriteRenderer>().color = new Color(1f,0.6f,0.6f);
        transform.localScale = new Vector3(0.80f*storeXScale, 0.80f*storeYScale, 0);
    }

    void Animation(){
        if(animationFrames > 1){
            animationFrames--;
        }else if(animationFrames == 1){
            animationFrames = 0;
            GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f);
            transform.localScale = new Vector3(storeXScale, storeYScale, 0);
        }
        
        
    }     

    void Update()
    {
        Animation();
    }

}
