using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipResourceCollect : ShipResourceState, IShipResourceCollect
{
    public Dictionary<string, int> ResourceCollect { get; private set; } = new();
    public PlanetCtrl CollectPlanet { get; private set; }

    public ShipResourceCollect(IStateMachine machine, ShipResourceCtrl ship) : base(machine, ship) { }

    public override IEnumerator OnEnter()
    {
        this.CollectPlanet = this.ShipObj.CollectPos.GetComponent<PlanetCtrl>();
        this.ResourceCollect = new Dictionary<string, int>(this.ShipObj.ShipResourceData.Resources);
        yield break;
    }

    public override IEnumerator OnUpdate()
    {
        yield return new WaitForSeconds(0.1f);
        bool isDepleted = true;

        foreach (var item in this.ResourceCollect)
        {
            int available = this.CollectPlanet.PlanetFactory.PlanetStorage.GetResourceCount(item.Key);
            int take = Mathf.Min(available, item.Value);
            this.CollectPlanet.PlanetFactory.PlanetStorage.RemoveResource(item.Key, take);
            this.ShipObj.ShipResourceFactory.ShipResourceInventory.AddResource(item.Key, take);

            if (available > 0) isDepleted = false;
        }

        yield return null;

        ShipResourceMove shipResourceMove = this.StateMachine.StatePool.GetState(() => new ShipResourceMove(this.StateMachine, this.ShipObj));
        shipResourceMove.SetFull(true);
        shipResourceMove.SetDepleted(isDepleted);

        this.StateMachine.SetState(() => shipResourceMove);
    }
}
