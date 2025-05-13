using UnityEngine;
using System.Threading.Tasks;

public class MainStationSpawner : Spawner<MainStationCtrl>, IMainStationSpawner
{
    public MainStationSpawner(IMainStationPrefab prefabLoader) : base(prefabLoader)
    {
    }

    public Task SpawnMainStation()
    {
        Vector3 SpawnPos = Vector3.zero;
        Quaternion SpawnRot = Quaternion.identity;
        MainStationCtrl mainStationCtrl = this.Spawn("MainStation", SpawnPos, SpawnRot);
        GameContext.Instance.Container.BindInstance<IMainStationCtrl>(mainStationCtrl);
        return Task.CompletedTask;
    }
}