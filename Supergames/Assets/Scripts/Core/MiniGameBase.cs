using System;
using TMPro;
using UnityEngine;

public abstract class MiniGameBase : MonoBehaviour, IMiniGame
{
    [SerializeField] protected MiniGameUIBase _gameUI;

    protected string _gameName = "No Name";
    public string GameName { get => _gameName; set => _gameName = value; }

    protected bool _isInitialized = false;
    public bool IsInitialized => _isInitialized;

    protected IPlayerAccount _playerAccount;
    public IPlayerAccount PlayerAccount => _playerAccount;

    private Action _onStop;

    public virtual void Initialize(IPlayerAccount playerAccount, string gameName, Action stopGameCallback)
    {
        if (_gameUI) _gameUI.InitGameUI(playerAccount, stopGameCallback);
        _gameName = gameName;
        _playerAccount = playerAccount;
        _onStop = stopGameCallback;
        _isInitialized = true;
    }

    public virtual void StopGame()
    {
        _onStop?.Invoke();
    }

    public abstract void StartGame();
}
