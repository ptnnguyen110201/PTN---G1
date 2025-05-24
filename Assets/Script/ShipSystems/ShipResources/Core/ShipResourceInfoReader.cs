using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class ShipResourceInfoReader : JsonObjectReader, IShipResourceInfoReader
{
    public Dictionary<int, ShipResourceData> ShipResourceData { get; private set; } = new();
    protected override string AddressableKey() => "Assets/DataSystem/ResourceShipInfo.json";
    private readonly ShipType ShipType = ShipType.ShipResource;

    public override async Task LoadPath()
    {
        await base.LoadPath();
        if (this.RawList == null || this.RawList.Count == 0)
        {
            Debug.LogWarning("[ShipResourceInfoReader] RawList is null or empty.");
            return;
        }

        foreach (var row in this.RawList)
        {
            this.SetRow(row);

            int Level = this.LoadInt("Level");
            string ResourceType = this.LoadString("Resource");
            int ResourceCount = this.LoadInt("Count");
            ShipResourceData ShipResourceData = new ShipResourceData
            {
                ShipType = this.ShipType,
                Resources = new Dictionary<string, int> { { ResourceType, ResourceCount } }

            };

            if (this.ShipResourceData.ContainsKey(Level)) continue;
            this.ShipResourceData.Add(Level, ShipResourceData);


        }
    }
    public ShipResourceData GetShipResourceData(int ShipLevel)
    {
        if (!this.ShipResourceData.ContainsKey(ShipLevel)) return null;
        return this.ShipResourceData[ShipLevel];
    }



}
