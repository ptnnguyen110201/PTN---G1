
using System.Threading.Tasks;
using UnityEngine;
public static class MainStationBootstrap
{
    public static async Task Initialize(DIContainer DIContainer)
    {
     
        MainStationInstaller installer = new MainStationInstaller();  
        await installer.Install(DIContainer);

        IMainStation MainStation = DIContainer.Resolve<IMainStation>();
        await MainStation.Initialize();
    }
}

