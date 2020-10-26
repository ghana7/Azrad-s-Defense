using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LevelManager : MonoBehaviour
{
    [HideInInspector]
    public static LevelManager instance;

    //[HideInInspector]
    public Vector3 spawnLocation;
    public int level;
    public Button button;

    //pause menu
    public GameObject pause;
    public GameObject controls;

    private List<List<int>> waves;

    private int wavesSpawned;

    // This is temporary until Nick makes speed-up images for the buttons
    private Text buttonText;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        level = GlobalVariables.Level;

        SetSpeed(1);

        wavesSpawned = 0;
        waves = new List<List<int>>();
        HardcodeWave();

        // temp
        buttonText = button.GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !pause.activeSelf && !controls.activeSelf)
        {
            SetSpeed(0);
            pause.SetActive(true);
        }

        //if the player has no health, end the game
        if (WaveManager.instance.Completed() && wavesSpawned < waves.Count)
        {
            SendWave();
        }
        if(WaveManager.instance.Completed() && wavesSpawned == waves.Count)
        {
            //END THE LEVEL
            //Debug.Log("Level Ended");
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
            waves.Add(new List<int> { 3, 3, 1, 2, 2, 3 }); //first wave to spawn
            waves.Add(new List<int> { 3, 1, 2, 2 });
            waves.Add(new List<int> { 3, 3, 3 }); //last wave to spawn
        }
        
    }

    public void IncreaseSpeed()
    {
        float speed = Time.timeScale;
        speed += 1.0f;
        if(speed > 3.0f)
        {
            Time.timeScale = 1.0f;
            // Will set it to a picture eventually
            buttonText.text = ">";
        }
        else if(speed == 3.0f)
        {
            Time.timeScale = speed;
            // Will set it to a picture eventually
            buttonText.text = ">>>";
        }
        else
        {
            Time.timeScale = speed;
            // Will set it to a picture eventually
            buttonText.text = ">>";
        }
    }

    public void SetSpeed(float speed) {
        Time.timeScale = speed;
    }

    //PAUSE MENU FUNCTIONS
    public void Resume()
    {
        pause.SetActive(false);
        SetSpeed(1);
    }

    public void Controls()
    {
        pause.SetActive(false);
        controls.SetActive(true);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Back()
    {
        controls.SetActive(false);
        pause.SetActive(true);
    }
}
