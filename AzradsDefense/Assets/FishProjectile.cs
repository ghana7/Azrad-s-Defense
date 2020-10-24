using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishProjectile : Projectile
{
    private LineRenderer lr;

    [HideInInspector]
    public GameObject shooter;

    [SerializeField]
    private float startOffset;
    // Start is called before the first frame update
    void Awake()
    {
        lr = GetComponent<LineRenderer>();
    }

    public void SetStartPos()
    {
        target = shooter;
        transform.position = shooter.transform.position + (Vector3)Random.insideUnitCircle * startOffset;
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
