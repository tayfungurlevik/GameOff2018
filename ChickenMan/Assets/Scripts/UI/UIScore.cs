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
        Zombie.OnZombieDied += Zombie_OnZombieDied;
    }

    private void Zombie_OnZombieDied(int score)
    {
        totalScore += score;
        SetScore();
    }

    private void SetScore()
    {
        scoreText.text = string.Format("Score: {0}", totalScore);
    }

    private void OnDisable()
    {
        Zombie.OnZombieHit -= Zombie_OnZombieHit;
        Zombie.OnZombieDied -= Zombie_OnZombieDied;
    }

    private void Zombie_OnZombieHit(int score)
    {
        totalScore += score;
        SetScore();
    }
}
