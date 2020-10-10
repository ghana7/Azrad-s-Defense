using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [HideInInspector]
    public static LevelManager instance;

    [HideInInspector]
    public Vector3 spawnLocation;

    //WILL NEED A WAY TO STORE MULTIPLE WAVES
    //this is just temporary to get one wave to work
    private List<int> waves;

    private int wavesSpawned;
    

    // Start is called before the first frame update
    void Start()
    {
        spawnLocation = new Vector3(0, 0, 0);
        wavesSpawned = 0;
        waves = new List<int> { 0, 0, 0, 0, 0 };
        //waves.Push(new List<int>[0, 0, 0, 0, 0]);
        //waves.Push(new List<int>[0, 0]);
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        //if(WaveManager.instance.Completed() && wavesSpawned < waves.Count)
        if(WaveManager.instance.Completed())
        {
            SendWave();
        }
    }

    private void SendWave()
    {
        //WaveManager.instance.enemiesToSpawn = waves[wavesSpawned];
        WaveManager.instance.enemiesToSpawn = waves;
        wavesSpawned++;
    }
}
