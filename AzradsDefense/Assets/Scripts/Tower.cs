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
    private Health healthClass;

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
    private bool isDamaged;

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

    private void Awake()
    {
        
        healthClass = gameObject.GetComponent<Health>();
        shooter = GetComponent<Shooter>();
    }
    // Start is called before the first frame update
    void Start()
    {
        popUp.SetActive(false);
        panel = popUp.GetComponent<RectTransform>();
        isDamaged = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlaced != false)
        {
            if (firstPointPlaced == true && secondPointPlaced == false)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    travelPoints.Add(new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0.0f));
                    secondPointPlaced = true;
                    toFirstPoint = true;
                    LevelManager.instance.SetSpeed(1.0f);

                    float angle = Vector3.SignedAngle(travelPoints[1] - travelPoints[0], transform.right, new Vector3(0.0f, 0.0f, 1.0f));
                    if(angle < 0.0f && angle >= -180.0f)
                    {
                        angle = -angle;
                        transform.RotateAround(transform.position, new Vector3(0.0f, 0.0f, 1.0f), angle + 90);
                    }
                    else if (angle <= 180.0f && angle > 0.0f)
                    {
                        transform.RotateAround(transform.position, new Vector3(0.0f, 0.0f, 1.0f), 90 - angle);
                    }
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
            LevelManager.instance.SetSpeed(0.0f);
        }
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

    public void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(0))
        {
            
            popUp.SetActive(true);
            panel.localPosition = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
            Debug.Log(panel.localPosition.x);
            Debug.Log(panel.localPosition.y);
        }
        
    }
}

