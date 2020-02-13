using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bullet;
    private Transform muzzle;

    public int currentAmmo;
    public int maxAmmo;
    private bool infinitAmmo;

    public float bulletSpeed;

    public float shootRate;
    private float lastShootTime;

    private void Awake()
    {
        muzzle = transform.Find("weapon/Muzzle");

        if (!muzzle)
            muzzle = transform.Find("Main Camera/weapon/Muzzle");     

        else
            infinitAmmo = true;
    }

    public bool CanShoot()
    {
        if (Time.time - lastShootTime >= shootRate)
        {
            if (currentAmmo>0 || infinitAmmo)
                return true;
        }

        return false;
    }

    public void Shoot()
    {
        lastShootTime = Time.time;
        currentAmmo--;

        GameObject bul = BulletPool.InstantiateBullet(bullet,muzzle);
        bul.GetComponent<Rigidbody>().velocity = muzzle.forward * bulletSpeed;
    }
}
