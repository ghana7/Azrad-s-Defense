using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairProjectile : Projectile
{
    private LineRenderer lr;

    [HideInInspector]
    public GameObject shooter;
    // Start is called before the first frame update
    void Awake()
    {
        lr = GetComponent<LineRenderer>();
    }

    protected override void Move()
    {
        base.Move();
        lr.SetPositions(new Vector3[] { transform.position, shooter.transform.position });
    }
    public override void Hit(GameObject obj)
    {
        shooter.GetComponent<Shooter>().Shoot(1);
        Destroy(gameObject);
    }
}
