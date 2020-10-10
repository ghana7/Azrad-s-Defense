using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        counter = true;
        enemyList = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyList.Count < 10 && timer >= 1.5f)
        {
            enemyList.Add(Instantiate(enemy, new Vector3(Random.Range(-3, 3), -6), Quaternion.identity));
            timer = 0.0f;
        }

        if (counter)
        {
            timer += 0.005f;
        }

        if (enemyList.Count == 10)
        {
            counter = false;
        }

        Move();
    }

    public void Behavior()
    {

    }
}