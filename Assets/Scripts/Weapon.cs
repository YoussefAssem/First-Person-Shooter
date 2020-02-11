using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bullet;
    public Transform muzzle;

    public int curAmmo;
    public int maxAmmo;
    public bool infinitAmmo;

    public float bulletSpeed;

    public float shootRate;
    private float lastShootTime;
    private bool isPlayer;

    private void Awake()
    {
        //find out if we are the player
        if (GetComponent<Player>())
        {
            isPlayer = true;
        }
    }

    public bool CanShoot()
    {
        if (Time.time - lastShootTime >= shootRate)
        {
            if (curAmmo>0 || infinitAmmo)
                return true;
        }

        return false;
    }

    public void Shoot()
    {
        lastShootTime = Time.time;
        curAmmo--;

        GameObject bul = Instantiate(bullet,muzzle.position,muzzle.rotation);
        bul.GetComponent<Rigidbody>().velocity = muzzle.forward * bulletSpeed;
    }
}
