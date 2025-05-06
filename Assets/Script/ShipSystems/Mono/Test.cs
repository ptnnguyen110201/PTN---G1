using UnityEngine;

public class Test : MonoBehaviour
{
    [Inject] IShipManager<ShipResourceCtrl> shipResourceManager;
    [Inject] IShipManager<ShipEnemyCtrl> shipEnemyManager;

    void Start()
    {
        GameContext.Instance.Container.InjectInto(this);

        Invoke(nameof(this.Test1), 2);

    }

    protected void Test1() 
    {
        shipResourceManager.Spawner.Spawn(PrefabCode.ShipResource1, transform.position, transform.rotation);
        shipEnemyManager.Spawner.Spawn(PrefabCode.Enemy1, transform.position, transform.rotation);


        GameObject newEnemy = this.shipEnemyManager.PrefabLoader.GetPrefab(PrefabCode.Enemy1);
        Debug.Log(newEnemy);
    }
}
