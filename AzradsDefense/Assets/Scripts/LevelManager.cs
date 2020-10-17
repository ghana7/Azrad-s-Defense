using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [HideInInspector]
    public static LevelManager instance;

    //[HideInInspector]
    public Vector3 spawnLocation;
    public int level;
    public Button button;

    private List<List<int>> waves;

    private int wavesSpawned;
    private bool paused;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        //spawnLocation = new Vector3(0, 0, 0); //change this if/when the spawn location is made hidden again
        wavesSpawned = 0;
        waves = new List<List<int>>();
        HardcodeWave();
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
            Debug.Log("Level Ended");
            level++;
            wavesSpawned = 0;
            HardcodeWave();
            SendWave();
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
        waves.Clear();
        if (level == 0)
        {
            waves.Add(new List<int> { 0, 0, 0 }); //first wave to spawn
            waves.Add(new List<int> { 0, 0, 0, 1 });
            waves.Add(new List<int> { 0, 0, 1, 1, 2 }); //last wave to spawn
        }
        else if (level == 1)
        {
            waves.Add(new List<int> { 0, 0, 1 }); //first wave to spawn
            waves.Add(new List<int> { 1, 1, 1, 1 });
            waves.Add(new List<int> { 1, 1, 1, 1, 1, 2 }); //last wave to spawn
        }
        else if (level == 2)
        {
            waves.Add(new List<int> { 2, 2, 1, 1, 1, 2, 2 }); //first wave to spawn
            waves.Add(new List<int> { 2, 2, 2, 2, 3 });
            waves.Add(new List<int> { 2, 2, 2, 3, 3, 3 }); //last wave to spawn
        }
        else
        {
            waves.Add(new List<int> { 0, 0, 0, 0, 0, 0 }); //first wave to spawn
            waves.Add(new List<int> { 0, 0, 0, 0 });
            waves.Add(new List<int> { 0, 0, 0 }); //last wave to spawn
        }
        
    }

    public void setSpeed(float speed) {
        Time.timeScale = speed;
    }
}
