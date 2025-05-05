public class GameContext
{
    public static GameContext Instance { get; } = new GameContext();
    public DIContainer Container { get; private set; }

    public void SetDIContainer(DIContainer container)
    {
        this.Container = container;
    }

   
}