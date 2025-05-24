using System;
using System.Collections.Generic;
[Serializable]
public class ShipResourceData : ShipData
{
    public Dictionary<string, int> Resources = new Dictionary<string, int>();
}