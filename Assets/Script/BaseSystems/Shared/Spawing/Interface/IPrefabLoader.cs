
using System.Threading.Tasks;

using UnityEngine;

public interface IPrefabLoader : IInitializableSystem
{
    PrefabType PrefabType(); 
    Task LoadPrefabs();
    GameObject GetPrefab(string prefabName);

}
