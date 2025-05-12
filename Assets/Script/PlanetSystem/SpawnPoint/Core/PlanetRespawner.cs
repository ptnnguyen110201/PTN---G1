using System.Collections.Generic;
using UnityEngine;

public class PlanetRespawner : IPlanetRespawner, IUpdatable
{
    public PlanetCtrl PlanetCtrl { get; private set; }
    public PlanetPointCtrl PlanetPointCtrl { get; private set; }
    public float cooldownTime { get; private set; } = 10f;
    public float cooldownTimer { get; private set; } = 0f;
    public PlanetRespawner(PlanetPointCtrl PlanetSpawnPointCtrl)
    {
        this.PlanetPointCtrl = PlanetSpawnPointCtrl;
        UpdateInstaller.Instance.Register(this);

    }
    public void OnUpdate(float deltaTime)
    {
        if (this.PlanetExist()) return;
        if (!this.CanRespawn(deltaTime)) return;
        this.SpawnPlanet();
    }

    protected bool CanRespawn(float deltaTime)
    {
        this.cooldownTimer += deltaTime;

        if (this.cooldownTimer < this.cooldownTime) return false;
        this.cooldownTimer = 0;

        return true;
    }

    protected void SpawnPlanet()
    {
        this.PlanetCtrl = this.PlanetPointCtrl.PlanetManager.PlanetSpawner.Spawn(
            this.GetPlanet(),
           this.PlanetPointCtrl.transform.position,
           this.PlanetPointCtrl.transform.rotation
        );

    }

    public bool PlanetExist()
    {
        if (this.PlanetCtrl == null) return false;
        return true;
    }

    public string GetPlanet()
    {
        int rand = Random.Range(0, this.PlanetPointCtrl.PlanetFactory.PlanetList.Count);
        return this.PlanetPointCtrl.PlanetFactory.PlanetList[rand];
    }

}
