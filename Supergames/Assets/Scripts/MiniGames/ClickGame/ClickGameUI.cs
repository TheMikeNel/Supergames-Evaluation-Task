using System;
using TMPro;
using UnityEngine;

public class ClickGameUI : MiniGameUIBase
{
    [SerializeField] private TMP_Text _playerNameText;

    public override void InitGameUI(IPlayerAccount playerAccount, Action onGameStop)
    {
        if (playerAccount == null) return;
        _playerNameText.text = playerAccount.Name;
        _gameStopButton.onClick.RemoveAllListeners();
        _gameStopButton.onClick.AddListener(() => onGameStop?.Invoke());
    }
}
