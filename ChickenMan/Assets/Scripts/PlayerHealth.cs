using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour,ITakeDamage
{
   
    private int health = 100;
    [SerializeField]
    private int MaxHealth=100;
    private bool isDead = false;
    public bool IsDead { get { return isDead; } }
    
    public static event Action OnPlayerDied = delegate { };
    public static event Action<int> OnPlayerHealthChanged = delegate { };

    private void Awake()
    {
        health = MaxHealth;
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
        if (OnPlayerHealthChanged != null)
        {
            OnPlayerHealthChanged(0);
        }
        if (OnPlayerDied!=null)
        {
            OnPlayerDied();
        }
        
    }
    public  void ResetHealth()
    {
        isDead = false;
        health = MaxHealth;
        if (OnPlayerHealthChanged != null)
        {
            OnPlayerHealthChanged(health);
        }
    }
}
