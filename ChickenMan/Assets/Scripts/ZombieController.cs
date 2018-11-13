using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class ZombieController : MonoBehaviour,IAttack
{
    [SerializeField]
    private PlayerController target;
    private NavMeshAgent agent;
    private Animator animator;
    private Zombie zombie;
    private bool isMoving = true;
    private int[] attackMoves = new int[] { 1, 2, 3, 4 };
    private void Awake()
    {
        zombie = GetComponent<Zombie>();
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
    }
    private void OnEnable()
    {
        if (target==null)
        {
            target = FindObjectOfType<PlayerController>();
        }
        zombie.OnZombieDied += Zombie_OnZombieDied;
        zombie.OnZombieHit += Zombie_OnZombieHit;
    }

    private void Zombie_OnZombieHit()
    {
        if (!zombie.Died)
        {
            animator.SetTrigger("Hit");
            isMoving = false;
        }
        
    }

    private void OnDisable()
    {
        target = null;
        zombie.OnZombieDied -= Zombie_OnZombieDied;
        zombie.OnZombieHit -= Zombie_OnZombieHit;
    }

    private void Zombie_OnZombieDied(int obj)
    {
        agent.isStopped = true;
        
        animator.SetFloat("Speed", 0);
        animator.SetBool("Died", true);
        isMoving = false;
    }

    private void Update()
    {
        if (isMoving)
        {
            agent.isStopped = false;
            agent.SetDestination(target.transform.position);
            animator.SetFloat("Speed", 1f);
        }
        else
        {
            agent.isStopped = true;
            
            
        }
            
        
        
        
    }

    public void Attack(int attackDamage, ITakeDamage objectToAttack)
    {
        int randomAttackMove = UnityEngine.Random.Range(1, 5);
    }
}
