using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed;

    [SerializeField]
    private int goldDropped;

    List<Vector3> enemyPath;

    public GameObject mapManager;
    Map mapScript;

    // Start is called before the first frame update
    void Start()
    {
        goldDropped = 10;

        enemyPath = new List<Vector3>();

        //mapManager = GameObject.Find("MapManager");
        //mapScript = mapManager.GetComponent<Map>();

        //enemyPath = mapScript.setPath();
    }

    void Update()
    {
        Move();
    }

    //Moving the enemies and checking if they are in the window
    public void Move()
    {
        transform.position += Vector3.right * movementSpeed / 3 * Time.deltaTime;

        //Checking if the enemy goes outside the window
        if ((transform.position.x >= 7 || transform.position.x <= -7) || (transform.position.y >= 7 || transform.position.y <= -7))
        {
            //FullDestroy();
        }
    }

    public void FullDestroy()
    {
        MoneyManager.instance.AddMoney(goldDropped);
        Destroy(gameObject);
    }
}
