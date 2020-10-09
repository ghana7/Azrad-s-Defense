using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject enemy;
    List<GameObject> enemyList;

    GameObject mapManager;
    Map mapScript;

    float distance;

    // Start is called before the first frame update
    void Start()
    {
        enemyList = new List<GameObject>();

        mapManager = GameObject.Find("MapManager");
        mapScript = mapManager.GetComponent<Map>();

        for (int i = 0; i < 10; i++)
        {
            enemyList.Add(Instantiate(enemy, new Vector3(0, -6), Quaternion.identity));
            enemyList[i].GetComponent<Enemy>().enemyPath = mapScript.setPath();
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < enemyList.Count; i++)
        {
            for (int j = 0; j < enemyList[i].GetComponent<Enemy>().enemyPath.Count; j++)
            {
                distance = Mathf.Abs(enemyList[i].transform.position.x - enemyList[i].GetComponent<Enemy>().enemyPath[j].x);
                Debug.Log(distance);
            }
        }

        Move();
    }

    public void Move()
    {
        for (int i = 0; i < enemyList.Count; i++)
        {
            enemyList[i].transform.position += Vector3.up * enemyList[i].GetComponent<Enemy>().movementSpeed * Time.deltaTime;
        }
    }

    public void Behavior()
    {

    }

    void FullDestroy(GameObject objectToDestroy)
    {
        Destroy(objectToDestroy);
    }
}
