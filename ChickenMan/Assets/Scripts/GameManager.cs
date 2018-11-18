using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;
    public bool Paused { get { return paused; } }
    private bool paused = false;
    public event Action<bool> OnGamePausedStateChanged = delegate { };
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

        DontDestroyOnLoad(gameObject);
    }

    private void InitializeGame()
    {


    }
    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            paused = !paused;
            if (OnGamePausedStateChanged!=null)
            {
                OnGamePausedStateChanged(paused);
            }
            
        }
    }
}
