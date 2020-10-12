using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField]
    protected GameObject[] projectilePrefabs;

    [SerializeField]
    private GameObject cannonObject;

    [SerializeField]
    private float range;

    [SerializeField]
    private float shotsPerSecond;
    private float secondsPerShot;
    private float shotCooldown;

    private bool isEnemy;

    protected GameObject currentTarget;

    private List<GameObject> targetsInRange;
    private CircleCollider2D rangeCollider;

    private void Awake()
    {
        rangeCollider = GetComponent<CircleCollider2D>();

        targetsInRange = new List<GameObject>();


        isEnemy = GetComponent<Enemy>() != null;
    }
    // Start is called before the first frame update
    void Start()
    {
        rangeCollider.radius = range;
        secondsPerShot = 1 / shotsPerSecond;
    }

    // Update is called once per frame
    void Update()
    {
        DebugMove(3);
        Aim();
        shotCooldown += Time.deltaTime;
        if(shotCooldown >= secondsPerShot)
        {
            shotCooldown = secondsPerShot;
        }
        if (currentTarget != null)
        {
            if(shotCooldown >= secondsPerShot)
            {
                Shoot(0);
                shotCooldown -= secondsPerShot;
            }
        }

        foreach (GameObject g in targetsInRange)
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
        //check to make sure object has a health script and can be shot
        if(other.gameObject.GetComponent<Health>() != null)
        {
            //next, check that the object is of the opposite type of the shooter
            //i.e., towers only target enemies, enemies only target towers
            if (isEnemy && other.gameObject.GetComponent<Tower>() || !isEnemy && other.gameObject.GetComponent<Enemy>())
            {
                targetsInRange.Add(other.gameObject);
                if (currentTarget == null)
                {
                    UpdateTarget();
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Health>() != null)
        {
            //next, check that the object is of the opposite type of the shooter
            //i.e., towers only target enemies, enemies only target towers
            if (isEnemy && other.gameObject.GetComponent<Tower>() || !isEnemy && other.gameObject.GetComponent<Enemy>())
            {
                targetsInRange.Remove(other.gameObject);
                if (other.gameObject == currentTarget)
                {
                    UpdateTarget();
                }
            }
        }
    }

    /// <summary>
    /// Finds the current target to fire at
    /// 
    /// Probably should be the furthest forward enemy
    /// </summary>
    private void UpdateTarget()
    {
        if(targetsInRange.Count > 0)
        {
            currentTarget = targetsInRange[0];
        } else
        {
            currentTarget = null;
        }
    }

    /// <summary>
    /// Rotates to face the current target
    /// </summary>
    private void Aim()
    {
        if (currentTarget != null)
        {
            if (cannonObject != null)
            {
                cannonObject.transform.SetPositionAndRotation(cannonObject.transform.position, Quaternion.LookRotation(Vector3.forward, Vector3.Cross(currentTarget.transform.position - transform.position, transform.forward)));
            } else
            {
                transform.SetPositionAndRotation(transform.position, Quaternion.LookRotation(Vector3.forward, Vector3.Cross(Vector3.forward, currentTarget.transform.position - transform.position)));
            }
            
        }
    }

    /// <summary>
    /// Fires a projectile at the current target
    /// </summary>
    public virtual void Shoot(int index)
    {
        if(projectilePrefabs.Length > index)
        {
            GameObject projectileInstance = Instantiate(projectilePrefabs[index]);
            projectileInstance.transform.position = transform.position;
            projectileInstance.GetComponent<Projectile>().target = currentTarget;
        }
    }

}
