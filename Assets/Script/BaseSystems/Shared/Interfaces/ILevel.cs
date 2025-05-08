
public interface ILevel : IInitializableSystem
{
    int CurrentLevel { get; }
    int MaxLevel { get; }
    bool IsMaxLevel();
    void OnLevelUp();
    

}