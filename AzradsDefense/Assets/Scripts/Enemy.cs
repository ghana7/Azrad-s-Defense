using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float movementSpeed;
    public int goldDropped;
    public List<Vector3> enemyPath;

    // Start is called before the first frame update
    void Start()
    {
        enemyPath = new List<Vector3>();

        movementSpeed = 1.0f;
        goldDropped = 10;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
