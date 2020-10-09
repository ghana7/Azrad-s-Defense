using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    List<Vector3> pathToFollow;
    List<GameObject> landObjects;

    // Start is called before the first frame update
    void Start()
    {
        pathToFollow = new List<Vector3>();
        landObjects = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        //This really doesn't do anything right now
        for (int i = 0; i < pathToFollow.Count; i++)
        {
            IsWater(pathToFollow[i]);
        }
    }

    bool IsWater(Vector3 testPoint)
    {
        return true;
    }

    public List<Vector3> setPath()
    {
        for (int i = 0; i < 10; i++)
        {
            pathToFollow.Add(new Vector3(0, (i - 5)));
        }

        return pathToFollow;

    }
}
