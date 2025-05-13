using UnityEngine;

public class SpawnPointSpawn : MonoBehaviour 
{
    [Inject] IMainStationCtrl MainStationCtrl;
    [Inject] IMainStation MainStation;
    protected void Start()
    {
        Invoke(nameof(this.Test), 3);
    }


    protected void Test()
    {
        GameContext.Instance.Container.InjectInto(this);

    }
}
