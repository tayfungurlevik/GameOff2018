using System;
using System.Collections;
using UnityEngine;

public class PooledMonoBehaviour : MonoBehaviour
{
    [SerializeField] private int initialPoolSize = 50;
    public event Action<PooledMonoBehaviour> OnReturnPool;
    public int InitialPoolSize { get { return initialPoolSize; } }

    public T Get<T>(bool enable = true) where T : PooledMonoBehaviour
    {
        var pool = Pool.GetPool(this);
        var pooledObject = pool.Get<T>();

        if (enable)
        {
            pooledObject.gameObject.SetActive(true);
        }
        return pooledObject;
    }

    public T Get<T>(Vector3 position,Quaternion rotation) where T : PooledMonoBehaviour
    {

        var pooledObject = this.Get<T>();
        pooledObject.transform.position = position;
        pooledObject.transform.rotation = rotation;

        return pooledObject;
    }

    private void OnDisable()
    {
        if (OnReturnPool!=null)
        {
            OnReturnPool(this);
        }
    }
    protected void ReturnToPool(float delay)
    {
        StartCoroutine(ReturnToPoolAfterSeconds(delay));
    }
    protected void ReturnToPool()
    {
        gameObject.SetActive(false);
    }

    private IEnumerator ReturnToPoolAfterSeconds(float delay)
    {
        yield return new WaitForSeconds(delay);
        gameObject.SetActive(false);
    }
}
