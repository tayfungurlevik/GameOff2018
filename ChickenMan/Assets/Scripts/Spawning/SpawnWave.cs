using System;
[Serializable]
public struct SpawnWave
{
    public PooledMonoBehaviour ObjectToSpawn;
    public int SpawnedObjectNumberPerWave;
    public float SpawnTime;
}
