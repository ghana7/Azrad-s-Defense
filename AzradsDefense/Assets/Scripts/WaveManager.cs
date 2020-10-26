using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//The Level Manager will send a list of strings with enemy types to the Wave Manager
//The Wave Manager will spawn units of the given type then, when the Level Manager sees the Wave Manager is done, the Level Manager can send a new wave
public class WaveManager : MonoBehaviour
{
    [HideInInspector]
    public static WaveManager instance;
    [HideInInspector]
    public List<int> enemiesToSpawn;
    [HideInInspector]
    public int enemiesLeft;

    [SerializeField]
    private List<GameObject> enemyType;

    private float timer;
    private float secondsBetweenSpawns;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0.0f;
        secondsBetweenSpawns = 0.7f;

        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= secondsBetweenSpawns)
        {
            if (enemiesToSpawn.Count > 0)
            {
                GameObject newEnemy = Instantiate(enemyType[enemiesToSpawn[0]], LevelManager.instance.spawnLocation, Quaternion.identity);
                enemiesToSpawn.RemoveAt(0);
                timer = 0.0f;
            }
        }
    }

    //returns false if the wave is still going
    //if all enemies have been both spawned and removed, 
    public bool Completed()
    {
        if (enemiesLeft == 0)
        {
            return true;
        }
        return false;
    }

    public void RemoveEnemy()
    {
        enemiesLeft--;
    }
}
