using System;
using System.Collections.Generic;

[Serializable]
public class PlanetUpdater : ILateUpdatable
{
    public PlanetCtrl planetCtrl;
    public List<Resource> resources = new List<Resource>();
    public float RestoreTime;
    public float RestoreTimer;
    public PlanetUpdater(PlanetCtrl planetCtrl)
    {
        this.planetCtrl = planetCtrl;
        UpdateInstaller.Instance.Register(this);
    }

    public void OnLateUpdate(float deltaTime)
    {
        this.resources.Clear();
        Dictionary<string, int> ResourceMap = new (this.planetCtrl.PlanetFactory.PlanetStorage.ResourceMap);

        foreach(var kvp in ResourceMap) 
        {
            Resource resource = new()
            {
                ResourceType = kvp.Key,
                ResourceCount = kvp.Value
            };
            this.resources.Add(resource);
        }
        this.RestoreTime = this.planetCtrl.PlanetFactory.PlanetResourceRestore.RestoreTime;
        this.RestoreTimer = this.planetCtrl.PlanetFactory.PlanetResourceRestore.RestoreTimer;
    }
}

[Serializable]
public class Resource 
{
    public string ResourceType;
    public int ResourceCount;
} 