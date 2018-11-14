using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour,ITakeDamage
{
    [SerializeField]
    private int health = 100;
    public static int MaxHealth;
    private bool isDead = false;
    public static event Action OnPlayerDied = delegate { };
    public static event Action<int> OnPlayerHealthChanged = delegate { };
    private void Awake()
    {
        MaxHealth = health;
    }
    public void TakeDamage(int amount)
    {
        health-=amount;
        
        if (health<=0)
        {
            Die();
        }
        if (!isDead)
        {
            if (OnPlayerHealthChanged!=null)
            {
                OnPlayerHealthChanged(health);
            }
        }
    }

    private void Die()
    {
        isDead = true;
        if (OnPlayerDied!=null)
        {
            OnPlayerDied();
        }
    }
}
