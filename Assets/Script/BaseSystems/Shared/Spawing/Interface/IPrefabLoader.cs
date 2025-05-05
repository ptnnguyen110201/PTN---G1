using System;
using System.Threading.Tasks;
using GameSystems.Shared.SystemBase;
using UnityEngine;

public interface IPrefabLoader : IInitializableSystem
{
    Task<GameObject> LoadPrefabAsync(PrefabType prefabType, PrefabCode prefabCode);
    Task PreloadAll();

}
