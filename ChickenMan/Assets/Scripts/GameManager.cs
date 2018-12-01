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
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
        playerHealth = FindObjectOfType<PlayerHealth>();
        uIScore = FindObjectOfType<UIScore>();
        HideCursor();
        
        DontDestroyOnLoad(gameObject);
    }

   

    private void OnEnable()
    {
        PlayerHealth.OnPlayerDied += PlayerHealth_OnPlayerDied;
    }
    private void OnDisable()
    {
        PlayerHealth.OnPlayerDied -= PlayerHealth_OnPlayerDied;
    }
    private void PlayerHealth_OnPlayerDied()
    {
        PauseGame();
    }

    private static void HideCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetButtonDown("Start Xbox"))
        {
            PauseGame();

        }
    }

    private void PauseGame()
    {
        paused = !paused;
        if (paused)
        {
            ShowCursor();
        }
        else
        {
            HideCursor();
        }

        if (OnGamePausedStateChanged != null)
        {
            OnGamePausedStateChanged(paused);
        }
    }

    private static void ShowCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
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
        if (OnGamePausedStateChanged != null)
        {
            OnGamePausedStateChanged(paused);
        }

    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
