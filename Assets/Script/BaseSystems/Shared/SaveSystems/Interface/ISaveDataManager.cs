public interface ISaveManager : IInitializableSystem
{
    ISaveRegistry SaveRegistry { get; }
    void Save();
    void Load();
}