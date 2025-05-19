using UnityEngine;

public class ShipResourceFactory : IShipResourceFactory
{
    public ShipResourceCtrl ObjT { get; private set; } 
    public IShipResourceSpawner ShipResourceSpanwer { get; private set; }
    public IStateMachine StateMachine { get; private set; }
    public IShipResourceInventory ShipResourceInventory { get; private set; }
    public IShipResourceLookat ShipResourceLookat { get; private set; }


    public void Create(ShipCtrl ObjT)
    {
        this.ObjT = (ShipResourceCtrl)ObjT;
        this.ShipResourceSpanwer = GameContext.Instance.Container.Resolve<IShipResourceSpawner>();
        this.StateMachine = new StateMachine(this.ObjT);
        this.ShipResourceInventory = new ShipResourceInventory();
        this.ShipResourceLookat = new ShipResourceLookat(this.ObjT);
        this.StateMachine.SetState(() => new ShipResourceIdle(this.StateMachine, this.ObjT));
    }

    public void Destroy()
    {
        if (this.ShipResourceLookat is IUpdatable ShipLookat)
            UpdateInstaller.Instance.Unregister(ShipLookat);


        this.StateMachine.StatePool.Clear(); 

        this.ObjT = null;
        this.StateMachine = null;
        this.ShipResourceInventory = null;
        this.ShipResourceLookat = null;
    }
}