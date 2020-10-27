using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public static MenuManager instance;

    public GameObject menu;
    public GameObject levelSelector;

    [SerializeField]
    private bool displayEnemyDeaths;

    // Start is called before the first frame update
    void Start()
    {
        if (displayEnemyDeaths)
        {
            //Debug.Log(GlobalVariables.EnemiesDestroyed);

            GetComponentInChildren<Text>().text = "You destroyed " + GlobalVariables.EnemiesDestroyed.ToString() + " enemies!";
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void EnableDisableLevelSelector()
    {
        menu.SetActive(!menu.activeSelf);
        levelSelector.SetActive(!menu.activeSelf);
    }

    public void ExitGame()
    {
        //DOES NOT WORK IN EDITOR (needs to be tested during build)
        Debug.Log("READ -> The Application.Quit() function does not work in the editor and must be tested after building");
        Application.Quit();
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void NextLevel()
    {
        GlobalVariables.Level++;
        if (GlobalVariables.Level <= 3)
        {
            SceneManager.LoadScene("Level");
        }
        else
        {
            SceneManager.LoadScene("Credits");
        }
    }

    public void GoToCredits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void RedoLevel()
    {
        SceneManager.LoadScene("Level");
    }

    public void GoToLevel(int levelToGoTo)
    {
        //string level = levelToGoTo.ToString();
        //level = string.Concat("Level", level);
        ////Debug.Log("Going to '" + level + "'");
        //SceneManager.LoadScene(level);
        GlobalVariables.Level = levelToGoTo;
        SceneManager.LoadScene("Level");
    }
}
