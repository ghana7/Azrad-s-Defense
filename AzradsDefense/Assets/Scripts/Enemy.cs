using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float movementSpeed;
    public int goldDropped;

    // Start is called before the first frame update
    void Start()
    {
        movementSpeed = Random.Range(1, 10);
        goldDropped = 10;

    }

    void Update()
    {
       
    }
}
