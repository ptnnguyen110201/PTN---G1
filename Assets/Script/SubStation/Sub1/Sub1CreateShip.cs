
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
public class Sub1CreateShip : ICreateShip, IUpdatable
{
    public IMainStation MainStation { get; private set; }
    protected float Timer;
    protected float TimerMax = 2f;
  
    protected Dictionary<string , int> ResourceRequire = new Dictionary<string, int>()
    {
        { "Gold", 1 },
    };

    public Sub1CreateShip()
    {
        this.MainStation = GameContext.Instance.Container.Resolve<IMainStation>();
        UpdateInstaller.Instance.Register(this);

    }
    public void CreateShip()
    {
        int randID = Random.Range(1, 1000);
        this.MainStation.MainStationShipStorage.AddShip(randID.ToString());
    }

    public void OnUpdate(float deltaTime)
    {
        this.Timer += deltaTime;
        if (this.Timer < this.TimerMax) return;
        if (!this.CheckResource()) return;
        this.Timer = 0f;
        this.CreateShip(); 
        this.DeductResource();
    }


    protected bool CheckResource()
    {
        foreach (var resource in this.ResourceRequire)
        {
            if (this.MainStation.MainStationStorage.GetResourceCount(resource.Key) < resource.Value)
            {
                return false;
            }
        }
        return true;
    }


    protected void DeductResource()
    {
        foreach (var resource in this.ResourceRequire)
        {
            this.MainStation.MainStationStorage.RemoveResource(resource.Key, resource.Value);
        }
    }
}