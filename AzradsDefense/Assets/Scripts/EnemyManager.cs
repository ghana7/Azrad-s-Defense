using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject enemy;
    List<GameObject> enemyList;
    List<Vector3> enemyPath;

    [SerializeField]
    float timer;
    bool counter;

    public GameObject mapManager;
    Map mapScript;

    // Start is called before the first frame update
    void Start()
    {
        counter = true;
        enemyList = new List<GameObject>();
        enemyPath = new List<Vector3>();

        mapScript = mapManager.GetComponent<Map>();

        enemyPath = mapScript.setPath();
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

    //Moving the enemies and checking if they are in the window
    public void Move()
    {
        for (int i = 0; i < enemyList.Count; i++)
        {
            enemyList[i].transform.position += Vector3.up * enemyList[i].GetComponent<Enemy>().movementSpeed / 3 * Time.deltaTime;

            //Checking if the enemy goes outside the window
            if ((enemyList[i].transform.position.x >= 7 || enemyList[i].transform.position.x <= -7) || (enemyList[i].transform.position.y >= 7 || enemyList[i].transform.position.y <= -7))
            {
                FullDestroy(enemyList[i]);
            }
        }
    }

    public void Behavior()
    {

    }

    void FullDestroy(GameObject enemy)
    {
        Destroy(enemy);
        enemyList.Remove(enemy);
    }
}