using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class angelBaby : MonoBehaviour
{

    public bool babyACTIVE = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

// to check if angelBaby is on the screen
    void OnBecameVisible(){ // if it is
        Debug.Log("angelspawn"); // lmk !
        babyACTIVE = true;
    }
}
