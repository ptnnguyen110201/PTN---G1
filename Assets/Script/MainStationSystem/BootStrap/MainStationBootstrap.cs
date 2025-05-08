
public static class MainStationBootstrap
{
    public static void Initialize(DIContainer DIContainer)
    {
        MainStationInstaller installer = new MainStationInstaller();
        installer.Install(DIContainer);



        
    }
}

