﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LivesManager : MonoBehaviour
{
    [HideInInspector]
    public static LivesManager instance;

    [SerializeField]
    private int lives;

    [SerializeField]
    private int startingLives;

    [SerializeField]
    private Text livesText;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        lives = startingLives;
    }
    public void ChangeLives(int amount)
    {
        lives += amount;
        livesText.text = lives.ToString();
        if(lives <= 0)
        {
            SceneManager.LoadScene("Game Over");
        }
    }

    public int GetLives()
    {
        return lives;
    }
}
