using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class SubStationPosReader : JsonObjectReader, ISubStationPosReader
{
    public Dictionary<string, SubStationInfo> SubStationPos { get; private set; } = new();

    protected override string AddressableKey() => "Assets/DataSystem/SubStationPos.json";

    public override async Task LoadPath()
    {
        await base.LoadPath();

        if (this.RawList == null || this.RawList.Count == 0)
        {
            Debug.LogWarning("[SubStationPosReader] RawList is null or empty.");
            return;
        }

        foreach (var row in this.RawList)
        {
            this.SetRow(row);

            string id = this.LoadString("ID");
            string name = this.LoadString("Name");
            Vector3 pos = this.LoadVector3("PosX", "PosY", "PosZ");

            SubStationInfo info = new SubStationInfo
            {
                Name = name,
                StationPos = pos
            };

            if (this.SubStationPos.ContainsKey(id)) continue;
            this.SubStationPos.Add(id, info);
            
          
        }
    }
}
