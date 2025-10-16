using System;

public interface IMiniGame
{
    string GameName { get; set; }
    bool IsInitialized { get; }

    void Initialize(IPlayerAccount playerAccount, string gameName, Action stopGameCallback); // Initializing Player Data in game before start
    void StartGame();
    void StopGame();
}