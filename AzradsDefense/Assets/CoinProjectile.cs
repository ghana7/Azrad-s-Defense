using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinProjectile : Projectile
{
    [SerializeField]
    private float lifetime;

    private float currentLifetime;
    private SpriteRenderer sr;
    // Start is called before the first frame update
    void Awake()
    {
        currentLifetime = 0;
        sr = GetComponent<SpriteRenderer>();

        //set the target to something so it doesn't delete itself
        target = gameObject;
    }

    protected override void Move()
    {
        transform.position += Vector3.up * speed * Time.deltaTime;

        currentLifetime += Time.deltaTime;

        sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, Mathf.Lerp(1.0f, 0.0f, currentLifetime / lifetime));
        if(currentLifetime > lifetime)
        {
            Destroy(gameObject);
        }
    }
}
