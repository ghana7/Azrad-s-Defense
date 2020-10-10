using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperShooter : Shooter
{
    public override void Shoot(int index)
    {
        if (projectilePrefabs.Length > index)
        {
            GameObject projectileInstance = Instantiate(projectilePrefabs[index]);
            projectileInstance.transform.position = transform.position;
            projectileInstance.GetComponent<Projectile>().target = currentTarget;
            if(projectileInstance.GetComponent<CrosshairProjectile>() != null)
            {
                projectileInstance.GetComponent<CrosshairProjectile>().shooter = gameObject;
            }
            
        }
    }
}
