using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField]
    private GameObject projectilePrefab;

    [SerializeField]
    private float range;

    [SerializeField]
    private float shotsPerSecond;
    


    private List<GameObject> targetsInRange;
    private CircleCollider2D rangeCollider;

    private void Awake()
    {
        rangeCollider = GetComponent<CircleCollider2D>();

        targetsInRange = new List<GameObject>();
    }
    // Start is called before the first frame update
    void Start()
    {
        rangeCollider.radius = range;   
    }

    // Update is called once per frame
    void Update()
    {
        DebugMove(3);
        foreach(GameObject g in targetsInRange)
        {
            Debug.DrawLine(transform.position, g.transform.position);
        }
    }

    private void DebugMove(float speed)
    {
        if(Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.down * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.GetComponent<Health>() != null)
        {
            targetsInRange.Add(other.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Health>() != null)
        {
            targetsInRange.Remove(other.gameObject);
        }
    }

    /// <summary>
    /// Finds the current target to fire at
    /// 
    /// Probably should be the furthest forward enemy
    /// </summary>
    private void GetTarget()
    {
        
    }

    /// <summary>
    /// Rotates to face the current target
    /// </summary>
    private void Aim()
    {

    }

    /// <summary>
    /// Fires a projectile at the current target
    /// </summary>
    private void Shoot()
    {

    }

}
