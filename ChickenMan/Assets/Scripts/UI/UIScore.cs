using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIScore : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI scoreText;
    private int totalScore = 0;
    private void OnEnable()
    {
        Zombie.OnZombieHit += Zombie_OnZombieHit;
    }
    private void OnDisable()
    {
        Zombie.OnZombieHit -= Zombie_OnZombieHit;
    }
    private void Zombie_OnZombieHit(int score)
    {
        totalScore += score;
        scoreText.text = string.Format("Score: {0}",totalScore);
    }
}
