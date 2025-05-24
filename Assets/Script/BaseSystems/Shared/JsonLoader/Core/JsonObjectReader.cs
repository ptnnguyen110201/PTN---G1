using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public abstract class JsonObjectReader : IJsonObjectReader
{
    protected Dictionary<string, object> Data;
    protected List<Dictionary<string, object>> RawList; 

    protected abstract string AddressableKey();

    public virtual async Task LoadPath()
    {
        AsyncOperationHandle<TextAsset> handle = Addressables.LoadAssetAsync<TextAsset>(this.AddressableKey());
        await handle.Task;

        if (handle.Status != AsyncOperationStatus.Succeeded)
        {
            Debug.LogError($"[JsonObjectReader] Failed to load JSON with key: {this.AddressableKey()}");
            return;
        }

        string jsonContent = handle.Result.text;
        this.RawList = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(jsonContent);

        if (this.RawList == null || this.RawList.Count == 0)
        {
            Debug.LogWarning($"[JsonObjectReader] No data found in JSON: {this.AddressableKey()}");
            return;
        }

        this.Data = this.RawList[0];
        Addressables.Release(handle);
    }

    public void SetRow(Dictionary<string, object> rowData)
    {
        this.Data = rowData;
    }

    public void SetRow(int index)
    {
        if (this.RawList != null && index >= 0 && index < this.RawList.Count)
        {
            this.Data = this.RawList[index];
        }
        else
        {
            Debug.LogWarning($"[JsonObjectReader] Invalid index: {index}");
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

    public bool HasKey(string key) => Data != null && Data.ContainsKey(key);

    protected object GetValue(string key)
    {
        if (!this.Data.ContainsKey(key))
        {
            Debug.LogWarning($"[JsonObjectReader] Key not found: {key}");
            return null;
        }

        return this.Data[key];
    }
}
