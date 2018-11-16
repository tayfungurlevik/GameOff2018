using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Statistics",menuName ="Data",order =1)]
public class Stats : ScriptableObject {

    public int TotalNumberOfZombieKilled;
    public int TotalNumberOfShotsMade;
    public int TotalNumberOfShotsHitZombie;
}
