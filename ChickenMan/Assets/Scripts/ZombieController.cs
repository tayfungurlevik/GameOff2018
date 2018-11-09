using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class ZombieController : MonoBehaviour
{
    [SerializeField]
    private PlayerController target;
    private NavMeshAgent agent;
    private Animator animator;
    private Zombie zombie;
    private bool isMoving = true;
    private void Awake()
    {
        zombie = GetComponent<Zombie>();
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
    }
    private void OnEnable()
    {
        zombie.OnZombieDied += Zombie_OnZombieDied;
    }
    private void OnDisable()
    {
        zombie.OnZombieDied -= Zombie_OnZombieDied;
    }

    private void Zombie_OnZombieDied(int obj)
    {
        agent.isStopped = true;
        Debug.Log("Zombie öldü.");
        animator.SetFloat("Speed", 0);
        animator.SetBool("Died", true);
        isMoving = false;
    }

    private void Update()
    {
        if (isMoving)
        {
            agent.SetDestination(target.transform.position);
            animator.SetFloat("Speed", 1f);
        }
            
        
        
        
    }
}
