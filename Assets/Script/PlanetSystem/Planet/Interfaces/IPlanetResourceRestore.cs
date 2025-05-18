using System.Collections.Generic;

public interface IPlanetResourceRestore 
{
    IPlanetFactory PlanetFactory { get; }
    Dictionary<string, int> ResoureRestore {  get; }
    float RestoreTime { get; }
    float RestoreTimer { get; }
    bool isPlanetRestore { get; }
    bool RestoreTiming(float deltaTime);
    void Restore();
}