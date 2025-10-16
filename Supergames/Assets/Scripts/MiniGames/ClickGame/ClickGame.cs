using System;
using UnityEngine;
using UnityEngine.UI;

public class ClickGame : MiniGameBase
{
    [SerializeField] private Button _clickerButton;
    
    private int _currentClicks = 0;

    public override void Initialize(IPlayerAccount playerAccount, string gameName, Action stopGameCallback)
    {
        if (_gameUI == null || playerAccount == null)
        {
            _isInitialized = false;
            return;
        }

        _currentClicks = playerAccount.Score;
        _gameUI.SetCounter(_currentClicks);

        base.Initialize(playerAccount, gameName, stopGameCallback);
    }

    public override void StartGame()
    {
        if (!IsInitialized)
        {
            Debug.LogError($"The game '{GameName}' is not initialized");
            return;
        }

        _clickerButton.gameObject.SetActive(true);
    }

    public override void StopGame()
    {
        PlayerAccount.AddScore(_currentClicks);
        _currentClicks = 0;
        _clickerButton.gameObject.SetActive(false);

        base.StopGame();
    }

    public void ClickGameButton()
    {
        _currentClicks++;
        _gameUI.SetCounter(_currentClicks);
    }
}