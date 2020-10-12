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
    private GameObject pathNode;
    
    [SerializeField]
    List<Vector3> enemyPath;

    [SerializeField]
    Vector3 position;

    [SerializeField]
    Vector3 direction;

    float distanceX;
    float distanceY;

    // Start is called before the first frame update
    void Start()
    {
        // Setting the distance to a number on start to prevent NaN errors
        distanceX = 1.0f;
        distanceY = 1.0f;

        position = new Vector3(-6, 0);
        goldDropped = 10;

        //Instantiating and setting the enemy path
        enemyPath = new List<Vector3>();
        SetPath(6);
    }

    void Update()
    {
        // Updating the gameobjects position every frame
        gameObject.transform.position = position;

        // Updating the direction every frame
        direction.x = enemyPath[0].x - position.x;
        direction.y = (enemyPath[0].y - position.y) * (1 / distanceY);

        // Moving the enemy every frame
        Move();
    }

    //Moving the enemies and checking if they are in the window
    public void Move()
    {
        // Setting distance between the position of the enemy and the next path node
        distanceX = Mathf.Abs(position.x - enemyPath[0].x);
        distanceY = Mathf.Abs(position.y - enemyPath[0].y);

        // Checking if the enemy is close enough to the current path node to move to the next
        if (distanceX <= 0.25f && distanceY <= 0.25f)
        {
            if (enemyPath.Count > 1)
            {
                enemyPath.RemoveAt(0);
            }
            else
            {
                // Subtract overall player health here

                // destroy the enemy
                WaveManager.instance.RemoveEnemy();
                Destroy(gameObject);
            }
        }

        // Changing the position of the enemy based on the direction to the next point and their movement speed
        position += direction * movementSpeed * Time.deltaTime;
    }

    // Setting a path for the enemies to follow based on the number of points passed in
    void SetPath(int numPoints)
    {
        // Checking if the path has too many nodes or too few nodes
        if (numPoints > 8)
        {
            numPoints = 8;
        }

        if (numPoints < 4)
        {
            numPoints = 4;
        }

        for (int i = 0; i < numPoints; i++)
        {
            //Checking if i is even or odd to determine if the paths y-value is positive or negative 
            if (i % 2 == 0)
            {
                enemyPath.Add(new Vector3((numPoints / 2) - (numPoints - i), 3));
            }
            else
            {
                enemyPath.Add(new Vector3((numPoints / 2) - (numPoints - i), -3));
            }
        }

        enemyPath.Add(new Vector3(4.5f, 0));

        DrawPath();
    }

    //Drawing the path that the enmies will take (just the nodes for now)
    void DrawPath()
    {
        for (int i = 0; i < enemyPath.Count; i++)
        {
            Instantiate(pathNode, enemyPath[i], Quaternion.identity);
        }
    }

    // Full destroy method to reward gold to the player, remove the enemy from the list of enemies, and destroy the gameobject
    public void FullDestroy()
    {
        MoneyManager.instance.AddMoney(goldDropped);
        WaveManager.instance.RemoveEnemy();
        Destroy(gameObject);
    }
}
