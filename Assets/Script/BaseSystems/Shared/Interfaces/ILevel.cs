public interface ILevel 
{
    int CurrentLevel { get; }
    int MaxLevel { get; }
    bool IsMaxLevel();
    void OnLevelUp();
}