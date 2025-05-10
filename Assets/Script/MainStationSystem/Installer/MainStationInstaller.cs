

using System.Threading.Tasks;
using UnityEngine;

public class MainStationInstaller : GameSystemInstaller
{

    public override Task Install(DIContainer container)
    {
        container.Bind<IMainStationLevel, MainStationLevel>();
        container.Bind<IMainStationStorage, MainStationStorage>();
        container.Bind<IMainStationUpgarde, MainStationUpgrade>();
        container.Bind<IMainStationShipStorage, MainStationShipStorage>();
        container.Bind<IMainStationCurrency, MainStationCurrency>();
        container.Bind<IMainStation, MainStation>();

        return Task.CompletedTask;

    }

   
}
