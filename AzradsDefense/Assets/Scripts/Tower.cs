using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum TypeOfTower
{
    land,
    sea,
    both
}
[RequireComponent(typeof(Health))]
public class Tower : MonoBehaviour
{
    [SerializeField]
    private GameObject towerPrefab;

    [SerializeField]
    private TypeOfTower towerType;

    [SerializeField]
    private bool canTravel;

    [SerializeField]
    private bool firstPointPlaced;

    [SerializeField]
    private bool secondPointPlaced;

    [SerializeField]
    private bool toFirstPoint;

    [SerializeField]
    private List<Vector3> travelPoints;

    [SerializeField]
    private float movementSpeed;

    [SerializeField]
    private int price;

    [SerializeField]
    private string description;

    [SerializeField]
    private float timer;

    [SerializeField]
    private GameObject popUp;
    RectTransform panel;

    [SerializeField]
    bool isPlaced;

    Tower placedTowerClass;
    private Shooter shooter;

    [SerializeField]
    private GameObject targetPrefab;
    private GameObject tempTarget;

    [SerializeField]
    private GameObject upgradePrefab;
    public int upgradeCost;


    private void Awake()
    {
        shooter = GetComponent<Shooter>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlaced != false && canTravel == true)
        {
            if (firstPointPlaced == true && secondPointPlaced == false)
            {
                shooter.rangeCylInstance.SetActive(true);
                tempTarget.transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0.0f);
                if (Input.GetMouseButtonDown(0) && ((Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - (Vector2)travelPoints[0]).sqrMagnitude <= shooter.range * 2)
                {
                    travelPoints.Add(new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0.0f));
                    secondPointPlaced = true;
                    toFirstPoint = true;

                    float angle = Vector3.SignedAngle(travelPoints[1] - travelPoints[0], transform.right, new Vector3(0.0f, 0.0f, 1.0f));
                    if (angle < 0.0f && angle >= -180.0f)
                    {
                        angle = -angle;
                        transform.RotateAround(transform.position, new Vector3(0.0f, 0.0f, 1.0f), angle + 90);
                    }
                    else if (angle <= 180.0f && angle > 0.0f)
                    {
                        transform.RotateAround(transform.position, new Vector3(0.0f, 0.0f, 1.0f), 90 - angle);
                    }
                    shooter.rangeCylInstance.SetActive(false);
                    Destroy(tempTarget);
                    LevelManager.instance.SetSpeed(1.0f);
                }
            }
        
            if (secondPointPlaced == true && canTravel == true)
            {
                if (toFirstPoint == true && timer <= 2.5f)
                {
                    transform.position = Vector3.Lerp(travelPoints[0], travelPoints[1], timer / 2.5f);
                    timer += Time.deltaTime;
                }
                else if (toFirstPoint == false && timer <= 2.5f)
                {
                    transform.position = Vector3.Lerp(travelPoints[1], GetComponent<Tower>().travelPoints[0], timer / 2.5f);
                    timer += Time.deltaTime;
                }
                else
                {
                    timer = 0.0f;
                    toFirstPoint = !toFirstPoint;
                    transform.RotateAround(transform.position, new Vector3(0.0f, 0.0f, 1.0f), 180);
                }
            }
        }
    }

    //places the tower onto the map
    public void Place(Vector3 position)
    {
        GameObject placed = Instantiate(towerPrefab, position, Quaternion.identity);
        placed.GetComponent<Shooter>().canShoot = true;
        if(placed.GetComponent<Tower>().canTravel == true)
        {
            placed.GetComponent<Tower>().travelPoints.Clear();
            placed.GetComponent<Tower>().firstPointPlaced = true;
            placed.GetComponent<Tower>().travelPoints.Add(position);
            placed.GetComponent<Tower>().isPlaced = true;
            placed.GetComponent<Tower>().tempTarget = Instantiate(targetPrefab, new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0.0f), Quaternion.identity);
            LevelManager.instance.SetSpeed(0.0f);
        }
    }

    public void SetCanAttack(bool val)
    {
        shooter.canShoot = val;
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

    public Tower Upgrade()
    {
        if(upgradePrefab != null)
        {
            GameObject upgradedTower = Instantiate(upgradePrefab);
            Tower newTower = upgradedTower.GetComponent<Tower>();

            newTower.firstPointPlaced = firstPointPlaced;
            newTower.secondPointPlaced = secondPointPlaced;
            newTower.toFirstPoint = toFirstPoint;
            newTower.travelPoints = travelPoints;
            newTower.timer = timer;
            newTower.isPlaced = isPlaced;
            newTower.canTravel = canTravel;
            newTower.transform.rotation = transform.rotation;

            Shooter newShooter = upgradedTower.GetComponent<Shooter>();
            newShooter.CloneData(GetComponent<Shooter>());
            Destroy(gameObject);
            return newTower;
        }
        return null;
    }

    public void OnMouseDown()
    {
        float sqrDist = ((Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - (Vector2)transform.position).sqrMagnitude;
        if(sqrDist <= 0.25f)
        {
            Debug.Log("selected");
            UpgradeManager.instance.SetShipToUpgrade(this);
        }
    }
}

