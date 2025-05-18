using System.Collections;
using UnityEngine;

public class ShipResourceMove : ShipResourceState, IShipResourceMove
{
    public Transform Target { get; private set; }
    public bool IsFull { get; private set; }
    public bool IsPlanetDepleted { get; private set; }

    public ShipResourceMove(IStateMachine stateMachine, ShipResourceCtrl shipObj) : base(stateMachine, shipObj) { }

    public override IEnumerator OnEnter()
    {
        this.Target = this.IsFull ? this.ShipObj.TransferPos : this.ShipObj.CollectPos;
        this.ShipObj.ShipResourceFactory.ShipResourceLookat.SetObjLookat(this.Target);
        yield break;
    }

    public override IEnumerator OnUpdate()
    {
        if (Vector3.Distance(this.ShipObj.transform.position, this.Target.position) > 0.5)
        {
            this.MoveToTarget(this.Target);
        }
        else
        {
            yield return null;

            if (this.IsFull)
            {
                ShipResourceTransfer shipResourceTransfer = this.StateMachine.StatePool.GetState(() => new ShipResourceTransfer(this.StateMachine, this.ShipObj));
                shipResourceTransfer.SetDepleted(this.IsPlanetDepleted);
                this.StateMachine.SetState(() => shipResourceTransfer);
            }
            else
            {
                this.StateMachine.SetState(() => new ShipResourceCollect(this.StateMachine, this.ShipObj));
            }
        }

        yield return null;
    }

    private void MoveToTarget(Transform target)
    {
        this.ShipObj.transform.position = Vector3.MoveTowards(
            this.ShipObj.transform.position,
            target.position,
            1f * Time.deltaTime
        );
    }

    public void SetFull(bool full) => this.IsFull = full;
    public void SetDepleted(bool depleted) => this.IsPlanetDepleted = depleted;
}
