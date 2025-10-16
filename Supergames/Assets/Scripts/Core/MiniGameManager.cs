using UnityEngine;
using System.Collections.Generic;

public class MiniGameManager : MonoBehaviour
{
    [SerializeField] private MainMenuUI _menuUI;
    [SerializeField] private List<MiniGameDefinition> _minigames;
    [SerializeField] private Transform _gameContainer;

    public IPlayerAccount PlayerAccount { get; private set; }
    public MiniGameBase ActiveGame { get; private set; }
    public bool IsPlayingNow => ActiveGame != null;

    public void Start()
    {
        DefaultPlayerAccount account = new("Player 1", 115); // In the real game, this data should be loaded from server or local saves
        PlayerAccount = account;
        Init();
    }

    private void Init()
    {
        // Here you need to make dynamic loading of MiniGameDefinitions. Whether it's from Resources, Addressables, or other methods. Like "_minigames = LoadFrom...();"
        if (_minigames != null && _minigames.Count > 0)
        {
            _menuUI.Init(PlayerAccount, _minigames, OnStartClick);
        }
    }

    private void StopActiveGame()
    {
        if (IsPlayingNow) // The current game should end correctly here. For now, it is just destroy.
        {
            Destroy(ActiveGame.gameObject);
            ActiveGame = null;
        }

        _menuUI.gameObject.SetActive(true);
    }

    private void OnStartClick(MiniGameDefinition definition)
    {
        if (IsPlayingNow)
        {
            Debug.LogError("Active Game is not closed");
        }

        if (definition == null || definition.gamePrefab == null)
        {
            Debug.LogError("Something wrong with Mini Game Definition when it is started");
            return;
        }

        PrepareMiniGame(definition);
    }

    private void PrepareMiniGame(MiniGameDefinition definition)
    {
        MiniGameBase game = Instantiate(definition.gamePrefab, _gameContainer);
        game.Initialize(PlayerAccount, definition.gameName, StopActiveGame);
        ActiveGame = game;

        StartActiveGame();
    }

    private void StartActiveGame()
    {
        if (!ActiveGame)
        {
            Debug.LogError("ActiveGame is null");
            return;
        }
        if (!ActiveGame.IsInitialized)
        {
            Debug.LogError($"Something went wrong with game initialization: '{ActiveGame.GameName}'");
            StopActiveGame();
            return;
        }

        _menuUI.gameObject.SetActive(false);
        ActiveGame.StartGame();
    }
}
