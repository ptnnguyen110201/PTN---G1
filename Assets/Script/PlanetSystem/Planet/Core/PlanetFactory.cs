public class PlanetFactory : IPlanetFactory
{
    public IPlanetStorage PlanetStorage {  get; private set; }
    public IPlanetResourceRestore PlanetResourceRestore { get; private set; }

    public void Create(PlanetCtrl ObjT)
    {
        this.PlanetStorage = new PlanetStorage(this);
        this.PlanetResourceRestore = new PlanetResourceRestore(this, true);
    }

    public void Destroy()
    {
        if (this.PlanetResourceRestore is IUpdatable updatable)
            UpdateInstaller.Instance.Unregister(updatable);
    }
}