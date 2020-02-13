using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [Header("stats")]
    public float moveSpeed;
    public float jumpForce;
    public int currentHP;
    public int maxHP;

    private Weapon weapon;

    private void Start()
    {
        weapon = GetComponent<Weapon>();
    }

    public void Shoot()
    {
        if (weapon.CanShoot())
            weapon.Shoot();
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;

        if (currentHP <= 0)
            Die();
    }

    private void Die()
    {
        if (gameObject.CompareTag("Enemy"))
            Destroy(gameObject);

        //else logic for player
    }

    public void TakeHP(int amount)
    {
        currentHP = Mathf.Clamp(currentHP + amount, 1, maxHP);
    }

    public void TakeAmmo(int amount)
    {
        weapon.currentAmmo = Mathf.Clamp(weapon.currentAmmo + amount, 1, weapon.maxAmmo);
    }
}
