using System.Collections.Generic;
using UnityEngine;

public interface ISubStationPosReader : IJsonObjectReader
{
    Dictionary<string, SubStationInfo> SubStationPos { get; }

}