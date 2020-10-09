using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject enemy;
    List<GameObject> enemyList;
    List<Vector3> enemyPath;

    GameObject mapManager;
    Map mapScript;

    // Start is called before the first frame update
    void Start()
    {
        enemyList = new List<GameObject>();
        enemyPath = new List<Vector3>();

        mapManager = GameObject.Find("MapManager");
        mapScript = mapManager.GetComponent<Map>();

        for (int i = 0; i < 10; i++)
        {
            enemyList.Add(Instantiate(enemy, new Vector3(Random.Range(-3, 3), -6), Quaternion.identity));
        }

        enemyPath = mapScript.setPath();
    }

    // Update is called once per frame
    void Update()
    {
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