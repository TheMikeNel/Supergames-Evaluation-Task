using UnityEngine;

[CreateAssetMenu(fileName = "MiniGameDefinition", menuName = "Configs/MiniGameDefinition")]
public class MiniGameDefinition : ScriptableObject
{
    public string gameName = "Mini Game";
    public Sprite iconSprite;
    public MiniGameBase gamePrefab;
}
