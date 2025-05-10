using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
public abstract class JsonObjectReader : IJsonObjectReader
{
    protected Dictionary<string, object> Data;
    protected abstract string JsonPath();

    public JsonObjectReader()
    {
        string path = this.JsonPath();

        if (!File.Exists(path))
        {
  
            return;
        }

        string jsonContent = File.ReadAllText(path);
        var rawList = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(jsonContent);
        if (rawList != null && rawList.Count > 0)
        {
            this.Data = rawList[0];
        }
        else
        {
          
            this.Data = new Dictionary<string, object>();
        }
    }

    public void SetRow(int index)
    {
        string jsonContent = File.ReadAllText(this.JsonPath());
        var rawList = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(jsonContent);
        if (rawList != null && index < rawList.Count)
        {
            this.Data = rawList[index];
        }
    }

    public string LoadString(string key)
    {
        if (Data.TryGetValue(key, out object value)) return value.ToString();
        return string.Empty;
    }

    public int LoadInt(string key)
    {
        if (Data.TryGetValue(key, out object value) && int.TryParse(value.ToString(), out int result)) return result;
        return 0;
    }

    public float LoadFloat(string key)
    {
        if (Data.TryGetValue(key, out object value) && float.TryParse(value.ToString(), out float result)) return result;
        return 0f;
    }

    public bool LoadBool(string key)
    {
        if (Data.TryGetValue(key, out object value) && bool.TryParse(value.ToString(), out bool result)) return result;
        return false;
    }

    public Vector3 LoadVector3(string keyX, string keyY, string keyZ)
    {
        return new Vector3(LoadFloat(keyX), LoadFloat(keyY), LoadFloat(keyZ));
    }

    public bool HasKey(string key) => Data.ContainsKey(key);
}
