using System.Collections.Generic;
using UnityEngine;

public class PlanetRespawner : IPlanetRespawner, IUpdatable
{
    public PlanetCtrl PlanetCtrl { get; private set; }
    public PlanetPointCtrl PlanetPointCtrl { get; private set; }
    public float cooldownTime { get; private set; } = 3f;
    public float cooldownTimer { get; private set; } = 0f;
    public List<string> PlanetList { get; private set; }
    public void SetPlanetList(List<string> PlanetList) => this.PlanetList = new List<string>(PlanetList);
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

        string planetName = this.GetPlanet();
        Vector3 spawnPoint = this.PlanetPointCtrl.transform.position;
        Quaternion spawnRot = this.PlanetPointCtrl.transform.rotation;

        IPlanetSpawner planetSpawner = this.PlanetPointCtrl.PlanetManager.PlanetSpawner;
        PlanetCtrl planetCtrl =  planetSpawner.Spawn(planetName, spawnPoint, spawnRot);
        this.PlanetCtrl = planetCtrl;
    }

    public bool PlanetExist()
    {
        if (this.PlanetCtrl == null) return false;
        return true;
    }

    public string GetPlanet()
    {
        int rand = Random.Range(0, this.PlanetList.Count);
        return this.PlanetList[rand];
    }

}
