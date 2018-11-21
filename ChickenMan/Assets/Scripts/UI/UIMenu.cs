using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Experimental.UIElements;
using UnityEngine.SceneManagement;

public class UIMenu : MonoBehaviour
{
    [SerializeField] private GameObject MenuPanel;
    [SerializeField] private GameObject firstEnabledObject;
    private EventSystem eventSystem;
    private void ToggleMenuState(bool state)
    {
        MenuPanel.SetActive(state);
    }
    private void Start()
    {
        
        GameManager.Instance.OnGamePausedStateChanged += Instance_OnGamePausedStateChanged;
        eventSystem = FindObjectOfType<EventSystem>();
        
        eventSystem.firstSelectedGameObject = firstEnabledObject.gameObject;
    }
    
    
    private void Instance_OnGamePausedStateChanged(bool pauseState)
    {
        ToggleMenuState(pauseState);
    }

    private void OnDisable()
    {
        GameManager.Instance.OnGamePausedStateChanged -= Instance_OnGamePausedStateChanged;
    }
    public void RestartGame()
    {
        GameManager.Instance.RestartGame();
        
    }
    public void ExitGame()
    {
        GameManager.Instance.ExitGame();
    }

}
