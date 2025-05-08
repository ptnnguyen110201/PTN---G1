
using UnityEngine;

public class ShipResourceCtrl : ShipCtrl<ShipResourceCtrl>
{

    Move move;

    public override void OnDespawn()
    {
       
    }

    public override void OnSpawn()
    {
        this.move = new(this.transform);
    }


    protected void Update()
    {
        this.move.Moving();
    }


}


public class Move 
{
    Transform objMove;
    public Move(Transform objMove) 
    { 
        this.objMove = objMove;
        //UpdateInstaller.Instance.Register(this);
    }

    public void Moving() 
    {
        this.objMove.transform.position += Time.deltaTime * Vector3.up;
    }

    public void OnUpdate(float deltaTime)
    {
       this.Moving();
    }
}


