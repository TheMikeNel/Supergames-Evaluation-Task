using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GamePanelUI : MonoBehaviour
{
    [SerializeField] private Image _iconImage;
    [SerializeField] private TMP_Text _nameText;
    [SerializeField] private Button _startButton;

    private MiniGameDefinition _definition;
    private Action<MiniGameDefinition> _onStart;

    public void Init(MiniGameDefinition definition, Action<MiniGameDefinition> onStartGamePanelClick)
    {
        if (definition.iconSprite != null && _iconImage != null)
            _iconImage.sprite = definition.iconSprite;

        if (_nameText != null) _nameText.text = definition.gameName;

        _definition = definition;
        _onStart = onStartGamePanelClick;

        _startButton.onClick.RemoveAllListeners();
        _startButton.onClick.AddListener(StartGame);
    }

    public void StartGame()
    {
        if (_definition == null || _definition.gamePrefab == null)
        {
            Debug.LogError($"The game can't be started! Check the definition of this game or prefab in game panel");
            return;
        }

        _onStart?.Invoke(_definition);
    }
}
