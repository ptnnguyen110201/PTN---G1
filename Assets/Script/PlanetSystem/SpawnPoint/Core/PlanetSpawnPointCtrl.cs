using UnityEngine;

public class PlanetSpawnPointCtrl : MonoBehaviour, IPoolable
{
    [Inject] private IPlanetManager planetManager;
    [Inject] private IPlanetRespawnerFactory planetRespawnerFactory;

    private IPlanetRespawner planetRespawner;

    public void OnDespawn()
    {
    }

    public void OnSpawn()
    {
        GameContext.Instance.Container.InjectInto(this);

        this.planetRespawner = this.planetRespawnerFactory.Create(this);
    }
}
