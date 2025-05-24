using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.Mathematics;
using UnityEngine;

public class ShipResourceSender : IShipResourceSender
{
    public HashSet<string> ShipSended { get; private set; } = new HashSet<string>();
    public IMainStationCtrl MainStationCtrl { get; private set; }
    public IMainStationShipStorage MainStationShipStorage { get; private set; }
    public IShipResourceSpawner ShipResourceSpawner { get; private set; }

    public IShipResourceInfoReader ShipResourceInfoReader { get; private set; }

    public ShipResourceSender(
        IMainStationShipStorage MainStationShipStorage,
        IShipResourceSpawner ShipResourceSpawner,
        IMainStationCtrl MainStationCtrl,
        IShipResourceInfoReader ShipResourceInfoReader
        )
    {
        this.MainStationShipStorage = MainStationShipStorage;
        this.ShipResourceSpawner = ShipResourceSpawner;
        this.MainStationCtrl = MainStationCtrl;
        this.ShipResourceInfoReader = ShipResourceInfoReader;
    }

    public Task Initialize()
    {

        return Task.CompletedTask;
    }

    public void SendShip(string ShipID, Transform CollectPos)
    {
        int shipLevel = this.MainStationShipStorage.GetShip(ShipID);
        if (shipLevel == 0) return;

        ShipResourceData shipResourceData = this.ShipResourceInfoReader.GetShipResourceData(shipLevel);

        Transform TransferPos = this.MainStationCtrl.mainStationCtrl.transform;

        ShipResourceCtrl ShipResource = this.ShipResourceSpawner.SpawnShipResource
            (
                "ShipResource1",
                TransferPos.transform.position,
                Quaternion.identity
            );
        ShipResource.SetShipResourceData(shipResourceData);
        ShipResource.SetPos(TransferPos, CollectPos);
        this.ShipSended.Add(ShipID);


    }

    public void ReMoveShip(string ShipID)
    {
        if (!this.ShipSended.Contains(ShipID)) return;
        this.ShipSended.Remove(ShipID);
    }
}