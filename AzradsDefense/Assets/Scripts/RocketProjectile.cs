using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketProjectile : Projectile
{
    [SerializeField]
    private float randomVelocity;

    [SerializeField]
    private float randomTime;

    private float flyTime;
    private float randDirectionFlip;

    private int soundId;

    private void Start()
    {
        flyTime = 0;
        randDirectionFlip = Random.Range(0, 2) * 2 - 1;
        soundId = SoundManager.instance.PlaySound("example_fireworkwhistle");
    }
    protected override void Move()
    {
        if(flyTime <= randomTime)
        {
            flyTime += Time.deltaTime;
        } else
        {
            flyTime = randomTime;
        }
        Vector3 displacement = target.transform.position - transform.position;
        
        if (displacement.sqrMagnitude <= speed * Time.deltaTime * speed * Time.deltaTime)
        {
            HitTarget();
        }
        else
        {
            Vector3 direction = Vector2.Lerp(randDirectionFlip * Vector2.Perpendicular(displacement.normalized), displacement.normalized, (speed / (0.0001f + randomVelocity)) * (flyTime / randomTime));
            transform.up = direction;
            transform.position += direction * speed * Time.deltaTime;
        }
    }
    private void OnDestroy()
    {
        SoundManager.instance.StopSound(soundId);
        SoundManager.instance.PlaySound("example_fireworkblast");
    }
}
