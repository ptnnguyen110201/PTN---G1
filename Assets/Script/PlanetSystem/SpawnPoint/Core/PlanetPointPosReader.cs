using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;

public class PlanetPointPosReader : JsonObjectReader, IPlanetPointPosReader
{
    public Dictionary<string, PlanetPointInfo> SpawnPosMap { get; private set; } = new();

    protected override string JsonPath() => Path.Combine(Application.dataPath, "Script/PlanetSystem/SpawnPoint/Data/PlanetSpawnPos.json");

    public override Task LoadPath()
    {
        string path = this.JsonPath();

        if (!File.Exists(path))
        {
            Debug.LogError($"[PlanetPointPosReader] Path not found: {path}");
            return Task.CompletedTask;
        }

        string json = File.ReadAllText(path);
        var rawList = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(json);
        if (rawList == null)
        {
            Debug.LogError("[PlanetPointPosReader] JSON content is null or invalid format.");
            return Task.CompletedTask;
        }

        for (int i = 0; i < rawList.Count; i++)
        {
            this.SetRow(rawList[i]);

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
            if (!this.SpawnPosMap.ContainsKey(id))
                this.SpawnPosMap.Add(id, pointInfo);
        }

        return Task.CompletedTask;
    }
}
