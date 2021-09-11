using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breadBounce : MonoBehaviour
{

// from tutorials ... :)
    // https://youtu.be/_CV9NlrAv0s !!
    // https://youtu.be/RoZG5RARGF0

    public Rigidbody2D myBody;

    Vector3 lastVelocity;

    public float bounceImpact; // the strength of bounce back

    // Start is called before the first frame update
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        lastVelocity = myBody.velocity;
    }

    void OnCollisionEnter2D(Collision2D other){
        var speed = lastVelocity.magnitude;
        var direction = Vector3.Reflect(lastVelocity.normalized, other.contacts[0].normal);

        myBody.velocity = direction * Mathf.Max(speed, bounceImpact);
    }
}
