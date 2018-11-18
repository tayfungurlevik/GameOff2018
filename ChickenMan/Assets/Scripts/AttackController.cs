using System;
using System.Collections;
using UnityEngine;

public class AttackController : MonoBehaviour, IAttack
{
    [SerializeField]
    private int damageWhenAttacks = 10;
    [SerializeField]
    [Tooltip("How long the zombie waits after an attack to attack again")]
    private float delayBetweenAttacks = 1.5f;
    [SerializeField]
    [Tooltip("How far away the zombie can attack from")]
    private float maximumAttackRange = 1.5f;
    [SerializeField]
    private float delayBetweenAnimationAndDamage = 0.25f;
    private float attackTimer;

    private PlayerHealth player;

    public event Action OnAttack = delegate { };
    private void Awake()
    {
        player = FindObjectOfType<PlayerHealth>();
        
    }

   

    private void Update()
    {
        if (GameManager.Instance.Paused)
        {
            return;
        }
        attackTimer += Time.deltaTime;
        if (CanAttack())
        {
            attackTimer = 0;
            Attack(damageWhenAttacks, player);
        }
    }

    private bool CanAttack()
    {
        return attackTimer>=delayBetweenAttacks&&
            Vector3.Distance(transform.position, player.transform.position) <= maximumAttackRange;
    }

    public void Attack(int attackDamage, ITakeDamage objectToAttack)
    {
        if (OnAttack!=null)
        {
            OnAttack();
        }
        StartCoroutine(DealDamageAfterDelay());
        objectToAttack.TakeDamage(attackDamage);
    }

    private IEnumerator DealDamageAfterDelay()
    {
        yield return new WaitForSeconds(delayBetweenAnimationAndDamage);
        
    }
}
