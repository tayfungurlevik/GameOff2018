using System;
using System.Collections;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class EggBullet : PooledMonoBehaviour,IBullet
{
    private Rigidbody bulletRigidbody;
    [SerializeField]private int damage;
    
   
    
    public void GiveDamage(ITakeDamage objectToHit)
    {
        objectToHit.TakeDamage(damage);
    }

    private void Awake()
    {
        bulletRigidbody = GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        ReturnToPool();
        //Destroy(gameObject, 0);

    }

   
}
