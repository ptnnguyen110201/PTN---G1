using System.Collections.Generic;
using UnityEngine;

public class PlanetSpawnPointSpawner : Spawner<PlanetSpawnPointCtrl>, IPlanetSpawnPointSpawner
{
    public IPlanetSpawnPosReader PlanetSpawnPosReader { get; private set; }
    public PlanetSpawnPointSpawner(IPrefabLoader prefabLoader, IPlanetSpawnPosReader PlanetSpawnPosReader) : base(prefabLoader)
    {
        this.PlanetSpawnPosReader = PlanetSpawnPosReader;

    }

    public void SpawnByPoint()
    {
        foreach (KeyValuePair<string, Vector3> kvp in this.PlanetSpawnPosReader.SpawnPosMap)
        {
            string id = kvp.Key;
            Vector3 pos = kvp.Value;

           
            PrefabCode prefabCode = PrefabCode.PlanetSpawnPoint; 
            Quaternion rot = Quaternion.identity;

            PlanetSpawnPointCtrl Point = this.Spawn(prefabCode, pos, rot);

           
        }
    }
}