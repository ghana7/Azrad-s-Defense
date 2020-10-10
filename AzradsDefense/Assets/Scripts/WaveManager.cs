using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//The Level Manager will send a list of strings with enemy types to the Wave Manager
//The Wave Manager will spawn units of the given type then, when the Level Manager sees the Wave Manager is done, the Level Manager can send a new wave
public class WaveManager : MonoBehaviour
{
    public List<string> enemiesToSpawn;
    public GameObject enemy;

    //WHEN AN ENEMY DIES NEED TO CHANGE THIS
    public uint enemiesLeft;

    private float timer;
    private float secondsBetweenSpawns;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0.0f;
        secondsBetweenSpawns = 5.0f;
        enemiesLeft = enemiesToSpawn.Count;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= secondsBetweenSpawns)
        {
            //FIX LOCATION
            Instantiate(enemy, new Vector3(0, 0, 0), Quaternion.identity);
            //SET THE ENEMY TYPE FROMM THE ENEMIES TO SPAWN LIST
            enemiesToSpawn.RemoveAt(0);
            timer = 0.0f;
        }

        //REMOVE FROM ENEMIES SPAWNED WHEN ENEMY DIES
    }

    //returns false if the wave is still going
    //if all enemies have been both spawned and removed, 
    public bool Completed()
    {
        if (enemiesLeft == 0)
        {
            //delete this wave manager?
            return true;
        }
        return false;
    }
}
