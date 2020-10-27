using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour
{
    [HideInInspector]
    public static MoneyManager instance;

    [SerializeField]
    private int startingDoubloons;

    private int doubloons;
    private int doubloonsPerSecond;
    private float timer;

    [SerializeField]
    private Text doubloonsText;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        doubloons = startingDoubloons;
        timer = 0.0f;

        //change to set doubleloons per second
        doubloonsPerSecond = 3;

        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        //adds three doubloons a second
        timer += Time.deltaTime;
        if (timer >= 1.0f)
        {
            AddMoney(doubloonsPerSecond);
            timer -= 1.0f;
        }
        
    }

    //adds the specified amount of money
    public void AddMoney(int donations)
    {
        doubloons += donations;
        doubloonsText.text = doubloons.ToString();
    }

    //if the player does not have enough doubloons, returns false
    //if the player does, removes that many doubloons and returns true
    public bool RemoveMoney(int expenditure)
    {
        if (doubloons >= expenditure)
        {
            doubloons -= expenditure;

            doubloonsText.text = doubloons.ToString();
            return true;
        }
        return false;
    }

    public int GetMoney()
    {
        return doubloons;
    }
}
