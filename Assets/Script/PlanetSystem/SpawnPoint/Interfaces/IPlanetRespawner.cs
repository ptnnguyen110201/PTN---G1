public interface IPlanetRespawner
{
    IPlanetManager PlanetManager { get; }
    PlanetSpawnPointCtrl PlanetSpawnPointCtrl { get; }
    PlanetCtrl PlanetCtrl { get; }
    float cooldownTime { get; }
    float cooldownTimer { get; }

    void SetSpawnPoint(PlanetSpawnPointCtrl PlanetSpawnPointCtrl);
    bool PlanetExist();
}