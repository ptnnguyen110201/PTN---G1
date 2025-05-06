using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GameSystems.Shared.SystemBase;

using UnityEngine;

public interface IPrefabLoader : IInitializableSystem
{

    Task LoadPrefabs(PrefabType prefabType);
    GameObject GetPrefab(PrefabCode prefabCode);
    PrefabType PrefabType { get; }

}
