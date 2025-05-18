using UnityEngine;

public class SpawnPointSpawn : MonoBehaviour 
{
    [Inject] IMainStation MainStation;
    [Inject] IShipResourceManager ShipResourceManager;
    protected void Start()
    {
        Invoke(nameof(this.Test), 3f);   
    }


    protected void Test()
    {
        GameContext.Instance.Container.InjectInto(this);
        MainStation.MainStationShipStorage.AddShip("Ship1");


    }
}
