using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;

public class PlanetPointPosReader : JsonObjectReader, IPlanetPointPosReader
{
    public Dictionary<string, PlanetPointInfo> SpawnPosMap { get; private set; } = new();

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

            string id = this.LoadString("ID");
            Vector3 pos = this.LoadVector3("PosX", "PosY", "PosZ");

            List<string> nameList = new();
            object rawName = this.GetValue("Name");

            if (rawName is Newtonsoft.Json.Linq.JArray jArray)
            {
                foreach (var item in jArray)
                {
                    if (item != null)
                        nameList.Add(item.ToString());
                }
            }

            PlanetPointInfo pointInfo = new()
            {
                SpawnPoint = pos,
                PlanetList = nameList
            };
            if (this.SpawnPosMap.ContainsKey(id)) continue;
            this.SpawnPosMap.Add(id, pointInfo);

        }
    }

    protected override string AddressableKey() => "Assets/DataSystem/PlanetPointPos.json";




}
