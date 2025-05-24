using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UnityEngine;

public class SaveManager : ISaveManager
{
    public ISaveRegistry SaveRegistry { get; private set; }
    private readonly string saveFolderPath = Path.Combine(Application.dataPath, "SaveSystems");
    private readonly string saveFilePath;
    private readonly JsonSerializerSettings settings;
    public SaveManager(ISaveRegistry saveRegistry)
    {
        this.SaveRegistry = saveRegistry;
        this.saveFilePath = Path.Combine(saveFolderPath, "save.json");
        this.settings = new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.Auto,
            Formatting = Formatting.Indented
        };
    }

    public Task Initialize()
    {
        this.Load();
        return Task.CompletedTask;
    }

    public void Save()
    {
        if (!Directory.Exists(saveFolderPath))
        {
            Directory.CreateDirectory(saveFolderPath);
        }

        SaveDataContainer container = new SaveDataContainer();

        foreach (ISaveable saveable in this.SaveRegistry.GetAll())
        {
            container.KeyValues[saveable.SaveKey] = saveable.CaptureData();
        }

        File.WriteAllText(saveFilePath, JsonConvert.SerializeObject(container, settings));
        Debug.Log("Game Saved to " + saveFilePath);
    }

    public void Load()
    {
        if (!File.Exists(saveFilePath))
        {
            Debug.LogWarning("Save file not found.");
            return;
        }

        SaveDataContainer container = JsonConvert.DeserializeObject<SaveDataContainer>(File.ReadAllText(saveFilePath), settings);

        foreach (ISaveable saveable in this.SaveRegistry.GetAll())
        {
            if (container.KeyValues.TryGetValue(saveable.SaveKey, out object data))
            {
                saveable.RestoreData(data);
            }
        }

        Debug.Log("Game Loaded from " + saveFilePath);
    }
}