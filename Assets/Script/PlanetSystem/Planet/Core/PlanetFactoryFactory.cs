using System.Collections;
using System.Collections.Generic;

public class PlanetFactoryFactory : IPlanetFactoryFactory
{
    protected Stack<IPlanetFactory> IPlanetFactory = new Stack<IPlanetFactory>();
    public IPlanetFactory CreateFactory(PlanetCtrl planet)
    {
        IPlanetFactory PlanetFactory;
        if(this.IPlanetFactory.Count <= 0) PlanetFactory = new PlanetFactory();
        else PlanetFactory = this.IPlanetFactory.Pop();
        PlanetFactory.Create(planet);
        return PlanetFactory;
    }
    public void ReleaseFactory(IPlanetFactory planetPointFactory)
    {
        planetPointFactory.Destroy();
        this.IPlanetFactory.Push(planetPointFactory);
    }
}
