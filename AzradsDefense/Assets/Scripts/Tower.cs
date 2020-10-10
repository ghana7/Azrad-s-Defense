using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum TypeOfTower
{
    land,
    sea,
    both
}
[RequireComponent(typeof(Health))]
public class Tower : MonoBehaviour
{
    public GameObject towerPrefab;
    public TypeOfTower towerType;
    public bool canTravel;
    public List<Vector3> travelPoints;
    float movementSpeed;
    public int price;
    public bool isDamaged;
    public bool canAttack;
    Health healthClass;

    // Start is called before the first frame update
    void Start()
    {
        isDamaged = false;
        canAttack = true;
        healthClass = GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //places the tower onto the map
    public void Place(Vector3 position, TypeOfTower type)
    {
        towerType = type;
        healthClass.maxHealth = 50;
        healthClass.health = 50;
        Instantiate(towerPrefab, position, Quaternion.identity);
    }

    //makes it so the tower is present but cant do anything with it until rebuilt
    public void DestroyTower()
    {
        isDamaged = true;
        canAttack = false;

    }

    //fix a destroyed tower
    public void Rebuild()
    {
        isDamaged = false;
        canAttack = true;
        healthClass.health = healthClass.maxHealth;
    }

    //completely get rid of a tower
    public void FullDestroy()
    {
        Destroy(this);
    }
}

