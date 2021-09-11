using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class angelBaby : MonoBehaviour
{

    public bool babyACTIVE = true;

    // Start is called before the first frame update
    void Start()
    {
        
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
}
