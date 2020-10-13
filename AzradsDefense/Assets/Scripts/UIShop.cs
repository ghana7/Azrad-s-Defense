﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIShop : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    private GameObject prefab;
    [SerializeField]
    private string information;
    [SerializeField]
    private UIManager uiManager;
    [SerializeField]
    private MoneyManager moneyManager;
    [SerializeField]
    private Button button;

    [SerializeField]
    private Text description;

    private Tower tower;
    

    // Start is called before the first frame update
    void Start()
    {
        tower = prefab.GetComponent<Tower>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!(moneyManager.GetMoney() > tower.GetPrice()))
        {
            button.GetComponent<Image>().color = Color.grey;
        }
        else
        {
            button.GetComponent<Image>().color = Color.white;
        }
    }

    public void OnClick()
    {
        if (moneyManager.GetMoney() >= tower.GetPrice())
        {
            uiManager.SetSelectedTower(this);
        }    
    }

    public GameObject getPrefab()
    {
        return prefab;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        description.text = information;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        description.text = "";
    }
}
