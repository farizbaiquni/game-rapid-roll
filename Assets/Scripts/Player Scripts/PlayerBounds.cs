﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBounds : MonoBehaviour
{
    public float min_X = -2.6f, max_X = 2.6f, min_y = -5.38f;

    bool out_Of_Bound;

    public static PlayerBounds instance;

    void Awake(){

        if(instance == null){
            instance = this;
        }

    }

    // Update is called once per frame
    void Update(){

        ChecKBound();
    }

    void ChecKBound(){
        Vector2 temp = transform.position;

        if(temp.x > max_X) {
            temp.x = max_X;
        }

        if(temp.x < min_X){
            temp.x = min_X;
        }

        transform.position = temp;

        if(temp.y <= min_y){
            
            if(!out_Of_Bound){
                
                out_Of_Bound = true;

                SoundManager.instance.deathSound();

                // GameManager.instance.RestateGame();

            
            }

        }
    }

    void OnTriggerEnter2D(Collider2D target) {
        if(target.tag == "TopSpike"){

            MovePlayerUp();

            // GetComponent<SpriteRenderer>().color = new Color (255, 255, 255, 0);

            HealthScript.instance.decreaseHealth();

            SoundManager.instance.deathSound();

            // GameManager.instance.RestateGame();
        }

        if(target.tag == "BatasBawah"){

            MovePlayerUp();

            HealthScript.instance.decreaseHealth();

            SoundManager.instance.deathSound();

            // GameManager.instance.RestateGame();
        }

        if(target.tag == "CubeVisible"){

            GetComponent<SpriteRenderer>().color = new Color (255, 255, 255, 255);

        }

        if(target.tag == "CubeInvisible"){

            GetComponent<SpriteRenderer>().color = new Color (255, 255, 255, 0);

        }

    }
    

    public void MovePlayerUp(){
        transform.position = new Vector2(0f, 1000f);
    }

}
