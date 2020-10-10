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

    private Tower tower;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetSelectedTower(UIShop shop)
    {
        selection = shop;
        prefab = shop.getPrefab();
        tower = prefab.GetComponent<Tower>();
        cost = tower.GetPrice();
        selected = true;
    }

    public void Buy(GameObject selection)
    {
        // set tower on the mouse to be the selected tower

        // remove money
    }

    public void Cancel()
    {
        tower = null;
        holdTower = false;
        // get rid of tower on mouse

        // refund money
    }
}
