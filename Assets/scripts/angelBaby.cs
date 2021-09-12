using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class angelBaby : MonoBehaviour
{

    public bool babyACTIVE = true;

    public AudioSource babyHit;

    // Start is called before the first frame update
    void Start()
    {
        babyHit = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        checkSelf();
    }

    void checkSelf(){
        if (gameObject.activeSelf){
            Debug.Log("BABY INACTIVE ...... ");
            babyACTIVE = false;
        } 
    }

    void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.gameObject.tag == "ghostbeam"){

            babyHit.Play();

            StartCoroutine(DESTRUCT());
            Debug.Log("BABY DESTROYED........ ");

        }
    }

    IEnumerator DESTRUCT(){
        yield return new WaitForSeconds (.5f); // after seconds , 

        Destroy(gameObject); // ... destroy gameobject!
        StopCoroutine(DESTRUCT());
    }
}
