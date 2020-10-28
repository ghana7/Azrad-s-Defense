using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupButton : MonoBehaviour
{
    [SerializeField]
    private Popup popup;

    private void OnMouseDown()
    {
        popup.Close();
    }
}
