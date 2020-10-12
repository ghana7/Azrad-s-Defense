using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AOEShooter : Shooter
{
    [SerializeField]
    private GameObject particleWrapper;

    public override void Shoot(int index)
    {
        for (int i = 0; i < targetsInRange.Count; i++)
        {
            projectilePrefabs[index].GetComponent<Projectile>().Hit(targetsInRange[i]);
        }
        particleWrapper.GetComponent<ParticleSystem>().Play();
    }

    protected override void Aim()
    {

    }
}
