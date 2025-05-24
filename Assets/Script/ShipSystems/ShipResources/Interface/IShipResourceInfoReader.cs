using System.Collections.Generic;
using UnityEngine;

public interface IShipResourceInfoReader : IJsonObjectReader
{
    ShipResourceData GetShipResourceData(int ShipLevel);
    Dictionary<int, ShipResourceData> ShipResourceData { get; }
 

}