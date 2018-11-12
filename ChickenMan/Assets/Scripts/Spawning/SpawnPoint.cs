using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField]
    private readonly PooledMonoBehaviour objectToSpawn;
    [SerializeField]
    private SpawnWave[] spawnWaves;
    private int waveIndex = 0;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0);
        Gizmos.DrawSphere(transform.position, 1f);
    }

    public IEnumerator Spawn()
    {
        for (int i = 0; i < spawnWaves[waveIndex].SpawnedObjectNumberPerWave; i++)
        {
            objectToSpawn.Get<Zombie>(this.transform.position, Quaternion.identity);
        }
        yield return new WaitForSeconds(spawnWaves[waveIndex].DelayAfterSpawn);
        waveIndex++;
    }

    private void Update()
    {
        
    }
}
