﻿using System;
using UnityEngine;

public class Zombie : MonoBehaviour, ITakeDamage
{
    [SerializeField]
    private int health = 100;
    [SerializeField]
    private int scoreOnDied = 50;
    private bool died = false;
    
    public bool Died { get { return died; } }
    public event Action<int> OnZombieDied = delegate { };

    public void TakeDamage(int amount)
    {
        if (!Died&&health>0)
        {
            health -= amount;
        }
        else
        {
            Die();
        }
        
    }

    private void Die()
    {
        died = true;
        if (OnZombieDied!=null)
        {
            OnZombieDied(scoreOnDied);
        }
    }
}