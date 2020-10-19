using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject menu;
    public GameObject levelSelector;
    public int levelToGoTo;

    // Start is called before the first frame update
    void Start()
    {

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

    public void GoToLevel()
    {
        string level = levelToGoTo.ToString();
        level = string.Concat("Level", level);
        //Debug.Log("Going to '" + level + "'");
        SceneManager.LoadScene(level);
    }
}
