using System.Collections.Generic;

public static class SaveRegistry
{
    private static readonly List<ISaveable> saveables = new();

    public static void Register(ISaveable saveable)
    {
        if (!saveables.Contains(saveable))
            saveables.Add(saveable);
    }

    public static void Unregister(ISaveable saveable)
    {
        saveables.Remove(saveable);
    }

    public static List<ISaveable> GetAll() => saveables;
}
