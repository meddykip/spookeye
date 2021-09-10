using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{

// PUBLIC tuning variables

    public float speed; // how fast the player moves

// REFERENCES to components

    Rigidbody2D myBody;

// PRIVATE code

    float moveDir = 1;
    // the player will move right by default

// SPRITES !!

    SpriteRenderer myRenderer;


    // Start is called before the first frame update
    void Start()
    {
        myBody = gameObject.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate(){ // runs first
        HandleMovement();
        ChecKeys();
    }

    void ChecKeys(){
        if(Input.GetKey(KeyCode.RightArrow)){
            moveDir = 1;
            Debug.Log("RIGHT RIGHT RIGHT RIGHT");
        } else {
            moveDir = 0;
        }
        if(Input.GetKey(KeyCode.LeftArrow)){
            moveDir = -1;
            Debug.Log("LEFT LEFT LEFT LEFT");
        }
        
        if(Input.GetKey(KeyCode.LeftArrow) && (Input.GetKey(KeyCode.RightArrow))){
            Debug.Log("hotel? trivago.");
        }
        
        if(Input.GetKeyUp(KeyCode.LeftArrow) && (Input.GetKeyUp(KeyCode.RightArrow))){
            Debug.Log("vibe? checked.");
        }
    }

        // code to handle movement from a class tutorial... :)
    void HandleMovement(){
        myBody.velocity = new Vector3(moveDir * speed, myBody.velocity.y);
    }
}
