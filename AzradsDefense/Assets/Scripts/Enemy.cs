using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed;

    [SerializeField]
    private int goldDropped;

    [SerializeField]
    private int livesLost;

    private int currentNode;

    void Awake()
    {
        currentNode = 1;

        transform.position = Map.instance.activePath[0];  
    }

    void Update()
    {

        // Moving the enemy every frame
        Move();
    }

    //Moving the enemies and checking if they are in the window
    public void Move()
    {
        Vector3 displacement = Map.instance.activePath[currentNode] - transform.position;
        if (displacement.sqrMagnitude <= movementSpeed * movementSpeed * Time.deltaTime * Time.deltaTime)
        {
            currentNode++;
            if (currentNode >= Map.instance.activePath.Length)
            {
                WaveManager.instance.RemoveEnemy();
                LivesManager.instance.ChangeLives(-livesLost);
                Destroy(gameObject);
            } 
            else
            {
                //recalculate displacement for new next node
                displacement = Map.instance.activePath[currentNode] - transform.position;
            }  
        }
        Vector3 direction = displacement.normalized;
        transform.up = -direction;
        transform.position += direction * movementSpeed * Time.deltaTime;
    }

    // Full destroy method to reward gold to the player, remove the enemy from the list of enemies, and destroy the gameobject
    public void FullDestroy()
    {
        MoneyManager.instance.AddMoney(goldDropped);
        WaveManager.instance.RemoveEnemy();
        Destroy(gameObject);
    }
}
