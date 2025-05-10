using System.Collections.Generic;
using UnityEngine;

public interface IPlanetSpawnPosReader
{
    Dictionary<string, Vector3> SpawnPosMap { get; }
    
}