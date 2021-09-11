using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breadBehavior : MonoBehaviour
{

//  PUBLIC tuning variables
    public float jumpHeight;
    public float gravityMultiplier;
    public float jumpMultiplier;

    public float speed;

// PRIVATE code
    bool onFloor = false;
        // to check when the bread hits the floor to signal when to restart the game

//  REFERENCES to components
    SpriteRenderer myRenderer;

    public Rigidbody2D myBody;

    public GameObject beamPush;

    public GameObject baker;

    // Start is called before the first frame update
    void Start()
    {
        myBody = gameObject.GetComponent<Rigidbody2D>();
        myBody.AddForce(new Vector2(20 * Time.deltaTime * speed, 20 * Time. deltaTime * speed));

        beamPush.GetComponent<bulletBehavior>();
        baker.GetComponent<playerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate(){
        JumpPhysics();

        if(baker.GetComponent<playerMovement>().tossBread){
            if(Input.GetKeyDown(KeyCode.RightControl) || (Input.GetKeyDown(KeyCode.LeftControl))){
                myBody.velocity = new Vector3(myBody.velocity.x, jumpHeight);
                baker.GetComponent<playerMovement>().tossBread = false;
            }
        }
    }

/////// JUMP MOVEMENT + PHYSICS i got from class ... :) /////////
    void JumpPhysics(){
        if(myBody.velocity.y < 0){
            myBody.velocity += Vector2.up * Physics.gravity.y * (gravityMultiplier - 1f) * Time.deltaTime;
        }
    }

// when the ghostbeam collides with the bread. ... 
    void OnTriggerEnter2D(Collider2D other){

    // bounce...!!!
        if (!baker.GetComponent<playerMovement>().tossBread){
            if(other.gameObject.gameObject.tag == "ghostbeam"){

                Debug.Log("huh !!!! huh um ... huh!!!!! okay .. HUH .. okay?");
                myBody.velocity = new Vector3(myBody.velocity.x, jumpHeight);

            } else if (myBody.velocity.y > 1){

                myBody.velocity += Vector2.up * Physics.gravity.y * (jumpMultiplier * 1f)* Time.deltaTime;

            }
        }
    }
}
