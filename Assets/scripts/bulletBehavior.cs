using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletBehavior : MonoBehaviour
{
// from a tutorial :)
    // https://www.youtube.com/watch?v=NjGwtJ0xelk !!

    public float ySpeed = 0f;

    public GameObject ghostbread;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(selfDestruct());
        // to regularly self destruct ... .

        ghostbread.GetComponent<breadBehavior>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position = transform.position;
        position.y += ySpeed;
        transform.position = position;
    }

    // KILLING CODE
    // i might also use this code to keep track of the points ?
    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.gameObject.tag == "bread"){
            Debug.Log("BREAD CRUMBS!! BREAD BREAD");
            
            // add +5 points

        } else if (other.gameObject.gameObject.tag == "angelbaby"){
            Debug.Log("BABY DESTROYED........ ");
            // add +50 points

        } else if (other.gameObject.gameObject.tag == "angelfly"){
            Debug.Log("FLY GONE.....!!!!!");
            // add +1000 points

        } 
    }

// AUTO DELETE CODE/S ....!!!
    void OnBecameInvisible(){ // when the beam is out of the screen..,
        Destroy(gameObject); // self distruct :)
    }

    IEnumerator selfDestruct(){
        yield return new WaitForSeconds (5f); // after 5 seconds , 
        Destroy(gameObject); // ... destroy gameobject!
    }
}
