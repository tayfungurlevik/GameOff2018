using System;
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
    
    private void Awake()
    {
        zombie = GetComponent<Zombie>();
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
        GetComponent<AttackController>().OnAttack += AttackController_OnAttack;
    }

    private void AttackController_OnAttack()
    {
        animator.SetInteger("AttackId", UnityEngine.Random.Range(1, 3));
        animator.SetTrigger("Attack");
    }

    private void OnEnable()
    {
        if (target==null)
        {
            target = FindObjectOfType<PlayerController>();
        }
    }
    
    private void OnDisable()
    {
        target = null;
    }

    private void Update()
    {
        agent.SetDestination(target.transform.position);
        animator.SetFloat("Speed", agent.velocity.magnitude);
    }

   
}
