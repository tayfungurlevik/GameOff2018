using System;
using System.Collections;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class EggBullet : PooledMonoBehaviour,IBullet
{
    
    [SerializeField]private int damage;
    [SerializeField]private PooledMonoBehaviour explosionEffect;
   
    
    public void GiveDamage(ITakeDamage objectToHit)
    {
        objectToHit.TakeDamage(damage);
    }

    
    private void OnCollisionEnter(Collision collision)
    {
        var particle=explosionEffect.Get<CFX_AutoDestructShuriken>(collision.contacts[0].point, Quaternion.identity);
        var damagableObject = collision.gameObject.GetComponent<ITakeDamage>();
        if (damagableObject != null)
        {
            GiveDamage(damagableObject);
        }
        ReturnToPool();
        //Destroy(gameObject, 0);

    }

   
}
