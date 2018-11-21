using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;
    public bool Paused { get { return paused; } }
    private bool paused = false;
    public event Action<bool> OnGamePausedStateChanged = delegate { };
    public event Action OnGameRestart = delegate { };
    private PlayerHealth playerHealth;
    private UIScore uIScore;
    private void Awake()
    {
        if (Instance==null)
        {
            Instance = this;
        }
        else if (Instance!=this)
        {
            Destroy(gameObject);
        }
        playerHealth = FindObjectOfType<PlayerHealth>();
        uIScore = FindObjectOfType<UIScore>();
        
        DontDestroyOnLoad(gameObject);
    }

    
    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape)||Input.GetButtonDown("Start Xbox"))
        {
            PauseGame();

        }
    }

    private void PauseGame()
    {
        paused = !paused;
        if (OnGamePausedStateChanged != null)
        {
            OnGamePausedStateChanged(paused);
        }
    }

    public void RestartGame()
    {

        if (OnGameRestart != null)
        {
            OnGameRestart();
        }
        SceneManager.LoadScene("Level1");
        ResumeGame();

        playerHealth.ResetHealth();
        uIScore.ResetScore();

    }

    private void ResumeGame()
    {
        paused = false;
        if (OnGamePausedStateChanged!=null)
        {
            OnGamePausedStateChanged(paused);
        }
        
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
