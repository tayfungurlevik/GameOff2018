using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class EggBullet : MonoBehaviour,IBullet
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

}
