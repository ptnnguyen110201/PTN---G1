using UnityEngine;
using System.IO;
using Newtonsoft.Json;

public static class UniversalSaveManager
{
    private static readonly string saveFolderPath = Path.Combine(Application.dataPath, "SaveSystems/Data");
    private static readonly string saveFilePath = Path.Combine(saveFolderPath, "save.json");

    private static readonly JsonSerializerSettings settings = new JsonSerializerSettings
    {
        TypeNameHandling = TypeNameHandling.Auto,
        Formatting = Formatting.Indented,
        
    };

    public static void Save()
    {
        if (!Directory.Exists(saveFolderPath))
        {
            Directory.CreateDirectory(saveFolderPath);
        }

        SaveDataContainer container = new SaveDataContainer();

        foreach (ISaveable saveable in SaveRegistry.GetAll())
        {
            object data = saveable.CaptureData();
            container.KeyValues[saveable.SaveKey] = data;
        }

        string finalJson = JsonConvert.SerializeObject(container, settings);
        File.WriteAllText(saveFilePath, finalJson);
        Debug.Log("Game Saved to " + saveFilePath);
    }

    public static void Load()
    {
        if (!File.Exists(saveFilePath))
        {
            Debug.LogWarning("Save file not found.");
            return;
        }

        string json = File.ReadAllText(saveFilePath);
        SaveDataContainer container = JsonConvert.DeserializeObject<SaveDataContainer>(json, settings);

        foreach (ISaveable saveable in SaveRegistry.GetAll())
        {
            if (!container.KeyValues.TryGetValue(saveable.SaveKey, out object savedObj)) continue;

            saveable.RestoreData(savedObj);
        }
      
        Debug.Log("Game Loaded from " + saveFilePath);
    }

   
}
