using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [Header("stats")]
    public float aimMoveSpeed;
    public float moveSpeed;
    public float jumpForce;
    public int currentHP;
    public int maxHP;

    private Weapon weapon;
    private bool isPlayer;
    private void Start()
    {
        isPlayer = gameObject.CompareTag("Player");
        weapon = GetComponent<Weapon>();

        if (isPlayer)
        {
            UImanager.uiManager.UpdateAmmo(weapon.currentAmmo, weapon.maxAmmo);
            UImanager.uiManager.UpdateHealthBar(currentHP, maxHP);
            UImanager.uiManager.UpdateScore(0);
        }
    }

    public void Shoot()
    {
        if (weapon.CanShoot())
            weapon.Shoot();

        if (isPlayer)
            UImanager.uiManager.UpdateAmmo(weapon.currentAmmo, weapon.maxAmmo);
    }

    public void TakeDamage(int damage)
    {
        currentHP = Mathf.Clamp(currentHP - damage,0,maxHP);

        if (isPlayer)
            UImanager.uiManager.UpdateHealthBar(currentHP, maxHP);
        else
            GameManager.gameManager.AddScore(10);

        if (currentHP <= 0)
            Die();
    }

    private void Die()
    {
        if (isPlayer)
        {
            GameManager.gameManager.LoseGame();
        }
        else
        {
            GameManager.gameManager.AddScore(100);
            Destroy(gameObject);
        } 
    }

    public void TakeHP(int amount)
    {
        currentHP = Mathf.Clamp(currentHP + amount, 1, maxHP);

        UImanager.uiManager.UpdateHealthBar(currentHP,maxHP);
    }

    public void TakeAmmo(int amount)
    {
        weapon.currentAmmo = Mathf.Clamp(weapon.currentAmmo + amount, 1, weapon.maxAmmo);

        UImanager.uiManager.UpdateAmmo(weapon.currentAmmo, weapon.maxAmmo);
    }
}
