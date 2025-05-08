using UnityEngine;

public class PlanetRespawner : IPlanetRespawner, IUpdatable
{
    public PlanetCtrl PlanetCtrl { get; private set; }
    public IPlanetManager PlanetManager { get; private set; }
    public PlanetSpawnPointCtrl PlanetSpawnPointCtrl { get; private set; }
    public float cooldownTime { get; private set; } = 10f;
    public float cooldownTimer { get; private set; } = 0f;


    public PlanetRespawner(IPlanetManager planetManager)
    {
        this.PlanetManager = planetManager;
        UpdateInstaller.Instance.Register(this);
    }

    public void SetSpawnPoint(PlanetSpawnPointCtrl spawnPoint)
    {
        this.PlanetSpawnPointCtrl = spawnPoint;
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
        this.PlanetCtrl = PlanetManager.Spawner.Spawn(
            PrefabCode.IronPlanet,
            PlanetSpawnPointCtrl.transform.position,
            PlanetSpawnPointCtrl.transform.rotation
        );

    }

    public bool PlanetExist()
    {
        if (this.PlanetCtrl == null) return false;
        return true;
    }
}
