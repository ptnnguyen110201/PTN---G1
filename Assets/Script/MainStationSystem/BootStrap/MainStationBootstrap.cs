
using System.Threading.Tasks;

public static class MainStationBootstrap
{
    public static async Task Initialize(DIContainer DIContainer)
    {
        MainStationInstaller installer = new MainStationInstaller();
        await installer.Install(DIContainer);



        
    }
}

