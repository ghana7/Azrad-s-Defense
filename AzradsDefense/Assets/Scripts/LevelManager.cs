using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [HideInInspector]
    public static LevelManager instance;

    //[HideInInspector]
    public Vector3 spawnLocation;
    public int level;

    private List<List<int>> waves;

    private int wavesSpawned;
    private bool paused;
    
    // Start is called before the first frame update
    void Start()
    {
        //spawnLocation = new Vector3(0, 0, 0); //change this if/when the spawn location is made hidden again
        wavesSpawned = 0;
        waves = new List<List<int>>();
        HardcodeWave();
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.P))
        {
            if (paused)
            {
                setSpeed(1);
                paused = false;
            }
            else
            {
                setSpeed(0);
                paused = true;
            }
        }

        //if the player has no health, end the game
        if (WaveManager.instance.Completed() && wavesSpawned < waves.Count)
        {
            SendWave();
        }
        if(WaveManager.instance.Completed() && wavesSpawned == waves.Count)
        {
            //END THE LEVEL
        }
    }

    private void SendWave()
    {
        WaveManager.instance.enemiesToSpawn = waves[wavesSpawned];
        WaveManager.instance.enemiesLeft = waves[wavesSpawned].Count;
        wavesSpawned++;
    }

    //the waves that are spawned for the level
    private void HardcodeWave()
    {
        if (level == 0)
        {
            waves.Add(new List<int> { 0, 0, 0, 0, 0, 0 }); //first wave to spawn
            waves.Add(new List<int> { 0, 0, 0, 0 });
            waves.Add(new List<int> { 0, 0, 0 }); //last wave to spawn
        }
        else if (level == 1)
        {
            waves.Add(new List<int> { 0, 0, 0, 0, 0, 0 }); //first wave to spawn
            waves.Add(new List<int> { 0, 0, 0, 0 });
            waves.Add(new List<int> { 0, 0, 0 }); //last wave to spawn
        }
        else if (level == 2)
        {
            waves.Add(new List<int> { 0, 0, 0, 0, 0, 0 }); //first wave to spawn
            waves.Add(new List<int> { 0, 0, 0, 0 });
            waves.Add(new List<int> { 0, 0, 0 }); //last wave to spawn
        }
        else
        {
            waves.Add(new List<int> { 0, 0, 0, 0, 0, 0 }); //first wave to spawn
            waves.Add(new List<int> { 0, 0, 0, 0 });
            waves.Add(new List<int> { 0, 0, 0 }); //last wave to spawn
        }
        
    }

    public void setSpeed(int speed) {
        Time.timeScale = speed;
    }
}
