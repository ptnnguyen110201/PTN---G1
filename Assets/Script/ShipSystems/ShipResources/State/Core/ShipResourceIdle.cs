using System.Collections;
using UnityEngine;

public class ShipResourceIdle : ShipResourceState, IShipResourceIdle
{
    public bool IsPlanetDepleted { get; private set; }

    public ShipResourceIdle(IStateMachine machine, ShipResourceCtrl ship) : base(machine, ship) { }

    public void SetDepleted(bool depleted) => this.IsPlanetDepleted = depleted;

    public override IEnumerator OnEnter()
    {
        yield return new WaitForSeconds(0.1f);

        if (this.IsPlanetDepleted)
        {
            this.ShipObj.ShipResourceFactory.ShipResourceSpanwer.Despawn(this.ShipObj);
            yield break;
        }

        ShipResourceMove shipResourceMove = this.StateMachine.StatePool.GetState(() => new ShipResourceMove(this.StateMachine, this.ShipObj));
        shipResourceMove.SetFull(false);
        this.StateMachine.SetState(() => shipResourceMove);
    }
}
