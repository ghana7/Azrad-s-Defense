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
        distanceX = 1.0f;
        distanceY = 1.0f;
        position = new Vector3(-6, 0);
        goldDropped = 10;

        enemyPath = new List<Vector3>();
        SetPath(5);
    }

    void Update()
    {
        gameObject.transform.position = position;

        direction.x = enemyPath[0].x - position.x;
        direction.y = (enemyPath[0].y - position.y) * (1 / distanceY);

        Move();
    }

    //Moving the enemies and checking if they are in the window
    public void Move()
    {
        distanceX = Mathf.Abs(position.x - enemyPath[0].x);
        distanceY = Mathf.Abs(position.y - enemyPath[0].y);

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

        position += direction * movementSpeed * Time.deltaTime;
    }

    void SetPath(int numPoints)
    {
        for (int i = 0; i < numPoints; i++)
        {
            if (i % 2 == 0)
            {
                enemyPath.Add(new Vector3(i - 3, 3));
            }
            else
            {
                enemyPath.Add(new Vector3(i - 3, -3));
            }
        }

        enemyPath.Add(new Vector3(4.5f, 0));
    }

    public void FullDestroy()
    {
        MoneyManager.instance.AddMoney(goldDropped);
        WaveManager.instance.RemoveEnemy();
        Destroy(gameObject);
    }
}
