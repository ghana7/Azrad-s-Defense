using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public static Map instance;

    public Vector3[] activePath;
    private List<GameObject> landObjects;

    [System.Serializable]
    private class Path
    {
        public Vector3[] path;
    }

    [SerializeField]
    private Path[] paths;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        activePath = paths[0].path;
        landObjects = new List<GameObject>();
        DrawMap();
    }

    // Update is called once per frame
    void Update()
    {
        //This really doesn't do anything right now
        for (int i = 0; i < activePath.Length; i++)
        {
            Debug.DrawLine(activePath[i] - Vector3.right, activePath[i] + Vector3.right);
            Debug.DrawLine(activePath[i] - Vector3.up, activePath[i] + Vector3.up);
            IsWater(activePath[i]);
        }
    }

    bool IsWater(Vector3 testPoint)
    {
        return true;
    }

    public void SetLevel(int level) {
        if(paths.Length > level)
        {
            activePath = paths[level].path;
            landObjects = new List<GameObject>();
            DrawMap();
        } else
        {
            activePath = paths[0].path;
            landObjects = new List<GameObject>();
            DrawMap();
        }
    }
    void DrawMap()
    {
        LineRenderer lr = GetComponent<LineRenderer>();
        lr.positionCount = activePath.Length;
        Vector3[] zFixedPositions = new Vector3[lr.positionCount];
        for(int i = 0; i < zFixedPositions.Length; i++)
        {
            zFixedPositions[i] = new Vector3(activePath[i].x, activePath[i].y, 9);
        }
        lr.SetPositions(zFixedPositions);
    }
}
