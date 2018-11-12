using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    
    [SerializeField]
    private SpawnWave[] spawnWaves;
    private int waveIndex = 0;
    private float time;
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0);
        Gizmos.DrawSphere(transform.position, 1f);
    }
    private void Awake()
    {
        time = 0.0f;
    }
    public void Spawn()
    {
        time = 0.0f;
        for (int i = 0; i < spawnWaves[waveIndex].SpawnedObjectNumberPerWave; i++)
        {
            spawnWaves[waveIndex].ObjectToSpawn.Get<Zombie>(this.transform.position, Quaternion.identity);
        }
        waveIndex++;
    }

    private void Update()
    {
        time += Time.deltaTime;
        if (CanSpawn())
        {
            Spawn(); 
        }
    }

    private bool CanSpawn()
    {
        if (waveIndex>=spawnWaves.Length)
        {
            return false;
        }
        else
            return time >= spawnWaves[waveIndex].SpawnTime;
    }
}
