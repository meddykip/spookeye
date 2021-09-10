using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerShoot : MonoBehaviour
{

// PUBLIC
    public GameObject beam; // the player's ghost bullet >:)
    public GameObject baker; // the player :)


    // Start is called before the first frame update
    void Start()
    {
        baker.GetComponent<playerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if(baker.GetComponent<playerMovement>().SPOOKBREAD){
            // shoot up
            GameObject gbeam = (GameObject)Instantiate (beam, transform.position, Quaternion.identity);

            gbeam.GetComponent<bulletBehavior>().ySpeed = 1f;
        }
    }
}
