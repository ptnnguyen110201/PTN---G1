using System.Collections.Generic;

public class PlanetPointFactory : IPlanetPointFactory
{
    public IPlanetRespawner PlanetRespawner { get; private set; }

    public void Create(PlanetPointCtrl ObjT)
    {
        this.PlanetRespawner = new PlanetRespawner(ObjT);
    }

    public void Destroy()
    {
        if (this.PlanetRespawner is IUpdatable updatable)
            UpdateInstaller.Instance.Unregister(updatable);
    }
}
