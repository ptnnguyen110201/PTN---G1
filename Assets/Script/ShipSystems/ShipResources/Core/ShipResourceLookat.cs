using UnityEngine;

public class ShipResourceLookat : ShipLookat<ShipResourceCtrl>, IShipResourceLookat, IUpdatable
{
    public Transform ObjLookat { get; private set; }
    public ShipResourceLookat(ShipResourceCtrl shipObj) : base(shipObj) 
    { 
        UpdateInstaller.Instance.Register(this);
    }

    public override void LookAt(Transform target)
    {
        if (target == null) return;

        Vector3 dir = target.position - this.ShipObj.transform.position;
        if (dir == Vector3.zero) return;

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
        Quaternion targetRotation = Quaternion.Euler(0f, 0f, angle);

        this.ShipObj.transform.rotation = Quaternion.Slerp(
            this.ShipObj.transform.rotation,
            targetRotation,
            5f * Time.deltaTime
        );
    }

    public void OnUpdate(float deltaTime) => this.LookAt(this.ObjLookat);
    
    public void SetObjLookat(Transform ObjLookat) => this.ObjLookat = ObjLookat;



}