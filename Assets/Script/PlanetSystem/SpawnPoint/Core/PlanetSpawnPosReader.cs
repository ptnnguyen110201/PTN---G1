using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;

public class PlanetSpawnPosReader : JsonObjectReader, IPlanetSpawnPosReader
{
    public Dictionary<string, Vector3> SpawnPosMap { get; private set; }
    protected override string JsonPath() => Path.Combine(Application.dataPath, "Script/PlanetSystem/SpawnPoint/Data/PlanetSpawnPos.json");
    public PlanetSpawnPosReader()
    {
        this.SpawnPosMap = new Dictionary<string, Vector3>();

        string path = this.JsonPath();

        if (!File.Exists(path))
        {
            Debug.Log("Path fail");
            return;
        }

        string json = File.ReadAllText(path);
        var rawList = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(json);

        if (rawList == null) return;

        for (int i = 0; i < rawList.Count; i++)
        {
            this.SetRow(i); 

            string id = this.LoadString("ID");
            Vector3 pos = this.LoadVector3("PosX", "PosY", "PosZ");

            if (!this.SpawnPosMap.ContainsKey(id))
            {
                this.SpawnPosMap.Add(id, pos);
            }
            Debug.Log("ID: " + id + "X: " + pos.x + "T: " + pos.y + "Z: " + pos.z);

        }
    }

    

    
    

    
}
