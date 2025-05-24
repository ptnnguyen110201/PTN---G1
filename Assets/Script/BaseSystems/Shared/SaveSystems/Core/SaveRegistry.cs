using System.Collections.Generic;

public class SaveRegistry : ISaveRegistry
{
    protected List<ISaveable> saveables = new();

    public void Register(ISaveable saveable)
    {
        if (this.saveables.Contains(saveable)) return;
            this.saveables.Add(saveable);
    }

    public void Unregister(ISaveable saveable)
    {
        if (!this.saveables.Contains(saveable)) return;
            this.saveables.Remove(saveable);
    }

    public List<ISaveable> GetAll() => this.saveables;
}
