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
    private float subProgress;
    void Awake()
    {
        currentNode = 1;
        subProgress = 0;
        transform.position = Map.instance.activePath[0];
        PopupManager.instance.TryShowPopup(2);
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
        Vector3 fullDist = Map.instance.activePath[currentNode] - Map.instance.activePath[currentNode - 1];
        subProgress = 1.0f - displacement.magnitude / fullDist.magnitude;
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
        if(transform.position.x >= -7)
        {
            PopupManager.instance.TryShowPopup(0);
        }
    }

    // Full destroy method to reward gold to the player, remove the enemy from the list of enemies, and destroy the gameobject
    public void FullDestroy()
    {
        GlobalVariables.EnemiesDestroyed++;
        MoneyManager.instance.AddMoney(goldDropped);
        WaveManager.instance.RemoveEnemy();
        Destroy(gameObject);
    }
    public float Progress()
    {
        return currentNode + subProgress;
    }
    public float Strength()
    {
        return livesLost;
    }
}
