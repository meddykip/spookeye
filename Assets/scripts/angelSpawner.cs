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

///////// ANGEL FLY SPAWN CODE /////////////
    // to handle where angelfly will spawn .....

    float randXfly;
    Vector2 whereToSpawnfly;

    public float spawnRatefly;
    float nextSpawnfly = 10;

// BOOLs ...,,

    public bool babyTIME = true;

    // Start is called before the first frame update
    void Start()
    {
        babySummon.GetComponent<angelBaby>();    
    }

    // Update is called once per frame
    void Update()
    {
    
    babySpawn();
    flySpawn();

    }

    void babySpawn(){
// SPAWN CODE
        if(Time.time >  nextSpawn){
            nextSpawn = Time.time + spawnRate;
            randX = Random.Range(-7.2f, 7.9f);
            whereToSpawn = new Vector2 (randX, 4.2f);

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
            }
            
            justBaby();
        }
    }

    void flySpawn(){
        if(Time.time > nextSpawnfly){
            nextSpawnfly = Time.time + spawnRatefly;
            randXfly = Random.Range(-4.0f, 4.9f);
            whereToSpawnfly = new Vector2 (randXfly, 4.2f);

            Instantiate (enemyFly, whereToSpawnfly, Quaternion.identity);
        }
    }

    // to assign the angel baby prefab clone !!
    void justBaby(){
        babySummon = GameObject.Find("angelBaby(Clone)"); 
            // find the specified game object to assign to variable babySummon
    }
}
