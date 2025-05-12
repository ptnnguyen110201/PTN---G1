using System.Collections.Generic;
using UnityEngine;

public interface IPlanetPointPosReader : IJsonObjectReader
{
    Dictionary<string, PlanetPointInfo> SpawnPosMap { get; }
    
}