using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    private uint doubloons;
    private uint doubloonsPerSecond;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        doubloons = 0;
        timer = 0.0f;

        //change to set doubleloons per second
        doubloonsPerSecond = 3;
    }

    // Update is called once per frame
    void Update()
    {
        //adds three doubloons a second
        timer += Time.deltaTime;
        if (timer >= 1.0f)
        {
            AddMoney(doubloonsPerSecond);
            timer = 0.0f;
        }
        
    }

    //adds the specified amount of money
    public void AddMoney(uint donations)
    {
        doubloons += donations;
    }

    //if the player does not have enough doubloons, returns false
    //if the player does, removes that many doubloons and returns true
    public bool RemoveMoney(uint expenditure)
    {
        if (doubloons >= expenditure)
        {
            doubloons -= expenditure;
            return true;
        }
        return false;
    }
}
