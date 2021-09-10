using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class angelSpawner : MonoBehaviour
{

// from a tutorial :) ...
    // https://youtu.be/AI8XNNRpTTw !!

// ENEMIES
    public GameObject enemyBaby;

// to handle Where the angels will spawn
    float randX;
    Vector2 whereToSpawn;

    public float spawnRate;
    float nextSpawn = 0;

    // Start is called before the first frame update
    void Start(){
 
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time >  nextSpawn){
            nextSpawn = Time.time + spawnRate;
            randX = Random.Range(-7.2f, 7.9f);
            whereToSpawn = new Vector2 (randX, 4.2f);

            Instantiate (enemyBaby, whereToSpawn, Quaternion.identity);

        }
    }

    
}
