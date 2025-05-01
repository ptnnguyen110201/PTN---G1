public interface IMainStationLevel : ILevel 
{
    int RequiredResources { get; }
    int CurrentResources { get; }

    void AddResources(int amount);
}