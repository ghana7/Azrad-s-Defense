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
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {

    }

    private void OnCollisionExit2D(Collision2D collision)
    {

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
