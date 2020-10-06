using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum TypeOfTower
{
    land,
    sea,
    both
}
public class Tower : MonoBehaviour
{
    public TypeOfTower towerType;
    public bool canTravel;
    public List<Vector3> travelPoints;
    float movementSpeed;
    public int price;
    public bool isDamaged;
    public bool canAttack;

    // Start is called before the first frame update
    void Start()
    {
        isDamaged = false;
        canAttack = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
