using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIHealth : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI healthText;
    private void OnEnable()
    {
        PlayerHealth.OnPlayerHealthChanged += PlayerHealth_OnPlayerHealthChanged;
    }
    private void OnDisable()
    {
        PlayerHealth.OnPlayerHealthChanged -= PlayerHealth_OnPlayerHealthChanged;
    }
    private void PlayerHealth_OnPlayerHealthChanged(int health)
    {
        healthText.text = string.Format("{0}/{1}", health, 100);
    }
}
