using System.Collections;
using UnityEngine;

public class ShipResourceTransfer : ShipResourceState, IShipResourceTransfer
{
    public MainStationCtrl TransferStation { get; private set; }

    public bool IsPlanetDepleted { get; private set; }

    public ShipResourceTransfer(IStateMachine machine, ShipResourceCtrl ship) : base(machine, ship) { }

   

    public override IEnumerator OnEnter()
    {
        this.TransferStation = this.ShipObj.TransferPos.GetComponent<MainStationCtrl>();
        yield break;
    }

    public override IEnumerator OnUpdate()
    {
        foreach (var item in this.ShipObj.ShipResourceFactory.ShipResourceInventory.ResourceMap)
        {
            this.TransferStation.MainStation.MainStationStorage.AddResource(item.Key, item.Value);
        }

        this.ShipObj.ShipResourceFactory.ShipResourceInventory.ResourceMap.Clear();
        yield return null;

        ShipResourceIdle shipResourceIdle = this.StateMachine.StatePool.GetState(() => new ShipResourceIdle(this.StateMachine, this.ShipObj));
        shipResourceIdle.SetDepleted(this.IsPlanetDepleted);
        this.StateMachine.SetState(() => shipResourceIdle);
    }

    public void SetDepleted(bool depleted) => this.IsPlanetDepleted = depleted;

}
