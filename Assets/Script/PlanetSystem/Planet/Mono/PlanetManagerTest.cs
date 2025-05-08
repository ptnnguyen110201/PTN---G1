using UnityEngine;

public class PlanetManagerTest : MonoBehaviour
{
    [Inject] IPlanetSpawnPointManager planetSpawnPointManager;

    protected void Start()
    {
        GameContext.Instance.Container.InjectInto(this);
        Invoke(nameof(this.Test), 1f);
    }


    void Test() 
    {
        this.planetSpawnPointManager.Spawner.Spawn(PrefabCode.PlanetSpawnPoint, transform.position, transform.rotation);
    }

}
