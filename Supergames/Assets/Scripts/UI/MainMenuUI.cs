using UnityEngine;
using System.Collections.Generic;
using System;
using TMPro;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private GameObject _emptyGamesListPanel;
    [SerializeField] private TMP_Text _playerNameText;
    [SerializeField] private GameObject _gamesListPanel;
    [SerializeField] private GamePanelUI _gamePanelUIPrefab;
    [SerializeField] private Transform _gamesUIListContent;

    private List<GamePanelUI> _currentGamesPanelsUI;

    public void Init(IPlayerAccount player, List<MiniGameDefinition> gamesList, Action<MiniGameDefinition> onStartClick)
    {
        if (_playerNameText != null) _playerNameText.text = player.Name;

        if (gamesList == null || gamesList.Count < 1) return;

        _emptyGamesListPanel.SetActive(false);
        _gamesListPanel.SetActive(true);

        SpawnGamePanels(gamesList, onStartClick);
    }

    private void SpawnGamePanels(List<MiniGameDefinition> gamesList, Action<MiniGameDefinition> onStartClick)
    {
        _currentGamesPanelsUI = new List<GamePanelUI>();

        foreach (MiniGameDefinition game in gamesList)
        {
            if (game == null) continue;
            if (game.gamePrefab == null)
            {
                Debug.LogWarning($"Game prefab was not founded in the definition '{game.gameName}'");
                continue;
            }

            _currentGamesPanelsUI.Add(SpawnGamePanel(game, onStartClick));
        }
    }

    private GamePanelUI SpawnGamePanel(MiniGameDefinition definition, Action<MiniGameDefinition> onStartClick)
    {
        GamePanelUI panel = Instantiate(_gamePanelUIPrefab, _gamesUIListContent);
        panel.Init(definition, onStartClick);
        return panel;
    }
}
