using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class angelFly : MonoBehaviour
{

    public bool flyACTIVE = true;
    
////////////////   AI FLYING CODE  /////////////   
        // AI flying from a tutorial :)
            // https://youtu.be/rn3tCuGM688 !!
    public bool mustFLY;

    public float flySpeed;

    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        mustFLY = true;
    }

    // Update is called once per frame
    void Update()
    {
        checkSelf();
        if (mustFLY){
            flyTIME();
        }
    }

// a code just to check its existence !
    void checkSelf(){
        if (gameObject.activeSelf){
            Debug.Log(" FLYING ...... ");
            //flyACTIVE = false;
        } 
    }

// code so the angel can fly to the left ....
    void flyTIME(){
        rb.velocity = new Vector2(2 * flySpeed * -Time.fixedDeltaTime, rb.velocity.y);
    }

// when the angel collides with the left wall , 
    void OnTriggerEnter2D (Collider2D other){
        if (other.gameObject.tag == "leftwall"){
            Destroy(gameObject); // self destruct !!!
        }
    }
}
