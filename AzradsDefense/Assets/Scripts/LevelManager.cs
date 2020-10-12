using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [HideInInspector]
    public static LevelManager instance;

    //[HideInInspector]
    public Vector3 spawnLocation;

    private List<List<int>> waves;

    private int wavesSpawned;
    
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
        if(WaveManager.instance.Completed() && wavesSpawned < waves.Count)
        {
            SendWave();
        }
        if(WaveManager.instance.Completed() && wavesSpawned == waves.Count)
        {
            //END THE LEVEL
            Debug.Log("Level Over");
        }
    }

    private void SendWave()
    {
        WaveManager.instance.enemiesToSpawn = waves[wavesSpawned];
        WaveManager.instance.enemiesLeft = waves[wavesSpawned].Count;
        wavesSpawned++;
    }

    private void HardcodeWave()
    {
        waves.Add(new List<int> { 0, 0, 0, 0, 0, 0 }); //first wave to spawn
        waves.Add(new List<int> { 0, 0, 0, 0 });
        waves.Add(new List<int> { 0, 0, 0 }); //last wave to spawn
    }
}
