
using TMPro;
using UnityEngine;

public class Test : MonoBehaviour
{

    [Inject] IShipResourceManager shipResourceManager;


    protected void Start()
    {
        GameContext.Instance.Container.InjectInto(this);

        Invoke(nameof(this.TestSpawnMove), 1f);
    }

    protected void TestSpawnMove() 
    {
        this.shipResourceManager.Spawn(PrefabCode.ShipResource1, transform.position, transform.rotation);
    }
}
