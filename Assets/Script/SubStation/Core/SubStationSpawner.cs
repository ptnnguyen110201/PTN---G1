using UnityEngine;

public class SubStationSpawner : Spawner<SubStationCtrl>, ISubStationSpawner
{
    public SubStationSpawner(ISubStationPrefab prefabLoader) : base(prefabLoader)
    {
    }
}