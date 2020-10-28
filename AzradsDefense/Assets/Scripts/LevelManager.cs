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

    [SerializeField]
    private Text levelText;

    private List<List<int>> waves;

    private int wavesSpawned;

    [HideInInspector]
    public float savedSpeed;

    // This is temporary until Nick makes speed-up images for the buttons
    private Text buttonText;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        GlobalVariables.EnemiesDestroyed = 0;
        level = GlobalVariables.Level;
        levelText.text = "Level " + level.ToString();
        if (level == 0)
        {
            levelText.text = "Tutorial";
        }
        //Debug.Log(level);

        SetSpeed(1);
        savedSpeed = 1.0f;

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

            SceneManager.LoadScene("Level Complete");
            //level++;
            //wavesSpawned = 0;
            //HardcodeWave();
            //SendWave();
        }
    }

    private void SendWave()
    {
        if(level == 0)
        {
            switch (wavesSpawned)
            {
                case 1:
                    PopupManager.instance.TryShowPopup(1);
                    break;
                case 2:
                    PopupManager.instance.TryShowPopup(5);
                    break;
                default:
                    break;
            }
        }
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
            waves.Add(new List<int> { 0, 0, 1 });                                       //1
            waves.Add(new List<int> { 0, 0, 1 });                                       //2
            waves.Add(new List<int> { 0, 1, 1 });                                       //3
            waves.Add(new List<int> { 0, 0, 0, 0, 0, 0, 0 });                           //4
            waves.Add(new List<int> { 1, 1, 1, 1 });                                    //5
            waves.Add(new List<int> { 1, 1, 1, 1, 0, 0, 0, 0 });                        //6
            waves.Add(new List<int> { 1, 1, 1, 1, 0, 0, 0, 0, 1, 1, 1, 1 });            //7
            waves.Add(new List<int> { 1, 1, 1, 1, 1, 1, 1, 1 });                        //8 
            waves.Add(new List<int> { 1, 1, 1, 1, 2 });                                 //9
            waves.Add(new List<int> { 2, 2, 2, 2, 2, 2, 2 });                           //10
        }
        else if (level == 1)
        {
            waves.Add(new List<int> { 0, 0, 0 });                                   //1
            waves.Add(new List<int> { 0, 0, 0, 1, 1 });                             //2
            waves.Add(new List<int> { 0, 0, 0, 1, 1, 1 });                          //3
            waves.Add(new List<int> { 2, 2, 2, 2, 1, 1, 1 });                       //4
            waves.Add(new List<int> { 3, 1, 1, 0, 0, 0, 0, 1, 1 });                 //5
            waves.Add(new List<int> { 2, 2, 2, 2, 2, 2, 2, 2, 2 });                 //6
            waves.Add(new List<int> { 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0 });     //7
            waves.Add(new List<int> { 3, 1, 1, 1, 2, 2, 0, 0, 0, 0, 0, 0 });        //8
            waves.Add(new List<int> { 3, 2, 2, 2, 2, 2, 2, 1, 1, 1, 1 });           //9
            waves.Add(new List<int> { 3, 3, 3, 3, 3, 3, 3 });                       //10
        }
        else if (level == 2)
        {
            waves.Add(new List<int> { 0, 0, 0 });                                   //1
            waves.Add(new List<int> { 0, 0, 1 });                                   //2
            waves.Add(new List<int> { 1, 0, 0 });                                   //3
            waves.Add(new List<int> { 2, 0, 0, 0 });                                //4
            waves.Add(new List<int> { 0, 0, 0, 0, 0, 0, 0 });                       //5
            waves.Add(new List<int> { 2, 2, 2, 2 });                                //6
            waves.Add(new List<int> { 1, 1, 1, 1, 0, 0, 0, 0 });                    //7
            waves.Add(new List<int> { 1, 1, 1, 1, 0, 0, 0, 0, 1, 1, 1, 1 });        //8
            waves.Add(new List<int> { 1, 1, 1, 1, 1, 1, 1, 1 });                    //9
            waves.Add(new List<int> { 0, 0, 2, 2, 3 });                             //10
            waves.Add(new List<int> { 0, 0 });                                      //11
            waves.Add(new List<int> { 0, 0, 0 });                                   //12
            waves.Add(new List<int> { 1, 1, 1 });                                   //13
            waves.Add(new List<int> { 2, 2, 2, 0, 0 });                             //14
            waves.Add(new List<int> { 3 });                                         //15
        }
        else
        {
            waves.Add(new List<int> { 0, 0, 0 });                                   //1
            waves.Add(new List<int> { 0, 0, 1 });                                   //2
            waves.Add(new List<int> { 1, 0, 0 });                                   //3
            waves.Add(new List<int> { 2, 0, 0, 0 });                                //4
            waves.Add(new List<int> { 0, 0, 0, 0, 0, 0, 0 });                       //5
            waves.Add(new List<int> { 2, 2, 2, 2 });                                //6
            waves.Add(new List<int> { 1, 1, 1, 1, 0, 0, 0, 0 });                    //7
            waves.Add(new List<int> { 1, 1, 1, 1, 0, 0, 0, 0, 1, 1, 1, 1 });        //8
            waves.Add(new List<int> { 1, 1, 1, 1, 1, 1, 1, 1 });                    //9
            waves.Add(new List<int> { 0, 0, 2, 2, 3 });                             //10
            waves.Add(new List<int> { 0, 0, 0 });                                   //11
            waves.Add(new List<int> { 0, 0, 1 });                                   //12
            waves.Add(new List<int> { 1, 0, 0 });                                   //13
            waves.Add(new List<int> { 2, 0, 0, 0 });                                //14
            waves.Add(new List<int> { 0, 0, 0, 0, 0, 0, 0 });                       //15
            waves.Add(new List<int> { 2, 2, 2, 2 });                                //16
            waves.Add(new List<int> { 1, 1, 1, 1, 0, 0, 0, 0 });                    //17
            waves.Add(new List<int> { 1, 1, 1, 1, 0, 0, 0, 0, 1, 1, 1, 1 });        //18
            waves.Add(new List<int> { 1, 1, 1, 1, 1, 1, 1, 1 });                    //19
            waves.Add(new List<int> { 0, 0, 2, 2, 3 });                             //20
        }
        
    }

    public void IncreaseSpeed()
    {
        if (Time.timeScale > 0.0f)
        {
            float speed = Time.timeScale;
            speed += 1.0f;
            Debug.Log(speed);
            if (speed > 3.0f)
            {
                savedSpeed = 1.0f;
                Time.timeScale = 1.0f;
                // Will set it to a picture eventually
                buttonText.text = ">";
            }
            else if (speed == 3.0f)
            {
                savedSpeed = speed;
                Time.timeScale = speed;
                // Will set it to a picture eventually
                buttonText.text = ">>>";
            }
            else
            {
                savedSpeed = speed;
                Time.timeScale = speed;
                // Will set it to a picture eventually
                buttonText.text = ">>";
            }
        }
    }

    public void SetSpeed(float speed) {
        Time.timeScale = speed;
    }

    //PAUSE MENU FUNCTIONS
    public void Resume()
    {
        pause.SetActive(false);
        SetSpeed(savedSpeed);
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

    //
}
