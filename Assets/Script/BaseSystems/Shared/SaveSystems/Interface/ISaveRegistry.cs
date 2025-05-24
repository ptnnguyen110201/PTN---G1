using System.Collections.Generic;

public interface ISaveRegistry
{
    void Register(ISaveable saveable);
    void Unregister(ISaveable saveable);
    List<ISaveable> GetAll();
}
