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

    public Animator movie;

////////////// AUDIO ////////////////

    public AudioSource openingSFX;
    public AudioSource endingSFX;

    public AudioSource coinEnterSFX;
    public AudioSource startGAMESFX;

    public AudioSource breadToss;
    public AudioSource breadCorner;

    public AudioSource scoreSFX;
    public AudioSource score5000;

    public AudioSource hitBorder;

    public AudioSource gunSFX;

//////////// BOOLS .... //////////////

    public bool SPOOKBREAD = false; 
        // to turn on / off shooting the bread !

    public bool startSHOOT = false; 
        // to detect when the shooting portion of the game starts

    public bool playerMOVE = false; 
        // to control player movement

    public bool HIGHSCORELETSGO = false;

////////////   REFERENCING others ..... /////////

    public GameObject spawngel; // to spawn the angels

    public GameObject ghostbread; // to activate the ghost bread

    public GameObject ghosTip; // to activate shooting !!


//////////////// UI ////////////////////

    public GameObject title;

    public GameObject instructions;

    public GameObject STARTgame;

    public GameObject score;


///////////// ETC ? //////////////////

    public bool tossBread = true;

    public bool faceRight = true;

    public GameObject shooTip;

    // Start is called before the first frame update
    void Start()
    {
        myBody = gameObject.GetComponent<Rigidbody2D>();
        myRenderer = gameObject.GetComponent<SpriteRenderer>();
        shooTip.GetComponent<playerShoot>();
        movie = GetComponent<Animator>();

        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

// runs first
    void FixedUpdate(){ 
        ChecKeys();
        HandleMovement();

        if (scoreScript.scoreValue >= 5000 && !HIGHSCORELETSGO){
            

            StartCoroutine(CELEBRATE());

            Debug.Log("5000!!!!!! !! ! ");
        }
    }

// to check what keys the player is pressing
    void ChecKeys(){
    
    // press 5 to start game !!!
    
        

        if (Input.GetKey(KeyCode.Alpha5) && !startSHOOT){
            title.SetActive(false);
            instructions.SetActive(false);
            STARTgame.SetActive(true);

            startGAMESFX.Stop();
            coinEnterSFX.Play();

            startSHOOT = true;

        } else if(Input.GetKey(KeyCode.Alpha1) && startSHOOT){
            startGAMESFX.Play();
            breadToss.Play();

            STARTgame.SetActive(false);
            score.SetActive(true);

            playerMOVE = true; // player can move
            spawngel.SetActive(true); // angels will start to spawn ...
            ghostbread.SetActive(true); // to activate the bread ....
            ghosTip.SetActive(true); // to activate shooting ...!!
            
            

            movie.SetBool("standing", false);
        } else {
            movie.SetBool("standing", true);
        }
    

    // code for moving !!
        if (playerMOVE){
            if(Input.GetKey(KeyCode.RightArrow)){
                faceRight = true;
                myRenderer.flipX = true;
                movie.SetBool("walk", true);
                movie.SetBool("standing", false);
                moveDir = 1;
                Debug.Log("RIGHT RIGHT RIGHT RIGHT");
            } else if(Input.GetKey(KeyCode.LeftArrow)){
                faceRight = false;
                myRenderer.flipX = true;
                movie.SetBool("walk", true);
                movie.SetBool("standing", false);
                moveDir = -1;
                Debug.Log("LEFT LEFT LEFT LEFT");
            } else {
                moveDir = 0;
            }
        }
        

    // code for shooting the bread !!
        if(Input.GetKeyDown(KeyCode.RightControl) || (Input.GetKeyDown(KeyCode.LeftControl))){
            Debug.Log("BANG ");
            gunSFX.Play();

            SPOOKBREAD = true;
        } else {
            SPOOKBREAD = false;
        }

    }

    // code to handle movement from the tutorial... :)
    void HandleMovement(){
        myBody.velocity = new Vector3(moveDir * speed, myBody.velocity.y);

    // to flip the shooting tip
        if(!faceRight){
            shooTip.GetComponent<playerShoot>().unFlip();
        } else if (faceRight){
            shooTip.GetComponent<playerShoot>().Flip();
        }

    }

    void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.gameObject.tag == "rightwall"){
            hitBorder.Play();
        } else if(other.gameObject.gameObject.tag == "leftwall"){
            hitBorder.Play();
        }
    }

    IEnumerator CELEBRATE(){
        yield return new WaitForSeconds (.1f); // after seconds , 

        score5000.Play();
        HIGHSCORELETSGO = true;

        
        StopCoroutine(CELEBRATE());
    }
}
