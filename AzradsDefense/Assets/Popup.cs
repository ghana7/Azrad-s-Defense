using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Popup : MonoBehaviour
{
    [SerializeField]
    private TextMeshPro tmp;
    [SerializeField]
    private GameObject target;
    private void Awake()
    {
        LevelManager.instance.SetSpeed(0);
    }
    public void SetText(string text)
    {
        tmp.text = text;
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Close();
        }
    }
    public void SetTarget(Vector2 position)
    {
        if(position.x <= -1000)
        {
            target.SetActive(false);
        }
        target.transform.position = (Vector3)position + new Vector3(0, 0, -2);
    }

    public void Close()
    {

        //LevelManager.instance.SetSpeed(1);
        LevelManager.instance.SetSpeed(LevelManager.instance.savedSpeed);
        Destroy(gameObject);
    }

}
