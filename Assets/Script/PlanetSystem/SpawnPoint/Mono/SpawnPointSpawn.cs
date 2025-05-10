using UnityEngine;

public class SpawnPointSpawn : MonoBehaviour 
{
    [Inject] IPlanetSpawnPointManager PlanetSpawnPointManager;


    protected void Start()
    {

        Invoke(nameof(this.Test), 3);
    }


    protected void Test() 
    {
        GameContext.Instance.Container.InjectInto(this);
        this.PlanetSpawnPointManager.PlanetSpawnPointSpawner.SpawnByPoint();
    }
}