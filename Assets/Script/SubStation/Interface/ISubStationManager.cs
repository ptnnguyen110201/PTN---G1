public interface ISubStationManager : IInitializableSystem
{
    ISubStationPosReader SubStationPosReader { get; }
    ISubStationPrefab SubStationPrefab { get; }
    ISubStationSpawner SubStationSpawner { get; }
}