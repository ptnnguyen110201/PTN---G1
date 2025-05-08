using UnityEngine;

public class PlanetSpawnPointCtrl : MonoBehaviour, IPoolable
{
    [Inject] IPlanetRespawner PlanetRespawner;

    public void OnDespawn()
    {

    }

    public void OnSpawn()
    {
        GameContext.Instance.Container.InjectInto(this);
        Invoke(nameof(this.Init), 1f);
    }

    protected void Init()
    {
        this.PlanetRespawner.SetSpawnPoint(this);

    }
}