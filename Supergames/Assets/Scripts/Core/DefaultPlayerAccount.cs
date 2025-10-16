public class DefaultPlayerAccount : IPlayerAccount
{
    private string _name = "No Name";
    public string Name => _name;

    private int _score = 0;
    public int Score => _score;

    public void AddScore(int value)
    {
        _score += value;
    }

    public DefaultPlayerAccount(string name, int score)
    {
        _name = name;
        _score = score;
    }
}
