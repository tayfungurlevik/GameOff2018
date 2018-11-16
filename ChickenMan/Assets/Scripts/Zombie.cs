using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : PooledMonoBehaviour, ITakeDamage
{
    [SerializeField]
    private int health = 100;
    [SerializeField]
    private int scoreOnDied = 50;
    [SerializeField]
    private int scoreOnHit = 10;
    [SerializeField]
    private Stats statistics;
    private bool died = false;
    private Animator animator;
    private NavMeshAgent agent;
        
    public bool Died { get { return died; } }
    public static event Action<int> OnZombieDied = delegate { };
    public static event Action<int> OnZombieHit = delegate { };

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }
    public void TakeDamage(int amount)
    {
        if (!died && health>0)
        {
            health -= amount;
            agent.isStopped = true;
            animator.SetTrigger("Hit");
            WaitSeconds(2f);
            agent.isStopped = false;
            if (OnZombieHit!=null)
            {
                OnZombieHit(scoreOnHit);
            }
            
        }
        else
        {
            if (!died)
            {
                Die();
            }
        }
        
    }

    private void Die()
    {
        statistics.TotalNumberOfZombieKilled++;
        died = true;
        agent.isStopped = true;
        animator.SetTrigger("Died");

        if (OnZombieDied!=null)
        {
            OnZombieDied(scoreOnDied);
        }
        ReturnToPool(8.0f);
        
    }
    private IEnumerator WaitSeconds(float time)
    {
        yield return new WaitForSeconds(time);
    }
}
