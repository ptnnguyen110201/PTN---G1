using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class SubStationSpawner : Spawner<SubStationCtrl>, ISubStationSpawner
{
    public SubStationSpawner(ISubStationPrefab prefabLoader) : base(prefabLoader)
    {
    }

    public Task SpawnSubStation()
    {
        ISubStationPosReader SubStationPosReader = GameContext.Instance.Container.Resolve<ISubStationPosReader>();
        foreach(var SubStationInfo in SubStationPosReader.SubStationPos) 
        {
            string SubStationName = SubStationInfo.Value.Name;
            Vector3 SubStationPos = SubStationInfo.Value.StationPos;

            SubStationCtrl subStationCtrl = this.Spawn(SubStationName, SubStationPos, Quaternion.identity);
            
        }
        return Task.CompletedTask;
    }
}