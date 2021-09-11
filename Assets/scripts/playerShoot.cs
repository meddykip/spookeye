using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerShoot : MonoBehaviour
{

// PUBLIC tingz....
    public GameObject beam; // the player's ghost bullet >:)
    public GameObject baker; // the player :)

    public Transform beamTip; // the origin of the ghost beams !!

    public bool facingRight = true; // to detect flipping ..

    // Start is called before the first frame update
    void Start()
    {
        baker.GetComponent<playerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if(baker.GetComponent<playerMovement>().SPOOKBREAD){
            // shoot up !
            
            GameObject gbeam = (GameObject)Instantiate (beam, beamTip.position, Quaternion.identity);

            gbeam.GetComponent<bulletBehavior>().ySpeed = 1f;
        }
        
    }

////////// FLIPPING CODE ///////////
    // from : https://www.reddit.com/r/Unity2D/comments/4bwclp/rotating_child_objects_and_transformlocalscale/ !!

    public void Flip(){
            facingRight = true;
            Vector3 theScale = transform.localScale;
            theScale.x = 1.263919f;
            transform.localScale = theScale;
    }

    public void unFlip(){
            facingRight = false;
            Vector3 theScale = transform.localScale;
            theScale.x = -1.263919f;
            transform.localScale = theScale;
    }
}
