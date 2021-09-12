using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class angelSpawner : MonoBehaviour
{

// from a tutorial :) ...
    // https://youtu.be/AI8XNNRpTTw !!

// ENEMIES
    public GameObject enemyBaby;
    public GameObject enemyFly;

/////////  ANGEL BABY SPAWN CODE ////////////
    //to handle Where angelbaby will spawn ....
    float randX;
    Vector2 whereToSpawn;

    public float spawnRate;
    float nextSpawn = 5;

    public GameObject babySummon;

    public float babyCount;

///////// ANGEL FLY SPAWN CODE /////////////
    // to handle where angelfly will spawn .....

    float randXfly;
    Vector2 whereToSpawnfly;

    public float spawnRatefly;
    float nextSpawnfly = 10;

// BOOLs ...,,

    public bool babyTIME = true;

///////////// REFERENCES to other tingz ...

    public GameObject baker;

    // Start is called before the first frame update
    void Start()
    {
        babySummon.GetComponent<angelBaby>();   
        baker.GetComponent<playerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
    
    if(babyCount <= 1){
        babySpawn();
        
        StopCoroutine(selfDestruct());
        // to regularly self destruct ... . 
    }

    flySpawn();

    }

    void babySpawn(){
// SPAWN CODE
        if(Time.time >  nextSpawn){
            nextSpawn = Time.time + spawnRate;
            randX = Random.Range(-4.8f, 6.1f);
            whereToSpawn = new Vector2 (randX, 3.0f);

            if(babySummon.GetComponent<angelBaby>().babyACTIVE){ // if angelBaby is active ...
                Debug.Log("ANGELBABY SPAWN");
                babyTIME = false; // summon !!!!
                
            } else if(!babySummon.GetComponent<angelBaby>().babyACTIVE){ // if it is not active ...
                Debug.Log("PAUSE SPAWNING");
                babyTIME = true; // stop spawning until player kills it again !
                
            }

        // if it is NOT babyTIME , spawn the angel babies ....
            if (!babyTIME){
                Instantiate (enemyBaby, whereToSpawn, Quaternion.identity);
                babyCount += 1;

                Debug.Log("SUMMONE...!!!!");

                StartCoroutine(selfDestruct());
                // to regularly self destruct ... . 
            }
            
            //justBaby();
        }
    }

    void flySpawn(){
        if(Time.time > nextSpawnfly){
            nextSpawnfly = Time.time + spawnRatefly;
            randXfly = Random.Range(-4.55f, 0.9f);
            whereToSpawnfly = new Vector2 (randXfly, 3.5f);

            Instantiate (enemyFly, whereToSpawnfly, Quaternion.identity);

        }
    }

    // to assign the angel baby prefab clone !!
    void justBaby(){
        babySummon = GameObject.Find("angelBaby(Clone)"); 
            // find the specified game object to assign to variable babySummon
    }

    IEnumerator selfDestruct(){
        yield return new WaitForSeconds (10f); // after a few seconds , 
        Destroy(GameObject.FindGameObjectWithTag("angelbaby"), 6f); // ... destroy gameobject!
        babyCount -= 1; // lessen baby count ?
    }
}
