using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BulletPool
{
    public static List<GameObject> enabledBullets = new List<GameObject>();
    public static List<GameObject> disabledBullets = new List<GameObject>();

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
}
