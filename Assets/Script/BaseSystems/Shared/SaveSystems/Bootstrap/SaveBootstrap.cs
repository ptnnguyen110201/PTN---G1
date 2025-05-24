


using System.Threading.Tasks;

public static class SaveBootstrap
{
    public static async Task Initialize(DIContainer DIContainer)
    {
        SaveManagerInstaller saveSystemInstaller = new SaveManagerInstaller();
        await saveSystemInstaller.Install(DIContainer);
    }

    public static void Initialize()
    {
        BaseBootstrap.AttachInstaller<SaveManagerCtrl>(true);
    }
}

