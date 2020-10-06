using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Health : MonoBehaviour
{
    public int health;
    public int maxHealth;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //passed value would have a negative value if losing health 
    public void ChangeHealth(int value)
    {
        health += value;
        Debug.Log("changed health by " + value);
    }
}
