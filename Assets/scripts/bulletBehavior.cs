using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletBehavior : MonoBehaviour
{
// from a tutorial :)
    // https://www.youtube.com/watch?v=NjGwtJ0xelk !!

    public float ySpeed = 0f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(selfDestruct());
        // to regularly self destruct ... .
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position = transform.position;
        position.y += ySpeed;
        transform.position = position;
    }

    // to automatically delete the bullet !
    IEnumerator selfDestruct(){
        yield return new WaitForSeconds (5f); // after 5 seconds , 
        Destroy(gameObject); // ... destroy gameobject!
    }
}
