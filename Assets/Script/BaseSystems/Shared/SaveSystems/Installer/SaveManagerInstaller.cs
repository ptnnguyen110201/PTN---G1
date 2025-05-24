using System.Threading.Tasks;

public class SaveManagerInstaller : GameSystemInstaller
{
    public override Task Install(DIContainer container)
    {
        container.Bind<ISaveRegistry, SaveRegistry>();
        container.Bind<ISaveManager, SaveManager>();
      
        return Task.CompletedTask;
    }
}
