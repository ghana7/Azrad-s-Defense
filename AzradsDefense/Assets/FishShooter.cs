using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishShooter : Shooter
{
    [SerializeField]
    private int amountOfMoney;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    protected override void Update()
    {
        if (canShoot)
        {
            shotCooldown += Time.deltaTime;
            if (shotCooldown >= secondsPerShot)
            {
                shotCooldown = secondsPerShot;
            }
            if (shotCooldown >= secondsPerShot)
            {
                Shoot(0);
                shotCooldown -= secondsPerShot;
            }
        }
    }

    public override void Shoot(int index)
    {
        if (projectilePrefabs.Length > index)
        {
            if(index == 1)
            {
                MoneyManager.instance.AddMoney(amountOfMoney);
            }
            GameObject projectileInstance = Instantiate(projectilePrefabs[index]);
            projectileInstance.transform.position = transform.position;
            if (projectileInstance.GetComponent<FishProjectile>() != null)
            {
                projectileInstance.GetComponent<FishProjectile>().shooter = gameObject;
                projectileInstance.GetComponent<FishProjectile>().SetStartPos();
            }

        }
    }
}
