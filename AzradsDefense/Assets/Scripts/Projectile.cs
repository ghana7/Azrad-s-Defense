using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    /// <summary>
    /// The GameObject that is the target of the projectile
    /// </summary>
    public GameObject target;
    /// <summary>
    /// The amount of damage dealt by the projectile
    /// </summary>
    [SerializeField]
    private int damage;
    /// <summary>
    /// How fast the projectile moves, in units per second
    /// </summary>
    [SerializeField]
    protected float speed;

    [SerializeField]
    private GameObject explodeParticleWrapper;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null)
        {
            DetachParticles();
            Destroy(gameObject);
        } else
        {
            Move();

        }
    }

    /// <summary>
    /// Behavior for when a projectile hits its target
    /// </summary>
    protected virtual void Hit()
    {
        target.GetComponent<Health>().ChangeHealth(-damage);
        Debug.Log("hit");
        DetachParticles();
        Destroy(gameObject);
    }

    /// <summary>
    /// Movement behavior for a projectile on each frame
    /// </summary>
    protected virtual void Move()
    {
        Vector3 displacement = target.transform.position - transform.position;
        if (displacement.sqrMagnitude <= speed * Time.deltaTime * speed * Time.deltaTime)
        {
            Hit();
        } else
        {
            transform.position += displacement.normalized * speed * Time.deltaTime;
        }
    }

    private void DetachParticles()
    {
        foreach (ParticleSystem ps in GetComponentsInChildren<ParticleSystem>())
        {
            ParticleSystem.EmissionModule em = ps.emission;
            em.rateOverTime = 0;
        }
        if(explodeParticleWrapper != null)
        {
            explodeParticleWrapper.GetComponent<ParticleSystem>().Play();

        }
        transform.DetachChildren();

    }
}
