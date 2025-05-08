
using System.Threading.Tasks;

using UnityEngine;

public interface IPrefabLoader : IInitializableSystem
{

    Task LoadPrefabs(PrefabType prefabType);
    GameObject GetPrefab(PrefabCode prefabCode);
    PrefabType PrefabType { get; }

}
