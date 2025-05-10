
using System.Threading.Tasks;

using UnityEngine;

public interface IPrefabLoader 
{
    PrefabType PrefabType(); 
    Task LoadPrefabs();
    GameObject GetPrefab(PrefabCode prefabCode);

}
