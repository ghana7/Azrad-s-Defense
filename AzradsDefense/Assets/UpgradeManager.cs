using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeManager : MonoBehaviour
{
    public static UpgradeManager instance;

    [SerializeField]
    private Button upgradeButton;
    [SerializeField]
    private Text buttonText;

    private Tower towerToUpgrade;
    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if(towerToUpgrade == null)
        {
            upgradeButton.interactable = false;
        } else
        {
            upgradeButton.interactable = MoneyManager.instance.GetMoney() >= towerToUpgrade.upgradeCost;
        }
        
    }
    public void SetShipToUpgrade(Tower tower)
    {
        if(tower != null)
        {
            towerToUpgrade = tower;
            if (towerToUpgrade.upgradeCost == 0)
            {
                buttonText.text = "Fully Upgraded";
            }
            else
            {
                buttonText.text = "Upgrade      " + towerToUpgrade.upgradeCost + "g";
            }
        }
        
    }

    public void Upgrade()
    {
        if(towerToUpgrade != null && MoneyManager.instance.RemoveMoney(towerToUpgrade.upgradeCost))
        {
            SetShipToUpgrade(towerToUpgrade.Upgrade());
            
        }
    }
}
