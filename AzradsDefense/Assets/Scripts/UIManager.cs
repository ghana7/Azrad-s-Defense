using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab;
    [SerializeField]
    private int cost;
    [SerializeField]
    private bool selected;
    [SerializeField]
    private GameObject towerOnMouse;
    [SerializeField]
    private bool holdTower;
    [SerializeField]
    private UIShop selection;
    [SerializeField]
    private MoneyManager moneyManager;

    private Tower tower;

    //keeps track if a tower is being held by the mouse
    private bool held;

    //holds the tower held by the mouse
    private Tower heldTower;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if a tower is selected
        if (holdTower == true)
        {
            //creates the tower to attach to the mouse and makes sure only one is created
            if(held == false)
            {
                heldTower = Instantiate(tower, new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0.0f), Quaternion.identity);
                held = true;
            }
            else
            {
                //makes the tower follow the mouse
                heldTower.transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0.0f);
            }
            
            //if left mouse button clicked, buy the tower as long as you have enough money
            if(Input.GetMouseButton(0) && moneyManager.GetMoney() >= tower.GetPrice())
            {
                Buy();
            }
            //if right mouse button clicked, cancels the hover
            else if(Input.GetMouseButton(1))
            {
                Cancel();
            }
        }
    }

    public void SetSelectedTower(UIShop shop)
    {
        selection = shop;
        prefab = shop.getPrefab();
        tower = prefab.GetComponent<Tower>();
        cost = tower.GetPrice();
        holdTower = true;
        selected = true;
    }

    public void Buy()
    {
        //place tower
        tower.Place(new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0.0f));
        //remove tower
        moneyManager.RemoveMoney(tower.GetPrice());
    }

    public void Cancel()
    {
        //removes tower attached to mouse
        heldTower.FullDestroy();

        //resets tower selected
        tower = null;
        holdTower = false;
        held = false;
    }
}
