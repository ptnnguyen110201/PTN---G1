public interface ISubStationManager : IInitializableSystem
{
    ISubStationPrefab SubStationPrefab { get; }
    ISubStationSpawner SubStationSpawner { get; }
}