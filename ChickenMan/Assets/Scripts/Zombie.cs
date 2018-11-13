using System;
using UnityEngine;


public class Zombie : PooledMonoBehaviour, ITakeDamage
{
    [SerializeField]
    private int health = 100;
    [SerializeField]
    private int scoreOnDied = 50;
    private bool died = false;
    
    public bool Died { get { return died; } }
    public event Action<int> OnZombieDied = delegate { };
    public event Action OnZombieHit = delegate { };

    public void TakeDamage(int amount)
    {
        if (!died && health>0)
        {

            if (OnZombieHit!=null)
            {
                OnZombieHit();
            }
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
        ReturnToPool(3.0f);
    }
}
