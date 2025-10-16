public interface IPlayerAccount
{
    string Name { get; }
    int Score { get; }

    void AddScore(int value);
}
