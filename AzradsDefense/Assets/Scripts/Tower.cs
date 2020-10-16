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
    private Health healthClass;

    [SerializeField]
    private GameObject towerPrefab;

    [SerializeField]
    private TypeOfTower towerType;

    [SerializeField]
    private bool canTravel;

    [SerializeField]
    private List<Vector3> travelPoints;

    [SerializeField]
    private float movementSpeed;

    [SerializeField]
    private int price;

    [SerializeField]
    private bool isDamaged;

    [SerializeField]
    private string description;

    private Shooter shooter;

    private void Awake()
    {

        healthClass = gameObject.GetComponent<Health>();
        shooter = GetComponent<Shooter>();
    }
    // Start is called before the first frame update
    void Start()
    {
        isDamaged = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //places the tower onto the map
    public void Place(Vector3 position)
    {
        GameObject placed = Instantiate(towerPrefab, position, Quaternion.identity);
        placed.GetComponent<Shooter>().canShoot = true;
    }

    //makes it so the tower is present but cant do anything with it until rebuilt
    public void DestroyTower()
    {
        isDamaged = true;
        shooter.canShoot = false;

    }

    public void SetCanAttack(bool val)
    {
        shooter.canShoot = val;
    }

    //fix a destroyed tower
    public void Rebuild()
    {
        isDamaged = false;
        shooter.canShoot = true;
        healthClass.health = healthClass.maxHealth;
    }

    //completely get rid of a tower
    public void FullDestroy()
    {
        Destroy(gameObject);
    }

    //return price of tower
    public int GetPrice()
    {
        return price;
    }

    //return description of tower
    public string GetDescription()
    {
        return description;
    }

}

