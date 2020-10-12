using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    // Gets set by UIShop
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

    // Set before launch
    [SerializeField]
    private Text description;

    private Tower tower;
    private string towerText;

    // Start is called before the first frame update
    void Start()
    {
        towerText = "";
        description.text = towerText;
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
        towerText = tower.GetDescription();
        description.text = towerText;
    }

    public void SetDescription(string text)
    {
        description.text = text;
    }

    public void SetDescriptionToSelection()
    {
        description.text = towerText;
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

    public bool isSelected()
    {
        return selected;
    }

    public UIShop getShop()
    {
        return selection;
    }
}
