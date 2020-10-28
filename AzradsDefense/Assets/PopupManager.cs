using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupManager : MonoBehaviour
{
    public static PopupManager instance;
    
    [SerializeField]
    private GameObject popupPrefab;
    [SerializeField]
    private string[] popups;
    [SerializeField]
    private Vector2[] targetLocations;

    private bool[] shownStatuses;


    private void Awake()
    {
        instance = this;
        shownStatuses = new bool[popups.Length];
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            TryShowPopup(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            TryShowPopup(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            TryShowPopup(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            TryShowPopup(3);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            TryShowPopup(4);
        }
    }

    public void TryShowPopup(int index)
    {
        if (popups.Length > index)
        {
            if (!shownStatuses[index])
            {
                shownStatuses[index] = true;

                GameObject popupInstance = Instantiate(popupPrefab);
                popupInstance.GetComponent<Popup>().SetText(popups[index]);
                popupInstance.GetComponent<Popup>().SetTarget(targetLocations[index]);
            }
        }
    }
}
