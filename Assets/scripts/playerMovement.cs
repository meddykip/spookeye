using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{

//////// PUBLIC tuning variables /////////

    public float speed; // how fast the player moves

//////// REFERENCES to components ///////////

    Rigidbody2D myBody;

//////////// PRIVATE code //////////

    float moveDir = 0;
    // the player will move right by default

/////////// SPRITES !! ////////////

    SpriteRenderer myRenderer;

    public Sprite shootSprite;
    public Sprite walkSprite;

//////////// BOOLS .... //////////////

    public bool SPOOKBREAD = false; 
        // to turn on / off shooting the bread !

    public bool startSHOOT = false; 
        // to detect when the shooting portion of the game starts

    public bool playerMOVE = false; 
        // to control player movement

////////////   REFERENCING others ..... /////////

    public GameObject spawngel; // to spawn the angels

    public GameObject ghostbread; // to activate the ghost bread


public GameObject shooTip;

///////////// ETC ? //////////////////

    public bool tossBread = true;

    public bool faceRight = true;

    // Start is called before the first frame update
    void Start()
    {
        myBody = gameObject.GetComponent<Rigidbody2D>();
        myRenderer = gameObject.GetComponent<SpriteRenderer>();
        shooTip.GetComponent<playerShoot>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

// runs first
    void FixedUpdate(){ 
        ChecKeys();
        HandleMovement();
    }

// to check what keys the player is pressing
    void ChecKeys(){
    
    // press 5 to start game !!!
    if (!startSHOOT){
        if(Input.GetKey(KeyCode.Alpha5)){
            playerMOVE = true; // player can move
            spawngel.SetActive(true); // angels will start to spawn ...
            ghostbread.SetActive(true); // to activate the bread ....
            startSHOOT = true;
        }
    }

    // code for moving !!
        if (playerMOVE){
            if(Input.GetKey(KeyCode.RightArrow)){
                myRenderer.flipX = true;
                faceRight = true;
                
                moveDir = 1;
                Debug.Log("RIGHT RIGHT RIGHT RIGHT");
            } else if(Input.GetKey(KeyCode.LeftArrow)){
                faceRight = false;
                myRenderer.flipX = false;
                
                moveDir = -1;
                Debug.Log("LEFT LEFT LEFT LEFT");
            } else {
                moveDir = 0;
            }
        }
        

    // code for shooting the bread !!
        if(Input.GetKeyDown(KeyCode.RightControl) || (Input.GetKeyDown(KeyCode.LeftControl))){
            Debug.Log("BANG ");
            SPOOKBREAD = true;
        } else {
            SPOOKBREAD = false;
        }

    }

    // code to handle movement from the tutorial... :)
    void HandleMovement(){
        myBody.velocity = new Vector3(moveDir * speed, myBody.velocity.y);

        if(faceRight){
            shooTip.GetComponent<playerShoot>().unFlip();
        } else if (!faceRight){
            shooTip.GetComponent<playerShoot>().Flip();
        }
    }

}
