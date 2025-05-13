using System.Collections.Generic;
using UnityEngine;

public class PlanetResourceRestore : IPlanetResourceRestore, IUpdatable
{
    public IPlanetFactory PlanetFactory { get; private set; }
    public Dictionary<string, int> ResoureRestore { get; private set; } = new Dictionary<string, int>()
    {
        {"Gold" , 1}
    };
    public float RestoreTime { get; private set; } = 1;
    public float RestoreTimer { get; private set; } = 0;
    public bool isPlanetRestore { get; private set; }



    public PlanetResourceRestore(IPlanetFactory PlanetFactory, bool IsPlanetRestore = false)
    {
        this.PlanetFactory = PlanetFactory;
        this.isPlanetRestore = IsPlanetRestore;
        UpdateInstaller.Instance.Register(this);
    }


    public void OnUpdate(float deltaTime)
    {
        if (!this.RestoreTiming(deltaTime)) return;
        this.Restore();
    }

    public bool RestoreTiming(float deltaTime)
    {
        if (!this.isPlanetRestore)
        {
            this.RestoreTimer = 0;
            return false;
        }
        this.RestoreTimer += deltaTime;
        if (this.RestoreTimer < this.RestoreTime) return false;
        this.RestoreTimer = 0;
        return true;
    }

    public void Restore()
    {
        if (this.ResoureRestore.Count <= 0) return;
        foreach(var vkp in this.ResoureRestore) 
        {
            this.PlanetFactory.PlanetStorage.AddResource(vkp.Key, vkp.Value);
            Debug.Log("ResoureType: " + vkp.Key + "Count: " + vkp.Value);
        }

    }
}