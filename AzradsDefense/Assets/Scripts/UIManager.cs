using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private GameObject towerSelected;
    private int cost;
    private bool selected;
    private GameObject towerOnMouse;
    private bool holdTower;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetSelectedTower(GameObject selection)
    {
        towerSelected = selection;
    }

    public void Buy(GameObject selection)
    {
        // set tower on the mouse to be the selected tower

        // remove money
    }

    public void Cancel()
    {
        towerSelected = null;

        // get rid of tower on mouse

        // refund money
    }
}
