using System.Collections.Generic;
using UnityEngine;

public interface IShipResourceSender : IInitializableSystem
{
    IMainStationCtrl MainStationCtrl { get; }
    IMainStationShipStorage MainStationShipStorage { get; }
    IShipResourceSpawner ShipResourceSpawner { get; }

    void SendShip(string ShipID,Transform CollectPos);
    void ReMoveShip(string ShipID);
    HashSet<string> ShipSended {  get; }
}