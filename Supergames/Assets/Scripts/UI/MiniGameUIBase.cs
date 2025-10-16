using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class MiniGameUIBase : MonoBehaviour
{
    [SerializeField] protected TMP_Text _counter;
    [SerializeField] protected Button _gameStopButton;

    public abstract void InitGameUI(IPlayerAccount playerAccount, Action onGameStop);

    public void SetCounter(int count)
    {
        if (_counter == null) return;

        _counter.text = count.ToString();
    }
}
