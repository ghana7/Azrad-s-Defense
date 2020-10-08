using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    float movementSpeed;
    List<Vector3> enemyPath;
    int goldDropped;

    // Start is called before the first frame update
    void Start()
    {
        movementSpeed = 2.0f;
        goldDropped = 10;

        for (int i = 0; i < 10; i++)
        {

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Move()
    {

    }

    void Behavior()
    {

    }

    void FullDestroy()
    {

    }

    float ProgressAmount()
    {
        return 1.0f;
    }
}
