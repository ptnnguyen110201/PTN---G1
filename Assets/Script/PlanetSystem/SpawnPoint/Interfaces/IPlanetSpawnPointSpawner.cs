public interface IPlanetSpawnPointSpawner : ISpawner<PlanetSpawnPointCtrl> 
{
    IPlanetSpawnPosReader PlanetSpawnPosReader { get;  }
    void SpawnByPoint();
}