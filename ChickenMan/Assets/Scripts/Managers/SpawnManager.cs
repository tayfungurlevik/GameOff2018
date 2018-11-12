using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private SpawnPoint[] spawnPoints;

    private void Awake()
    {
        spawnPoints = GetComponentsInChildren<SpawnPoint>();
    }
    private void Update()
    {
        
    }

}
