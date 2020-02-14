using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BulletPool
{
    private static List<GameObject> enabledBullets = new List<GameObject>();
    private static List<GameObject> disabledBullets = new List<GameObject>();

    public static void PoolInit()
    {
        enabledBullets.Clear();
        disabledBullets.Clear();
    }

    public static GameObject InstantiateBullet(GameObject bullet,Transform muzzle)
    {
        if (disabledBullets.Count == 0)
            return MonoBehaviour.Instantiate(bullet, muzzle.position, muzzle.rotation);

        GameObject tempBullet = disabledBullets[0];

        disabledBullets.RemoveAt(0);
        enabledBullets.Add(tempBullet);

        tempBullet.transform.position = muzzle.position;
        tempBullet.transform.rotation = muzzle.rotation;

        tempBullet.SetActive(true);

        return tempBullet;
    }

    public static void DisableBullet(GameObject bullet)
    {
        bullet.SetActive(false);

        enabledBullets.Remove(bullet);
        disabledBullets.Add(bullet);
    }
}
