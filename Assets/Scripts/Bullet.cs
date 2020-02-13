using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage;
    public float lifeTime;

    private float startTime;
    private float endTime;

    public GameObject hitParticle;
    private void OnEnable()
    {
        startTime = Time.time;
        endTime = startTime + lifeTime;
    }

    private void Update()
    {
        if (endTime <= Time.time)
            BulletPool.DisableBullet(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        Character character = other.GetComponent<Character>();

        if (character != null)
            character.TakeDamage(damage);

        GameObject obj = Instantiate(hitParticle, transform.position, transform.rotation);
        Destroy(obj,1.0f);

        BulletPool.DisableBullet(gameObject);
    }
}
