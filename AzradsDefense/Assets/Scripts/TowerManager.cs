using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    public GameObject towerPrefab;
    public List<GameObject> towers;
    Tower towerClass;
    Health healthClass;
    // Start is called before the first frame update
    void Start()
    {
        towerClass = towerPrefab.GetComponent<Tower>();
        healthClass = towerPrefab.GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < towers.Count; i++)
        {
            if(towers[i].GetComponent<Health>().health == 0)
            {
                DestroyTower(towers[i]);
            }

            if(towers[i].GetComponent<Health>().health < towers[i].GetComponent<Health>().maxHealth)
            {
                towers[i].GetComponent<Tower>().isDamaged = true;
            }
        }

        //testing the place method
        if(Input.GetMouseButtonDown(1))
        {
            Place(Camera.main.ScreenToWorldPoint(Input.mousePosition), TypeOfTower.sea);
        }
    }
    //places the tower onto the map
    public void Place(Vector3 position, TypeOfTower towerType)
    {
        towerClass.towerType = towerType;
        healthClass.maxHealth = 50;
        healthClass.health = 50;
        towers.Add(Instantiate(towerPrefab, position, Quaternion.identity));
    }

    //makes it so the tower is present but cant do anything with it until rebuilt
    public void DestroyTower(GameObject towerToDestroy)
    {
        towerClass.canAttack = false;

    }

    //fix a destroyed tower
    public void Rebuild()
    {
        towerClass.canAttack = true;
        healthClass.health = healthClass.maxHealth;
    }

    //completely get rid of a tower
    public void FullDestroy(GameObject towerToDelete)
    {
        Destroy(towerToDelete);
    }
}
