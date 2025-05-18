using System.Collections;

public abstract class ShipResourceState : IState
{
    public IStateMachine StateMachine { get; private set; }
    public ShipResourceCtrl ShipObj { get; private set; }
    protected ShipResourceState(IStateMachine machine, ShipResourceCtrl ship)
    {
        this.StateMachine = machine;
        this.ShipObj = ship;
    }

    public virtual IEnumerator OnEnter() { yield break; }
    public virtual IEnumerator OnUpdate() { yield break; }
    public virtual IEnumerator OnExit() { yield break; }
}
