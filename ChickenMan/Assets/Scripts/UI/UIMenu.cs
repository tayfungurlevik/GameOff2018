using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMenu : MonoBehaviour
{
    [SerializeField] private GameObject MenuPanel;
    private void ToggleMenuState(bool state)
    {
        MenuPanel.SetActive(state);
    }

    private void Start()
    {
        GameManager.Instance.OnGamePausedStateChanged += Instance_OnGamePausedStateChanged;
    }

    private void Instance_OnGamePausedStateChanged(bool pauseState)
    {
        ToggleMenuState(pauseState);
    }

    private void OnDestroy()
    {
        GameManager.Instance.OnGamePausedStateChanged -= Instance_OnGamePausedStateChanged;
    }
    
    
}
